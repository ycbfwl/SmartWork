using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartWork.Common
{
    public class Utils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="columnName"></param>
        /// <param name="cellText"></param>
        /// <param name="type">cell、row</param>
        /// <param name="color"></param>
        public static void SetCellBackColor(System.Windows.Forms.DataGridView dataGridView, String columnName, String cellText,String type, System.Drawing.Color color)
        {
            for(int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if(dataGridView.Columns[i].Name.Equals(columnName))
                {
                    for(int j = 0; j <dataGridView.RowCount;j++)
                    {
                        if (dataGridView.Rows[j].Cells[i].Value == null) continue;
                        if(cellText.Equals(dataGridView.Rows[j].Cells[i].Value.ToString()))
                        {
                            if(type.ToUpper().Equals("ROW"))
                            {
                                dataGridView.Rows[j].DefaultCellStyle.BackColor = color;

                            }
                            else
                            {
                                dataGridView.Rows[j].Cells[i].Style.BackColor = color;

                            }
                        }
                    }
                }
            }
        }

    }
}
