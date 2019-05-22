using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Player
    {
        string userName;
        string avatar;
        int soTienConLai;
        int role; // 0: Người xem; 1: Người chơi
        public int pos;
        int soQuanBaiConLai;
        public Player(string name)
        {
            userName = name;
            avatar = "";
            soTienConLai = 10000;
            role = 0;
            soQuanBaiConLai = 13;

        }
    }
}
