using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace SmartWork.Common
{
    /// <summary>
    /// 与服务端交互的协议类
    /// </summary>
    public class ExecServer
    {
        public Hashtable args;
        public String header;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="header">className(FullPath) + # + methodName</param>
        /// <param name="args">参数</param>
        public ExecServer(String header, Hashtable args)
        {
            this.header = header;  
            this.args = args;
        }
    }
}
