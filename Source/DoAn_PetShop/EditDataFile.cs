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
    public partial class EditDataFile : Form
    {
        CSDL_Oracle oracle = new CSDL_Oracle();
        string title = "Dogily PetShop Management System";
        public EditDataFile(DetailTBSP form)
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnresize_Click(object sender, EventArgs e)
        {
            if(txtresize.TextLength == 0 | cbbsize.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thay đổi kích thước datafile này?", "Sửa datafile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.resizeDatafile(lbpath.Text, txtresize.Text+cbbsize.Text))
                    {
                        MessageBox.Show("Sửa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }              
            }
        }
    }
}
