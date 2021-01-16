using Newtonsoft.Json;
using SmartWork.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWork.UI
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SocketHelper soh = new SocketHelper("127.0.0.1",8888);



            Hashtable hs = new Hashtable();
            hs.Add("arg1", "love");
            String par = "SmartWork.Biz.Quartz.Sample#main";

            ExecServer dbh = new ExecServer(par, hs);




            string obj = JsonConvert.SerializeObject(dbh);
            //发送信息向服务器端
            String rcv = soh.Send(obj);

           

            this.richTextBox1.Text += rcv;
        }
    }
}
