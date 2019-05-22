using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class QuanBai
    {
        int tenBai;
        double chatBai;
        string DuongDan;// Duong dan lay link anh cho bai

        public QuanBai(int name, double value)
        {
            tenBai = name;
            chatBai = value;
        }

        public string  LayBai()
        {          
            return tenBai+","+chatBai;
        }
        public bool sosanh(QuanBai  y)
        {
            if (tenBai == y.tenBai && chatBai == y.chatBai)
                return true;
            return false;
        }
        
        
    }
}
