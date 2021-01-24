using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartWork.Common;
using System.Data.SQLite;

namespace SmartWork.UI
{
    public partial class frmRollCall : Form
    {
        public frmRollCall()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = AccessHelper.Adapter("select * from humer", null);

            dataGridView1.DataSource = dt.Copy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dbFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db\\RollCall.db";  //请修改***为实际SQLite数据库名

            string connectString = string.Format("Data Source =\"{0}\"", dbFilePath.Replace("file:\\", ""));

            SQLiteConnection myConnect = new SQLiteConnection(connectString);



            string sqlStr = "SELECT * FROM PEOPLE ";
            DataSet ds = SQLiteHelper.ExecuteDataSet(myConnect, sqlStr, null);


            this.dataGridView1.DataSource = ds.Tables[0].Copy();
        }
    }
}
