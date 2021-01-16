using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartWork.Common
{
  public  class ExecHelper
    {
        Hashtable htArgs = new Hashtable();
        String serverHost;
        int serverPort; 

        public void addArg(String key, Object arg)
        {
            this.htArgs.Add(key, arg.ToString());
        }

        public ExecHelper()
        {
            
            serverHost = "127.0.0.1";
            String strPort = "8888";
            serverPort = String.IsNullOrWhiteSpace(strPort) ? 8888 : int.Parse(strPort);
        }

        public DataSet Select(String header)
        {
            SocketHelper soh = new SocketHelper(serverHost, serverPort);
            ExecServer dbh = new ExecServer(header, htArgs);
            string obj = JsonConvert.SerializeObject(dbh);
            String rcv = soh.Send(obj);
            DataSet ds = (DataSet)JsonConvert.DeserializeObject(rcv, typeof(DataSet));
            return ds;
        }

        public int Update(String header)
        {
            int res = 0;
            SocketHelper soh = new SocketHelper(serverHost, serverPort);
            ExecServer dbh = new ExecServer(header, htArgs);
            string obj = JsonConvert.SerializeObject(dbh);
            String rcv = soh.Send(obj);
            try
            {
                res = int.Parse(rcv);
            }
            catch
            {
                res = 0;
            }
            return res;
        }

    }
}
