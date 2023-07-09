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
    public partial class AlterUser : Form
    {
        CSDL_Login login = new CSDL_Login();
        CSDL_Oracle oracle = new CSDL_Oracle();
        public AlterUser()
        {
            InitializeComponent();
        }

        private void AlterUser_Load(object sender, EventArgs e)
        {
            lbUsername.Text = login.getName().ToUpper() + " • PetShop";
            txtpassold.Focus();
        }

        private void btndmk_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn chắc chắn muốn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (oracle.alterPassUser(login.getName(), txtpassold.Text, txtpassnew.Text))
                {
                    if (MessageBox.Show("Đổi mật khẩu thành công, bạn có muốn đăng nhập lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        LoginForm login = new LoginForm();
                        this.Dispose();
                        login.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại! Bạn vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }


        private void txtrepass_TextChanged(object sender, EventArgs e)
        {
            if (txtrepass.Text != txtpassnew.Text)
            {
                lberror.Text = "Mật khẩu mới không khớp. Hãy nhập lại mật khẩu mới tại đây.";
                btndmk.Enabled = false;
            }          

            else if (txtpassold.Text == "" | txtpassnew.Text == "" | txtrepass.Text == "")
            {
                btndmk.Enabled = false;
            } 
            else
            {
                lberror.Text = "";
                btndmk.Enabled = true;
            }        
        }

        private void lbqmk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ quản lý.", "Thông báo");
        }
    }
}
