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
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_ABC", "TEST");

           DataSet ds =  execHelper.Select("SmartWork.Biz.Sample#main");

            dataGridView1.DataSource = ds.Tables[0].Copy();

        }
    }
}
