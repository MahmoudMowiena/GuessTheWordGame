using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Client
    {
        byte[] BtArrIp;
        IPAddress LocalAddress;
        TcpClient tcpClient;
        NetworkStream NStream;
        StreamWriter Writer;
        StreamReader Reader;
        string clientID;
        public string ClientID { get { return clientID; } }
        public string UserName { get; set; }

        public event Action<Client, string> MessageReceived;

        public static Client ClientInstance;

        public Client()
        {
            this.tcpClient = new TcpClient();
            BtArrIp = new byte[] { 127, 0, 0, 1 };
            LocalAddress = new IPAddress(BtArrIp);
        }

        public Client(string id)
        {
            this.clientID = id;
        }

        public void ConnectToServer()
        {
            this.tcpClient.Connect(LocalAddress, 9000);
            NStream = this.tcpClient.GetStream();

            Reader = new StreamReader(NStream);
            ReceiveUniqueID(Reader);
            Task.Run(() => { ReceiveMsg(Reader); });

            Writer = new StreamWriter(NStream);
            Writer.AutoFlush = true;
        }

        public void SendMsg(string message)
        {
            Writer.Write(message);
        }

        private void ReceiveMsg(StreamReader Reader)
        {
            try
            {
                while (true)
                {
                    char[] buffer = new char[200];
                    int bytesRead = Reader.Read(buffer, 0, buffer.Length);
                    string message = new string(buffer, 0, bytesRead);
                    if (MessageReceived != null)
                        MessageReceived(this, message);
                }
            }
            catch
            {
                Environment.Exit(0);
            }
        }

        public void CloseConnections()
        {
            Reader.Close();
            Writer.Close();
            NStream.Close();
            tcpClient.Close();
        }

         private void ReceiveUniqueID(StreamReader Reader)
        {
            char[] buffer = new char[32];
            int bytesRead = Reader.Read(buffer, 0, buffer.Length);
            clientID = new string(buffer, 0, bytesRead);
        }
    }
}
