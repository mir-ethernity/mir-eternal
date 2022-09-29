using AccountServer.Models;
using AccountServer.Services.Default;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountServer.Services
{
    public class Network
    {
        public UdpClient LocalServer;
        public ConcurrentQueue<PacketData> IncomingQueue;
        private readonly IAccountService _accountService;
        private readonly IAppConfiguration _settings;
        private readonly IStatsService _stats;
        private readonly ILogger<Network> _logger;

        public Network(
            IAccountService accountService,
            IAppConfiguration settings,
            ILogger<Network> logger,
            IStatsService statsService
        )
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _stats = statsService ?? throw new ArgumentNullException(nameof(statsService));
            _logger = logger;
        }

        private async void StartAccountServer()
        {
            while (LocalServer != null)
            {
                try
                {
                    if (LocalServer.Available == 0)
                    {
                        await Task.Delay(1);
                        continue;
                    }

                    var packet = default(PacketData);
                    packet.ReceivedData = LocalServer.Receive(ref packet.ClientAddress);
                    if (packet.ReceivedData.Length > 1024)
                    {
                        _logger.LogWarning($"Excessively long packet received Address: {packet.ClientAddress}, Length: {packet.ReceivedData.Length}");
                    }
                    else
                    {
                        IncomingQueue.Enqueue(packet);
                        _stats.TotalBytesReceived += packet.ReceivedData.Length;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error ocurred receiving data");
                }
            }
        }

        private async void StartLoginGate()
        {
            _logger.LogDebug("--- [ Ready to Process Client Requests ] ---");

            while (LocalServer != null)
            {
                try
                {
                    if (IncomingQueue.IsEmpty || !IncomingQueue.TryDequeue(out PacketData packet))
                    {
                        await Task.Delay(1);
                        continue;
                    }

                    var data = Encoding.UTF8.GetString(packet.ReceivedData, 0, packet.ReceivedData.Length);
                    var parts = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length <= 3 || !int.TryParse(parts[0], out var packetCounter) || !int.TryParse(parts[1], out var packetId))
                    {
                        _logger.LogWarning($"Bad Packet Received, Address: {packet.ClientAddress}, Length: {packet.ReceivedData.Length}");
                    }
                    else
                    {
                        switch (packetId)
                        {
                            case 0: // login
                                if (!await _accountService.CheckLogin(parts[2], parts[3]))
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 1 wrong user name or password"));
                                }
                                else
                                {
                                    SendData(packet.ClientAddress, $"{parts[0]} 0 {parts[2]} {parts[3]} {_settings.PublicServerInfo}");
                                    _logger.LogInformation($"Account login successful! Account: {parts[2]}");
                                }
                                break;
                            case 1: // Register Account
                                if (parts[2].Length <= 5 || parts[2].Length > 12)
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 3 Username length is wrong"));
                                }
                                else if (parts[3].Length <= 5 || parts[3].Length > 18)
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 3 Wrong password length"));
                                }
                                else if (parts[4].Length <= 1 || parts[4].Length > 18)
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 3 Question length is wrong"));
                                }
                                else if (parts[5].Length <= 1 || parts[5].Length > 18)
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 3 Answer length is wrong"));
                                }
                                else if (!Regex.IsMatch(parts[2], "^[a-zA-Z]+.*$"))
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 3 Username format error"));
                                }
                                else if (!Regex.IsMatch(parts[2], "^[a-zA-Z_][A-Za-z0-9_]*$"))
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 3 Username format error"));
                                }
                                else if (await _accountService.ExistsAccount(parts[2]))
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes($"{parts[0]} 3 Username already exists"));
                                }
                                else
                                {
                                    await _accountService.RegisterAccount(new AccountData(parts[2], parts[3], parts[4], parts[5]));
                                    SendData(packet.ClientAddress, $"{parts[0]} 2 {parts[2]} {parts[3]}");
                                }
                                break;
                            case 2: // Reset Password
                                var result = await _accountService.ResetPassword(parts[2], parts[3], parts[4], parts[5]);

                                if (result != Models.ResetPasswordResult.Success)
                                {
                                    SendData(packet.ClientAddress, $"{parts[0]} 5 {(int)result}");
                                    _logger.LogDebug($"Trying reset password with wrong info: {parts[1]}");
                                }
                                else
                                {
                                    SendData(packet.ClientAddress, $"{parts[0]} 4 {parts[2]} {parts[3]}");
                                    _logger.LogInformation($"Password Changed on Account: {parts[1]}");
                                }
                                break;
                            case 3: // Start Game (Generate Ticket)
                                if (!await _accountService.CheckLogin(parts[2], parts[3]))
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 7 wrong user name or password"));
                                }
                                else if (!_settings.Servers.TryGetValue(parts[4], out var server))
                                {
                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(parts[0] + " 7 server not found"));
                                }
                                else
                                {
                                    string text = _accountService.GenerateTicket();
                                    SendTicket(server.InternalAddress, text, parts[2]);
                                    SendData(packet.ClientAddress, $"{parts[0]} 6 {parts[2]} {parts[3]} {text}");
                                    _logger.LogInformation($"Successfully Generated Ticket! Account: {parts[2]} - {text}");
                                    _stats.TotalTickets += 1U;
                                }
                                break;
                            default:
                                _logger.LogWarning($"Undefined packet received address: {packet.ClientAddress}, Length: {packet.ReceivedData.Length}");
                                break;
                        }
                    }
                }
                catch (Exception ex2)
                {
                    _logger.LogError(ex2, "Packet processing error");
                }
            }

            _logger.LogInformation("Stopped Processing Client Requests.");
        }

        public Task<bool> Start()
        {
            bool result;
            try
            {
                LocalServer = new UdpClient(new IPEndPoint(IPAddress.Any, _settings.AccountServerPort));
                IncomingQueue = new ConcurrentQueue<PacketData>();

                StartAccountServer();
                StartLoginGate();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Critical global exception on Network");
                UdpClient udpClient = LocalServer;
                if (udpClient != null)
                {
                    udpClient.Close();
                }
                LocalServer = null;
                result = false;
            }

            return Task.FromResult(result);
        }
        public Task Stop()
        {
            LocalServer?.Close();
            LocalServer = null;

            return Task.CompletedTask;
        }

        public void SendData(IPEndPoint address, string data)
        {
            SendData(address, Encoding.UTF8.GetBytes(data));
        }

        public void SendData(IPEndPoint address, byte[] data)
        {
            _stats.TotalBytesSended += data.Length;

            if (LocalServer != null)
            {
                try
                {
                    LocalServer.Send(data, data.Length, address);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending data");
                }
            }
        }
        public void SendTicket(IPEndPoint address, string packet, string account)
        {
            _stats.TotalTickets += 1U;
            byte[] bytes = Encoding.UTF8.GetBytes(packet + ";" + account);
            if (LocalServer != null)
            {
                try
                {
                    LocalServer.Send(bytes, bytes.Length, new IPEndPoint(address.Address, _settings.LoginGatePort));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending packet");
                }
            }
        }
    }
}
