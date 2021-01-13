using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class FrmInfo
    {
       public String name { get; set; }
        public String id { get; set; }
        public String desc { get; set; }
        public String assemblyPath { get; set; }
        public String className { get; set; }


        public FrmInfo(String name, String id, String desc, String assemblyPath, String className)
        {
            this.name = name;
            this.id = id;
            this.assemblyPath = assemblyPath;
            this.desc = desc;
            this.className = className;
        }

    }
}
