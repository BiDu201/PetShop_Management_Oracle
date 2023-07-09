using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class dataTable : Form
    {
        public dataTable()
        {
            InitializeComponent();
        }
        CSDL_Oracle oracle = new CSDL_Oracle();
        static int countcheck = 0;
        private void dataTable_Load(object sender, EventArgs e)
        {
            List<string> columnName;
            List<string> data;
            switch (oracle.getLuaChon())
            {
                case "xem profile user":
                    #region
                    columnName = oracle.getColumnName();
                    for (int i = 0; i < columnName.Count; i++)
                    {
                        dataGridView1.Columns.Add(columnName[i], columnName[i]);
                        dataGridView1.Columns[i].DataPropertyName = columnName[i];
                    }
                    data = oracle.getInforUser();
                    for (int j = 0; j < data.Count; j++)
                    {
                        dataGridView1.Rows[0].Cells[j].Value = data[j];
                    }
                    break;
                #endregion
                case "Session đang đăng nhập":
                    #region 
                    //lấy dữ liệu session
                    columnName = oracle.GetColumnsessionDN();
                    data = oracle.sessionDN();
                    //thêm tên cột vào dgv
                    for (int i = 0; i < columnName.Count; i++)
                    {
                        dataGridView1.Columns.Add(columnName[i], columnName[i]);
                    }
                    //thêm dữ liệu vào dgv
                    int count = 1, row = 0, cell = 0;
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (count == 5)
                        {
                            dataGridView1.Rows.Add();
                            cell = 0;
                            count = 1;
                            row++;
                        }
                        dataGridView1.Rows[row].Cells[cell].Value = data[i];
                        count++;
                        cell++;
                    }
                    countcheck++;
                    data.Clear();
                    break;
                #endregion
                case "dừng session":
                    #region
                    if (countcheck == 0)
                    {
                        MessageBox.Show("bạn cần phải check những session đang đăng nhập");
                        return;
                    }
                    columnName = oracle.getColumnSessionkilled();
                    for (int i = 0; i < columnName.Count; i++)
                    {
                        dataGridView1.Columns.Add(columnName[i], columnName[i]);
                        dataGridView1.Columns[i].DataPropertyName = columnName[i];
                    }
                    string[] s = oracle.getSIDSerial().Split(' ');
                    data = oracle.checkSessionKilled(s[0], s[1]);
                    count = 1; row = 0; cell = 0;
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (count == 6)
                        {
                            dataGridView1.Rows.Add();
                            cell = 0;
                            count = 1;
                            row++;
                        }
                        dataGridView1.Rows[row].Cells[cell].Value = data[i];
                        count++;
                        cell++;
                    }
                    break;
                #endregion
                case "Spfile":
                    #region
                    columnName = oracle.columnSPFile("V_$PARAMETER");
                    data = oracle.dataSPFile();
                    //thêm cột vào dgv
                    count = 0;
                    for (int i = 0; i < columnName.Count; i++)
                    {
                        dataGridView1.Columns.Add(columnName[i], columnName[i]);
                        count++;
                    }
                    //thêm data vào dgv
                    row = 0; cell = 1;
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (cell - count == 1)
                        {
                            dataGridView1.Rows.Add();
                            cell = 1;
                            row++;
                        }
                        dataGridView1.Rows[row].Cells[cell - 1].Value = data[i];
                        cell++;
                    }
                    break;
                #endregion
                case "xem session block":
                    columnName = oracle.GetColumnBlockedSession();
                    for (int i = 0; i < columnName.Count; i++)
                    {
                        dataGridView1.Columns.Add(columnName[i], columnName[i]);
                        dataGridView1.Columns[i].DataPropertyName = columnName[i];
                    }
                    data = oracle.checkSessionBlocked();
                    for (int j = 0; j < data.Count; j++)
                    {
                        dataGridView1.Rows[0].Cells[j].Value = data[j];
                    }
                    break;
                default:
                    #region
                    string tableName = "V_$" + oracle.getLuaChon().ToUpper();
                    string fromTable = "V$" + oracle.getLuaChon();
                    columnName = oracle.ColumnThongTinTuyChon(tableName);
                    data = oracle.dataThongTinTuyChon(fromTable);
                    //thêm cột vào dgv
                    count = 0;
                    for (int i = 0; i < columnName.Count; i++)
                    {
                        dataGridView1.Columns.Add(columnName[i], columnName[i]);
                        count++;
                    }
                    //thêm data vào dgv
                    row = 0; cell = 1;
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (cell - count == 1)
                        {
                            dataGridView1.Rows.Add();
                            cell = 1;
                            row++;
                        }
                        dataGridView1.Rows[row].Cells[cell - 1].Value = data[i];
                        cell++;
                    }
                    #endregion
                    break;
            }
        }
    }
}
