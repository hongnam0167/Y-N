using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Room
    {
        List<Player> players;
        int  nguoiDangThang;// 0: Player; 1: Player 2; 2: Player 3; 3: Player 4 
        int soTienCuoc;
        int isPlaying;

        public Room()
        {

        }

        
        void chiaBai()
        {
            BoBai bobai = new BoBai();
            bobai.xaoBai();
            
            List<SocketModel> SocketList = new List<SocketModel>();
            int count = players.Count(); // Số người chơi hiện tại trong phòng
            int SoLaBai=0; // Nếu có đủ 4 người chơi thì số lá bài là 52, 3 người chơi thì số lá bài là 39, 2 người chơi thì số lá là 26
            if (count == 2)
                SoLaBai = 26;
            else if (count == 3)
                SoLaBai = 39;
            else if (count == 4)
                SoLaBai = 52;

            int indexOfPlayer;// chỉ số của List Player chạy từ 0 tới count (max(count)=4) 
            for( int i=1; i<SoLaBai; i=indexOfPlayer+i)
            {
                indexOfPlayer = 0;
                for(int k=nguoiDangThang; k<count; k++)
                {                 
                    SocketList[players[k].pos].SendData(bobai.boBai[i+indexOfPlayer].LayBai());
                    indexOfPlayer++;
                }
                nguoiDangThang = 0;
            }
        }

    }
}
