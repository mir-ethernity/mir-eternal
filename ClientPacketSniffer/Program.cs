// See https://aka.ms/new-console-template for more information
using ClientPacketSniffer;
using ClientPacketSniffer.Repositories;
using ClientPacketSniffer.Services;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.CancelKeyPress += delegate
{
    if (PacketCapturerService.Working)
        PacketCapturerService.Stop();
    else
        Environment.Exit(1);
};

void SelectServiceCommand()
{
    Console.WriteLine("Select the service you want to run: ");
    Console.WriteLine(" [1] Sniffer: Capture data listening port 8701 and save into session");
    Console.WriteLine(" [2] Inspector: Select a session sniffer and explore packets received");
    Console.WriteLine(" [3] Emulator: Starts a fake server emulator");
    Console.WriteLine(" [4] Manual decode packets");

    Console.Write("Service: ");
    var idxStr = Console.ReadLine();
    if (int.TryParse(idxStr, out int idx))
    {
        switch (idx)
        {
            case 1:
                PacketCapturerService.Start();
                break;
            case 2:
                PacketInspectorService.DisplaySession();
                break;
            case 3:
                PacketServerEmulator.Instance.Start();
                break;
            case 4:
                ManualDecodePacketService.WaitEntry();
                break;
            default:
                Console.WriteLine("Invalid service value");
                SelectServiceCommand();
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid service value");
        SelectServiceCommand();
    }
}


SelectServiceCommand();