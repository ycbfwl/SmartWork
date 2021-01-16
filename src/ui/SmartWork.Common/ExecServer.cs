using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SmartWork.Common
{
    public class ExecServer
    {

        public Hashtable para;
        public String Header;


        public ExecServer(String header, Hashtable hsp)
        {
            this.Header = header;
            this.para = hsp;
        }

    }
}
