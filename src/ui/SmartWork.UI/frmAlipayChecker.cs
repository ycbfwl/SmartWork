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
    public partial class frmAlipayChecker : Form
    {
        DataTable dtTypes;

        public frmAlipayChecker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawSheet();
        }

        private void DrawSheet()
        {
            int rowIndex = 0 ;

            if (dataGridView1.Rows.Count>0)
            {
                 rowIndex = dataGridView1.CurrentRow.Index;
            }
            

            


            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_DT", this.dtpMonth.Value.ToString("yyyyMMdd"));
            execHelper.addArg("ARG_OWNER", cboOwner.Text);

            DataSet ds = execHelper.Select("SmartWork.Biz.bizAlipayChecker#SELECT_DETAIL_MONTH");

            dataGridView1.DataSource = ds.Tables[0].Copy();



            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //dataGridView1.Rows[0].Selected = false;
            //dataGridView1.Rows[rowIndex].Selected = true;

            dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex];

            showData(dataGridView1.DataSource as DataTable, rowIndex);
            Utils.SetCellBackColor(dataGridView1, "ISCHECKED", "True","CELL", Color.Green);
        }

        private void showData(DataTable dtSource, int index)
        {
            if (dtSource.Equals(null) || dtSource.Rows.Count == 0 || index > dtSource.Rows.Count)
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
            this.setCbo(cboType1,  dtSource.Rows[index]["TYPE1"].ToString());
            this.setCbo(cboType2, dtSource.Rows[index]["TYPE2"].ToString());

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

            if (updown.ToUpper().Equals("DOWN"))
            {
                if (rowIndex == (dataGridView.Rows.Count - 1)) return;
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

        private int updateChecked(String eventid, String checkStatus)
        {
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_EVENTID", eventid);
            execHelper.addArg("ARG_ISCHECKED", checkStatus);

            int res = execHelper.Update("SmartWork.Biz.bizAlipayChecker#INS_CHECKED_STATUS");

            return res;
        }

        private int updateCostType(String eventid, String type1,String type2)
        {
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_EVENTID", eventid);
            execHelper.addArg("ARG_TYPE1", type1);
            execHelper.addArg("ARG_TYPE2", type2);

            int res = execHelper.Update("SmartWork.Biz.bizAlipayChecker#INS_COSTTYPE");

            return res;
        }


        private int updateRemark(String eventid, String remark)
        {
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_EVENTID", eventid);
            execHelper.addArg("ARG_REMARK", remark);

            int res = execHelper.Update("SmartWork.Biz.bizAlipayChecker#INS_REMARK");

            return res;
        }

        private DataSet getInitInfos()
        {
            ExecHelper execHelper = new ExecHelper();


            DataSet ds = execHelper.Select("SmartWork.Biz.bizAlipayChecker#GET_INFS");


            return ds;
        }

        private void frmAlipayChecker_Load(object sender, EventArgs e)
        {
            DataSet dsDataSource = this.getInitInfos();

            //
            DataTable dtSource = dsDataSource.Tables[0].Copy();
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                cboOwner.Items.Add(dtSource.Rows[i][0].ToString());
            }

            if (dtSource.Rows.Count > 0)
            {
                cboOwner.SelectedIndex = 0;
            }


            ///cboType1 cboType2
            dtTypes = dsDataSource.Tables[1].Copy();
            Hashtable htType1 = new Hashtable();
            for(int i = 0; i < dtTypes.Rows.Count;i++)
            {
                String col1 = dtTypes.Rows[i]["TYPE1"].ToString();
                if (!htType1.ContainsKey(col1))
                {
                    cboType1.Items.Add(col1);
                    htType1.Add(col1, col1);
                }
            }
            htType1.Add("", "");


        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cboType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String type1 = cboType1.Text;
            cboType2.Items.Clear();
            for (int i = 0; i  < dtTypes.Rows.Count; i++)
            {
                String col1 = dtTypes.Rows[i]["TYPE1"].ToString();
                if(col1.Equals(type1))
                {
                    cboType2.Items.Add(dtTypes.Rows[i]["TYPE2"].ToString());
                }
            }
        }


        private void setCbo(System.Windows.Forms.ComboBox cbo,String val)
        {
            if(String.IsNullOrWhiteSpace(val))
            {
                cbo.SelectedIndex = -1;
            }else
            {
                cbo.Text = val;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String eventid = textBox1.Text;

            if (String.IsNullOrWhiteSpace(eventid)) return;

            String remark = textBox8.Text;

            int resRemark = updateRemark(eventid, remark);



            String type1 = cboType1.Text;
            String type2 = cboType2.Text;
           int resType =  updateCostType(eventid, type1, type2);

            String checkedStatus = checkBox1.Checked.ToString();
            int resChked = updateChecked(eventid, checkedStatus);


            MessageBox.Show("变更数量:\nRemark==>:" + resRemark + "\nCostType ==>:" + resType + "\nChked ==>:" + resChked, "变更数量");


            DrawSheet();
        }
    }
}
