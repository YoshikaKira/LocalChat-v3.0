using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatModelWPF
{
    class ServerConnection
    {
        public TcpClient Client { get; private set; }
        public int Port { get; private set; }
        public string IP { get; private set; }
        public ServerConnection (string ip = "127.0.0.1", int port = 8888)
        {
            Port = port;
            IP = ip;
            Client = new TcpClient(ip, port);
        }
        public void SendMessage (string message)
        {
            message += '\n';
            NetworkStream stream = Client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }
        public string GetMessage()
        {
            NetworkStream stream = Client.GetStream();
            byte[] buffer = new byte[1000];
            stream.Read(buffer, 0, 1000);
            string message = Encoding.UTF8.GetString(buffer);
            return message;
        }
    }
}