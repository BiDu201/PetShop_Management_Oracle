using DoAn_PetShop.CSDL;
using DoAn_PetShop.Property;
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
    public partial class UserForm : Form
    {
        CSDL_User csdl_user = new CSDL_User();
        CSDL_Login login = new CSDL_Login();
        string title = "Dogily PetShop Management System";
        public UserForm()
        {
            InitializeComponent();
            lbUsername.Text = login.getName();
            lbRole.Text = login.getRole();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule module = new UserModule(this);
            module.btnUpdate.Visible = false;
            module.btnSave.Visible = true;
            module.ShowDialog();
            dgvUser.Rows.Clear();
            UserForm_Load(sender, e);
            //List<User> list = csdl_user.LoadUser(txtSearch.Text);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    dgvUser.Rows.Add(i, list[i].maND, list[i].tenND, list[i].diaChi, list[i].sdt.ToString(), list[i].tenCV);
            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvUser.Rows.Clear();
            List<User> list = csdl_user.LoadUser(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvUser.Rows.Add(i, list[i].maND, list[i].tenND, list[i].diaChi, list[i].sdt.ToString(), list[i].tenCV);
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = @"anhnv\" + "nv00" + (e.RowIndex + 1) + ".png";
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            guna2PictureBox1.ImageLocation = absolutePath;
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModule module = new UserModule(this);
                module.txtma.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtAddress.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.cbbcv.SelectedItem = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.btnSave.Visible = false;
                module.btnUpdate.Visible = true;
                module.btnUpdate.Enabled = true;
                module.lbtt.Text = "Sửa nhân viên";
                module.ShowDialog();
                csdl_user.delete_img(e.RowIndex);
                dgvUser.Rows.Clear();
                UserForm_Load(sender, e);
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên ?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (csdl_user.deleteUser(dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        MessageBox.Show("Xóa nhân viên thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                dgvUser.Rows.Clear();
                //List<User> list = csdl_user.LoadUser(txtSearch.Text);
                //for (int i = 0; i < list.Count; i++)
                //{
                //    dgvUser.Rows.Add(i, list[i].maND, list[i].tenND, list[i].diaChi, list[i].sdt.ToString(), list[i].tenCV);
                //}
                UserForm_Load(sender, e);
            }
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            List<User> list = csdl_user.LoadUser(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvUser.Rows.Add(i, list[i].maND, list[i].tenND, list[i].diaChi, list[i].sdt.ToString(), list[i].tenCV);
            }
            csdl_user.checkfolder();
        }
    }
}
