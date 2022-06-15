using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CharServerAgain
{
    class Users
    {
        public TcpClient client { get; set; }
        public string Name { get; set; }
    }
}