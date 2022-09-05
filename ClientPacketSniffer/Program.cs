using ClientPacketSniffer;
using ClientPacketSniffer.Services;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var key = new byte[16] { 0xB2, 0x59, 0xf9, 0x6c, 0xd9, 0x9e, 0xdb, 0x4d, 0xf8, 0x91, 0x58, 0x15, 0x27, 0x3d, 0x68, 0x8e };
var input = new byte[] { 0x32, 0x30, 0x32, 0x32, 0x2d, 0x30, 0x38, 0x2d, 0x32, 0x32 };
var ojo = Convert.FromBase64String("TMB5iVAs7eMXcfCTLx7XRA==");

Console.CancelKeyPress += delegate
{
    if (PacketCapturerService.Working)
        PacketCapturerService.Stop();
    else
        Environment.Exit(1);
};

WiresharkArrayC.DynamicParse();

void SelectServiceCommand()
{
    Console.WriteLine("Select the service you want to run: ");
    Console.WriteLine(" [1] Sniffer: Capture data listening port 8701 and save into session");
    Console.WriteLine(" [2] Inspector: Select a session sniffer and explore packets received");
    Console.WriteLine(" [3] Emulator: Starts a fake server emulator");
    Console.WriteLine(" [4] Manual decode packets");
    Console.WriteLine(" [5] Decode from Array C extracted from Wireshark");

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
            case 5:
                WiresharkArrayC.DynamicParse();
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