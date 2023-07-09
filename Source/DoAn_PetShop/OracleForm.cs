using DoAn_PetShop.CSDL;
using DoAn_PetShop.Property;
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
    public partial class OracleForm : Form
    {
        string title = "Pet Shop Management System";
        CSDL_Oracle oracle = new CSDL_Oracle();
        public OracleForm()
        {
            InitializeComponent();
        }
        private void OracleForm_Load(object sender, EventArgs e)
        {
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "")
            {
                MessageBox.Show("Chưa chọn gì cả", title);
                return;
            }
            dataTable dt = new dataTable();
            oracle.setLuaChon(guna2ComboBox1.Text);
            dt.ShowDialog();
            #region
            //switch (guna2ComboBox1.Text)
            //{
            //    case "SGA":
            //        if (oracle.InforView("V_$SGA", "v$sga"))
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "PGA":
            //        if (oracle.InforView("V_$PGASTAT", "v$pgastat"))
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "Process":
            //        if (oracle.InforView("V_$PROCESS", "v$process"))
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "Control files":
            //        if (oracle.InforView("V_$CONTROLFILE", "v$controlfile"))
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "Instance":
            //        if (oracle.InforView("V_$INSTANCE", "v$instance"))
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "Database":
            //        if (oracle.Database())
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "Datafile":
            //        if (oracle.InforView("V_$DATAFILE", "v$datafile"))
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //    case "Spfile":
            //        if (oracle.spFile())
            //        {
            //            MessageBox.Show("thông tin nằm trong ổ D file excel tên Oracle\nnhớ check từng sheet");
            //        }
            //        else
            //        {
            //            MessageBox.Show("phát hiện lỗi gì chưa biết");
            //        }
            //        break;
            //}
            #endregion
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox2.Text == "")
            {
                MessageBox.Show("Chưa chọn gì cả", title);
                return;
            }
            dataTable dt = new dataTable();
            oracle.setLuaChon(guna2ComboBox2.Text);
            switch (guna2ComboBox2.Text)
            {
                case "Session đang đăng nhập":
                    dt.ShowDialog();
                back:
                    if (cb_killsession.Items.Count == 0)
                    {
                        List<string> temp = oracle.sessionDN();
                        string temp1 = string.Empty;
                        int count = 0;
                        for (int i = 0; i <= temp.Count; i++)
                        {
                            if (count == 4)
                            {
                                if (temp1 != string.Empty)
                                {
                                    cb_killsession.Items.Add(temp1);
                                    count = 0;
                                    temp1 = string.Empty;
                                }
                                else
                                {
                                    count = 0;
                                }
                            }
                            if (count == 3)
                            {
                                if (temp[i].Contains("ORACLE.EXE"))
                                {
                                    temp1 = string.Empty;
                                }
                                else
                                {
                                    temp1 += temp[i];
                                }
                            }
                            else
                            {
                                if (i != temp.Count)
                                {
                                    temp1 += temp[i] + ',';
                                }
                            }
                            count++;
                        }
                    }
                    else
                    {
                        cb_killsession.Items.Clear();
                        goto back;
                    }
                    break;
                case "dừng session":
                    string[] temp2 = cb_killsession.Text.Split(',');
                    if (!temp2[0].Equals(""))
                    {
                        oracle.setSIDSerial(temp2[0] + ' ' + temp2[1]);
                        dt.ShowDialog();
                        cb_killsession.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("vui lòng chạy kiểm tra session đang đăng nhập");
                    }
                    goto back;
                case "đếm session":
                    MessageBox.Show("tổng session: " + oracle.demSession());
                    break;
                case "dừng session block":
                    string[] temp3 = oracle.getSidSerrialBlock().Split(',');
                    oracle.setSIDSerial(temp3[0] + ' ' + temp3[1]);
                    string[] ss = oracle.getSIDSerial().Split(' ');
                    oracle.KillBlockSession(ss[0], ss[1]);
                    MessageBox.Show("session đã dừng");
                    goto back;
                case "xem session block":
                    dt.ShowDialog();
                    break;
            }
        }

        private void guna2ComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.Text == "dừng session")
            {
                guna2HtmlLabel5.Visible = true;
                cb_killsession.Visible = true;
            }
            else
            {
                guna2HtmlLabel5.Visible = false;
                cb_killsession.Visible = false;
            }
        }

        private void guna2ComboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox3.Text == "xem profile user")
            {
                guna2HtmlLabel4.Visible = true;
                guna2TextBox1.Visible = true;
            }
            else
            {
                guna2HtmlLabel4.Visible = false;
                guna2TextBox1.Visible = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("bạn chưa nhập gì cả");
                return;
            }
            else
            {
                oracle.setLuaChon(guna2ComboBox3.Text);
                oracle.setGetUserName(guna2TextBox1.Text);
                dataTable dt = new dataTable();
                dt.ShowDialog();
            }
        }
    }
}
