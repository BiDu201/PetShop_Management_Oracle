using DoAn_PetShop.CSDL;
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
    public partial class MainForm : Form
    {
        DbConnect con = new DbConnect();
        LoginForm login = new LoginForm();
        public MainForm()
        {
            InitializeComponent();
            btnDashboard.PerformClick();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new Dashboard());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new CustomerForm());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new UserForm());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new ProductForm());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new BillingForm());

            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                this.Dispose();
                //CSDL_Login csdlLogin = new CSDL_Login();
                //csdlLogin.logOut();
                login.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new OderEntry());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }
        private Form activeForm = null;

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTTOracle_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new OracleForm());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void lbLastLogin_Click(object sender, EventArgs e)
        {
            CSDL_Login login = new CSDL_Login();
            MessageBox.Show(login.getLastLogin(), "SYSTEM");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new TableSpace());
            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CSDL_Login login = new CSDL_Login();
            if (login.getRole().Equals("SYSTEM"))
            {
                btnUser.Enabled = true;
                btnTTOracle.Enabled = true;
                guna2Button1.Enabled = true;
                btnuspro.Enabled = true;
            }
        }

        private void btnuspro_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new UserProfile());

            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void btnpolicy_Click(object sender, EventArgs e)
        {
            if (!con.checkListSessionKilled())
            {
                openChildForm(new Policy());

            }
            else
            {
                MessageBox.Show("session của bạn đã bị dừng cần chạy lại chương trình");
                this.Close();
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AlterUser u = new AlterUser();
            u.ShowDialog();
        }
    }
}
