using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class BoBai
    {
        public List<QuanBai> boBai = new List<QuanBai>();
        

        //Khoi tao bo bai
        public BoBai()
        {
            for(int i=3;i<=15;i++)
                for(double j=0.1; j<=0.4;j=j+0.1)
                {
                    boBai.Add(new QuanBai(i, j));
                }
        }

        public void xaoBai1()
        {
            //Xóc bài 10 lần
            for (int i = 0; i <= 10000; i++)
            {
                List<QuanBai> nuaBoBai = new List<QuanBai>();

                Random rand = new Random();
                int pos = rand.Next(10, 42);
                for(int j=0;j<pos;j++)
                {
                    nuaBoBai.Add(boBai[0]);
                    boBai.RemoveAt(0);
                }
                boBai.InsertRange(boBai.Count(), nuaBoBai);
                nuaBoBai.Clear();
            }
        }
        List<QuanBai> nuaBoBai1= new List<QuanBai>();
        List<QuanBai> nuaBoBai2 = new List<QuanBai>();
        public void xaoBai()
        {
            xaoBai1();
            for (int l = 0; l < 26; l++){
                nuaBoBai1.Add(boBai[l]);
                nuaBoBai2.Add(boBai[l + 26]);
            }

            int i = 0, j = 0;
            boBai.Clear();
            for (int k = 0; k < 52; k++)
            {
                if (k % 2 == 0){
                    boBai.Add(nuaBoBai1[i]);
                    i++;
                }
                else{
                    boBai.Add(nuaBoBai2[j]);
                    j++;
                }
            }

        }

        



        public string inbai()
        {
          //  xaoBai1();
            string re = Convert.ToString(boBai.Count())+"\r\n";

            //foreach (var i in boBai)
            //    re += i.LayBai() + "\r\n";
            for (int i = 0; i < boBai.Count(); i++)
                re += boBai[i].LayBai() + "\r\n";
            re += "end \r\n\n\n"+nuaBoBai1.Count()+"\r\n";

            for (int i = 0; i < nuaBoBai1.Count(); i++)
                re += nuaBoBai1[i].LayBai() + "\r\n";
            re += "end \r\n\n\n" + nuaBoBai2.Count() + "\r\n";

            for (int i = 0; i < nuaBoBai2.Count(); i++)
                re += nuaBoBai2[i].LayBai() + "\r\n";
            re += "end \r\n\n\n" + boBai.Count() + "\r\n";
            for (int i = 0; i < boBai.Count(); i++)
                re += boBai[i].LayBai() + "\r\n";
            return re;
                

        }

        public string ktra()
        {
            // QuanBai x = boBai[0];
            //return  Convert.ToString(boBai.Contains(x));
            //List<QuanBai> y = new List<QuanBai>();
            //y.Add(new QuanBai(1, 0.1));
            //y.Add(new QuanBai(1, 0.1));
            //y.Add(new QuanBai(2, 0.2));
            // string re = "";

            for (int i = 0; i < boBai.Count(); i++)
            {
                // re+=y[i].LayBai()+"\r\n";
                //QuanBai x = y[i];
                //y.RemoveAt(i);
                //if (y.Contains(y[i]) == true)
                //    return "trung";
                //boBai.Add(x);
                int s = 0;
                for (int j = 0; j < boBai.Count(); j++)
                {
                    if (boBai[i].sosanh(boBai[j]) == true)
                        s++;
                }
                if (s == 2)
                    return "trung";
            }
            return "KHong trung";
            // return re;
        }
    }
}
