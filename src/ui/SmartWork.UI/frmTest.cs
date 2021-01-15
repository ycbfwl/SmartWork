using SmartWork.Common;
using System;
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

            this.richTextBox1.Text += soh.Send("123");
        }
    }
}
