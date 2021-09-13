using System.Text;
using System.Collections.Generic;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MW2DisconnectTool
{
    public static class sniffer
    {
        private static Regex ipRegex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
        
        const int gamePort = 28960;
        const int package_type_offset = 0x2F;
       
        // запрос списка игроков уже играющих на сервере или о подключении новых
        // получаем от игрока который является сервером
        const string party_state_event = "partystate";
        
        static Encoding gameEncoding = Encoding.ASCII;

        public static void Init()
        {
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                MessageBox.Show("Интерфейсы не найдены! Убедитесь что WinPcap установлен.", "PcapDotNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool adderessFounded = false;
            string adapterIpAddress = string.Empty;
            LivePacketDevice finded = null;
            foreach (var device in allDevices)
            {
                foreach (var adress in device.Addresses)
                {
                    MatchCollection result = ipRegex.Matches(adress.Address.ToString());
                    if (result.Count != 0)
                    {
                        adapterIpAddress = result[0].ToString();
                        finded = device;
                        adderessFounded = true;
                        break;
                    }
                }

                if(adderessFounded)
                {
                    break;
                }
            }

            if (adapterIpAddress == string.Empty)
            {
                MessageBox.Show("Не смогли получить IP адрес у адаптера.", "PcapDotNet");
                return;
            }
            else
            {
                MainForm.LocalIP = adapterIpAddress;
            }

            PacketDevice selectedDevice = finded;

            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {
                //Console.WriteLine("Listening on " + selectedDevice.Description + "...");
                using (BerkeleyPacketFilter filter = communicator.CreateFilter("udp and port 28960"))
                {
                    // Set the filter
                    communicator.SetFilter(filter);
                }
                // start the capture
                communicator.ReceivePackets(0, PacketHandler);
            }
        }

        private static void parsePackage(Packet packet, string sourceIp, string destinationIp)
        {
            bool isSourceIPLocal = sourceIp == MainForm.LocalIP;
            
            if (packet.Length > 120)
            {
                string package_type = gameEncoding.GetString(packet.Buffer, package_type_offset, party_state_event.Length);
                if (package_type == party_state_event && !isSourceIPLocal)
                {
                    MainForm.currentHostIp = sourceIp;
                }
            }
        }

        // Callback function invoked by Pcap.Net for every incoming packet
        private static void PacketHandler(Packet packet)
        {
            IpV4Datagram ip = packet.Ethernet.IpV4;

            parsePackage(packet, ip.Source.ToString(), ip.Destination.ToString());
        }
    }
}
