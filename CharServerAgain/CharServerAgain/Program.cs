using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace CharServerAgain
{
    class Program
    {
        static List<Users> clients;
        static TcpListener listener;
        static void Main(string[] args)
        {
            clients = new List<Users>();
            listener = new TcpListener(IPAddress.Any, 8888);
            WaitingForClient();
        }
        static string GenerateUserList()
        {
            string users = "<USERLIST>";
            foreach(Users user in clients)
            {
                users += user.Name + "|";
            }
            return users;
        }
        static void SendUserList()
        {
            string mess = GenerateUserList();
            byte[] buffer = new byte[mess.Length];
            buffer = Encoding.UTF8.GetBytes(mess);
            foreach (Users tcpClient in clients)
            {
                SendMessage(tcpClient, buffer);
            }
        }
        static void ListenClient (object Client)
        {
            NetworkStream stream;
            Users client = (Users)Client;
            byte[] buffer;
            while (client.client.Connected)
            {
                try
                {
                    stream = client.client.GetStream();
                    StreamReader reader = new StreamReader(stream);
                    string mes = reader.ReadLine();
                    if (mes.IndexOf("<USERLIST>") == 0) continue;
                    if (mes.IndexOf("<NAME>")==0)
                    {
                        client.Name = mes.Remove(0, 6);
                        client.Name.Remove(client.Name.Length - 1);
                        SendUserList();
                    }
                    else
                    {
                    string message = client.Name + ":" + mes;             
                    buffer = new byte[message.Length];
                    buffer = Encoding.UTF8.GetBytes(message);
                    
                    foreach (Users tcpClient in clients)
                    {
                        SendMessage(tcpClient, buffer);
                    }
                    Console.WriteLine(message);
                    }
                }
                catch {
                    clients.Remove(client);
                    SendUserList();
                    break;
                };
            }
        }
        static void SendMessage(Users client, byte[] buffer)
        {
            NetworkStream stream = client.client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }

        static void WaitingForClient ()
        {
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Users user = new Users()
                {
                    client = client,
                    Name = "NO NAME"
                };
                clients.Add(user);
                Thread thread = new Thread(new ParameterizedThreadStart(ListenClient));
                thread.Start(user);
                Console.WriteLine("NEW CLIENT");
            }
        }
    }
}