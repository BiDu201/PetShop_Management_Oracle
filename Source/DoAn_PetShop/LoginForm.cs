using DoAn_PetShop.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class LoginForm : Form
    {
        CSDL_Login csdl_lo = new CSDL_Login();
        string title = "Dogily Petshop Management System";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnFroget_Click(object sender, EventArgs e)
        {
            //ChangePassword a = new ChangePassword();
            //a.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "sys")
            {
                if (csdl_lo.connectDBSys(txtName.Text, txtPassword.Text))
                {
                    if (csdl_lo.checkNgayHetHan(txtName.Text))
                    {
                        MessageBox.Show("Kết nối với oracle thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("thời hạn sử dụng password đã hết\ncần đổi mật khẩu user");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể kết nối", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(@"sys.txt"))
                {
                    string conn = sr.ReadLine();
                    if (conn != null)
                    {
                        if (csdl_lo.connectDB(txtName.Text, txtPassword.Text))
                        {
                            if (csdl_lo.checkNgayHetHan(txtName.Text))
                            {
                                MessageBox.Show("Kết nối với oracle thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("thời hạn sử dụng password đã hết\ncần đổi mật khẩu user");
                            }
                        }
                        else
                        {
                            MessageBox.Show("không thể kết nối", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("vì 1 số lý do bắt buộc cần đăng nhập vào user sys trước");
                        return;
                    }
                }
            }
            csdl_lo.getDefaultTableSpace();
            this.Dispose();
            MainForm form = new MainForm();
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}