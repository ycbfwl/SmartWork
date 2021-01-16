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
    public partial class frmAlipayChecker : Form
    {
        public frmAlipayChecker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_DT", this.dtpMonth.Value.ToString("yyyyMMdd"));
            execHelper.addArg("ARG_OWNER", cboOwner.Text);

            DataSet ds = execHelper.Select("SmartWork.Biz.bizAlipayChecker#SELECT_DETAIL_MONTH");

            dataGridView1.DataSource = ds.Tables[0].Copy();

            showData(ds.Tables[0], 0);

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void showData(DataTable dtSource,int index)
        {
            if(dtSource.Equals(null) || dtSource.Rows.Count == 0 || index > dtSource.Rows.Count)
            {
                return;
            }
            this.textBox1.Text = dtSource.Rows[index]["EVENT_ID"].ToString();
            this.textBox2.Text = dtSource.Rows[index]["CREATE_TM"].ToString();
            this.textBox3.Text = dtSource.Rows[index]["PAY_TO"].ToString();
            this.textBox4.Text = dtSource.Rows[index]["GOODS_NAME"].ToString();
            this.textBox5.Text = dtSource.Rows[index]["COST"].ToString();
            this.textBox6.Text = dtSource.Rows[index]["IN_OUT"].ToString();
            this.textBox7.Text = dtSource.Rows[index]["PAY_STATUS"].ToString();
            this.textBox8.Text = dtSource.Rows[index]["REMARK"].ToString();
            this.textBox9.Text = dtSource.Rows[index]["OWNER"].ToString();
            this.checkBox1.Checked = dtSource.Rows[index]["ISCHECKED"].ToString().Equals("True") ? true : false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = dataGridView1.DataSource as DataTable;

            showData(dt, e.RowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveRow(dataGridView1, "up");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveRow(dataGridView1, "down");
        }

        private void moveRow(System.Windows.Forms.DataGridView dataGridView, String updown)
        {
            int rowIndex = dataGridView.CurrentRow.Index;
            
            if(updown.ToUpper().Equals("DOWN"))
            {
                if (rowIndex == (dataGridView.Rows.Count-1)) return;
                dataGridView.Rows[rowIndex + 1].Selected = true;
                dataGridView.CurrentCell = dataGridView.Rows[rowIndex + 1].Cells[dataGridView.CurrentCell.ColumnIndex];
            }
            else
            {
                if (rowIndex == 0) return;
                dataGridView.Rows[rowIndex - 1].Selected = true;
                dataGridView.CurrentCell = dataGridView.Rows[rowIndex - 1].Cells[dataGridView.CurrentCell.ColumnIndex];
            }
            dataGridView.Rows[rowIndex].Selected = false;


            showData(dataGridView.DataSource as DataTable, dataGridView.CurrentRow.Index);

        }

        private int updateChecked(String eventid,String checkStatus)
        {
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_EVENTID", eventid);
            execHelper.addArg("ARG_ISCHECKED", checkStatus);

            int res = execHelper.Update("SmartWork.Biz.bizAlipayChecker#INS_CHECKED_STATUS");

            return res;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            String eventid = textBox1.Text;
            String checkedStatus = checkBox1.Checked.ToString();
             MessageBox.Show(  this.updateChecked(eventid, checkedStatus).ToString());
        }

        private DataTable getOwners()
        {
            ExecHelper execHelper = new ExecHelper();


            DataSet ds = execHelper.Select("SmartWork.Biz.bizAlipayChecker#GET_OWNERS");


            return ds.Tables[0].Copy();
        }

        private void frmAlipayChecker_Load(object sender, EventArgs e)
        {
            DataTable dtSource = this.getOwners();
            for(int i = 0; i < dtSource.Rows.Count; i++)
            {
                cboOwner.Items.Add(dtSource.Rows[i][0].ToString());
            }

            if(dtSource.Rows.Count>0)
            {
                cboOwner.SelectedIndex = 0;
            }
            
        }
    }
}
