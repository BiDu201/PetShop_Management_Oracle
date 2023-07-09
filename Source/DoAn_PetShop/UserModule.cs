using DoAn_PetShop.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class UserModule : Form
    {
        CSDL_User csdl_user = new CSDL_User();
        string title = "Dogily PetShop Management System";
        UserForm userform;
        bool check = false;
        public UserModule(UserForm user)
        {
            InitializeComponent();
            userform = user;
        }

        private void UserModule_Load(object sender, EventArgs e)
        {
            //cbRole.DataSource = csdl_user.LoadCBB();
            //cbRole.DisplayMember = "tencv";
            //cbRole.ValueMember = "macv";
            //txtma.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Thêm nhân viên mới ?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    csdl_user.chuyen_file_hinh_anh();
                    if (csdl_user.addUser(txtName.Text, txtAddress.Text, txtPhone.Text, cbbcv.Text, Path.GetFileName(csdl_user.getImg())))
                    {
                        MessageBox.Show("Thêm nhân viên thành công", title);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại", title);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckField();
            if (check)
            {
                if (MessageBox.Show("Chỉnh sửa thông tin của nhân viên? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (csdl_user.updateUser(txtma.Text, txtName.Text, txtAddress.Text, txtPhone.Text, cbbcv.Text) && csdl_user.updateIMG(csdl_user.getImg(), txtma.Text))
                    {
                        MessageBox.Show("Chỉnh sửa thành công", title);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa thất bại", title);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void CheckField()
        {
            if (txtName.Text == "" | txtAddress.Text == "" | txtPhone.Text == "" || cbbcv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", title);
                return;
            }

            check = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string imgpath = "";
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*jpg|All Files (*.*)|*.*";
                dlg.Title = "chọn ảnh nhân viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgpath = dlg.FileName.ToString();
                    guna2PictureBox2.ImageLocation = imgpath;
                    csdl_user.setImg(imgpath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
