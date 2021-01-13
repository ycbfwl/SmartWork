using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Utils
    {

        
        public static DataSet getXmlInfo( String xmlPath)
        {
            DataSet myds = new DataSet();
            myds.ReadXml(xmlPath);
            return myds;
        }

    }
}
