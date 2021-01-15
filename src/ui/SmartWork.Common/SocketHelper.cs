using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SmartWork.Common
{
    public class SocketHelper
    {
        public SocketHelper(String ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }
        private static Encoding encode = Encoding.Default;
        private String ip = "127.0.0.1";
        private int port = 8888;

        /// <summary>
        /// 监听请求
        /// </summary>
        /// <param name="port"></param>
        public  void Listen()
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            listenSocket.Listen(100);
            Console.WriteLine("Listen " + port + " ...");
            while (true)
            {
                Socket acceptSocket = listenSocket.Accept();
                string receiveData = Receive(acceptSocket, 5000); //5 seconds timeout.
                Console.WriteLine("Receive：" + receiveData);
                acceptSocket.Send(encode.GetBytes("ok"));
                DestroySocket(acceptSocket); //import
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public  string Send( string data)
        {
            string result = string.Empty;
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ip, port);
            clientSocket.Send(encode.GetBytes(data));
            //Console.WriteLine("Send：" + data);
            result = Receive(clientSocket, 5000 * 2); //5*2 seconds timeout.
            //Console.WriteLine("Receive：" + result);
            DestroySocket(clientSocket);
            //Console.ReadLine();
            return result;
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private  string Receive(Socket socket, int timeout)
        {
            string result = string.Empty;
            socket.ReceiveTimeout = timeout;
            List<byte> data = new List<byte>();
            byte[] buffer = new byte[1024];
            int length = 0;
            try
            {
                while ((length = socket.Receive(buffer)) > 0)
                {
                    for (int j = 0; j < length; j++)
                    {
                        data.Add(buffer[j]);
                    }
                    if (length < buffer.Length)
                    {
                        break;
                    }
                }
            }
            catch { }
            if (data.Count > 0)
            {
                result = encode.GetString(data.ToArray(), 0, data.Count);
            }
            return result;
        }
        /// <summary>
        /// 销毁Socket对象
        /// </summary>
        /// <param name="socket"></param>
        private  void DestroySocket(Socket socket)
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            socket.Close();
        }

        //public void Main(string[] args)
        //{
        //    //运行服务器监听数据
        //    //SocketTest.Listen(8888);

        //    //发送和接收TCP数据：
        //    Send(this.ip, this.port, "TCP TEST.");
        //}

    }
}
