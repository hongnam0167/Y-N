using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class SocketModel
    {
        private Socket socket;
        private byte[] byteReceive;
        private string remoteEndPoint;

        public SocketModel(Socket s)
        {
            socket = s;
            byteReceive = new byte[100];
        }
        public SocketModel(Socket s, int length)
        {
            socket = s;
            byteReceive = new byte[length];
        }
        //get the IP and port of connected client
        public string GetRemoteEndpoint()
        {
            string str = "";
            try
            {
                str = Convert.ToString(socket.RemoteEndPoint);
                remoteEndPoint = str;
            }
            catch (Exception e)
            {
                string str1 = "Error..... " + e.StackTrace;
                Console.WriteLine(str1);
                str = "Socket is closed with " + remoteEndPoint;
            }
            return str;
        }
        //receive data from client
        public string ReceiveData()
        {
            string message = "";
            //server just can receive data AFTER a connection is set up between server and client         
            try
            {
                //count the length of data received (maximum is 100 bytes)
                int k = socket.Receive(byteReceive);      
                //convert the byte recevied into string
                message = System.Text.Encoding.UTF8.GetString(byteReceive, 0, k);                            
            }
            catch (Exception e)
            {
                string str1 = "Error..... " + e.StackTrace;              
                message = "Socket is closed with " + remoteEndPoint;
            }
            return message;
        }

        //send data to client
        public void SendData(string str)
        {
            //QUESTION: why use try/catch here?
            try
            {            
                socket.Send(Encoding.UTF8.GetBytes(str));
            }
            catch (Exception e)
            {
                MessageBox.Show("Error..... " + e.StackTrace);
            }
        }
        //close sockket
        public void CloseSocket()
        {
            socket.Close();
        }
    }
}
