using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class TCPModel
    {
        private IPAddress ipAd_of_server;
        private int port_to_listen;
        private TcpListener tcpServer;

        public TCPModel(string ip, int p)
        {
            ipAd_of_server = IPAddress.Parse(ip);
            port_to_listen = p;
            tcpServer = new TcpListener(ipAd_of_server, port_to_listen);
        }
        //function to listen
        public void Listen()
        {
            try
            {
                tcpServer.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error..... " + e.StackTrace);
            }
        }
        //accept a new connection
        public Socket SetUpANewConnection(ref int status)
        {
            Socket socket = tcpServer.AcceptSocket();
            status = 1;
            return socket;
        }
        //shutdown server
        public void Shutdown()
        {
            //students should develop script to finish the job in progress by working sockets
            tcpServer.Stop();
        }
    }
}
