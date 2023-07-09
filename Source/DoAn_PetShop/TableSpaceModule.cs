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
    public partial class TableSpaceModule : Form
    {
        string title = "Dogily PetShop Management System";
        TableSpace tb;
        CSDL_Oracle oracle = new CSDL_Oracle();
        public TableSpaceModule(TableSpace form)
        {
            InitializeComponent();
            tb = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtnametb.TextLength == 0 | txtpathdt.TextLength == 0 | txtsizedt.TextLength == 0 | txtautoextend.TextLength == 0 | txtsldtf.TextLength == 0 | txtnamedata.TextLength == 0 | cbbsize.Text == "" | cbbauto.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",title);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thêm Tablespace này không ?", "Thêm tablespace", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.addTablespace(txtsldtf.Text, txtnametb.Text, txtpathdt.Text + txtnamedata.Text, txtsizedt.Text + cbbsize.Text, txtautoextend.Text + cbbauto.Text))
                    {
                        MessageBox.Show("Thêm dữ liệu thành công", title);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            if (fol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //txtnamedt.Text = fol.SelectedPath + "\\filename.dbf";
                txtpathdt.Text = fol.SelectedPath + "\\";
            }
            else
            {
                txtpathdt.Text = "";
            }
        }

        //private void txtnamedt_Click(object sender, EventArgs e)
        //{
        //    if (txtpathdt.TextLength > 0)
        //    {
        //        int index = txtpathdt.Text.IndexOf("filename");
        //        txtpathdt.SelectionStart = index;
        //        txtpathdt.SelectionLength = 8;
        //    }
        //}
    }
}
