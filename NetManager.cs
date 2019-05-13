using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatroomClient
{
    public class NetManager
    {
        public static Client client;

        public static Queue<Package> toServer = new Queue<Package>();
        public static Queue<Package> toClient = new Queue<Package>();

        public static User me { get; set; }
    }
}
