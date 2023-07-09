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
    public partial class DetailTBSP : Form
    {
        TableSpace tbp;
        CSDL_Oracle oracle = new CSDL_Oracle();
        string title = "Dogily PetShop Management System";
        public DetailTBSP(TableSpace form)
        {
            InitializeComponent();
            tbp = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DetailTBSP_Load(object sender, EventArgs e)
        {
            tbp.LoadDataGridView(oracle.detailtbspace(lbnametb.Text), 6, dgvTableSpaceDetail);
        }

        private void dgvTableSpaceDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditDataFile ed = new EditDataFile(this);
            string colName = dgvTableSpaceDetail.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ed.lbpath.Text = dgvTableSpaceDetail.Rows[e.RowIndex].Cells[0].Value.ToString();
                ed.ShowDialog();
                dgvTableSpaceDetail.Rows.Clear();
                tbp.LoadDataGridView(oracle.detailtbspace(lbnametb.Text), 6, dgvTableSpaceDetail);
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this datafile?", "Edit Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.deleteDatafile(lbnametb.Text, dgvTableSpaceDetail.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Delete failed", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                dgvTableSpaceDetail.Rows.Clear();
                tbp.LoadDataGridView(oracle.detailtbspace(lbnametb.Text), 6, dgvTableSpaceDetail);
            }
        }

        private void btnopenfile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            if (fol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtfilename.Text = fol.SelectedPath + "\\filename.dbf";
            }
            else
            {
                txtfilename.Text = "";
            }
        }

        private void btnsavefile_Click(object sender, EventArgs e)
        {
            if (txtfilename.TextLength == 0 | txtsize.TextLength == 0 | txtautosize.TextLength == 0 | cbbsize.Text == "" | cbbauto.Text == "")
            {
                MessageBox.Show(title, "Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thêm datafile này không ?", "Add Datafile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.addDatafile(lbnametb.Text, txtfilename.Text, txtsize.Text+cbbsize.Text, txtautosize.Text+cbbauto.Text))
                    {
                        MessageBox.Show("Thêm dữ liệu thành công", title);
                        reset_txt();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                dgvTableSpaceDetail.Rows.Clear();
                tbp.LoadDataGridView(oracle.detailtbspace(lbnametb.Text), 6, dgvTableSpaceDetail);
            }
        }

        private void txtfilename_Click(object sender, EventArgs e)
        {
            if (txtfilename.TextLength > 0)
            {
                int index = txtfilename.Text.IndexOf("filename");
                txtfilename.SelectionStart = index;
                txtfilename.SelectionLength = 8;
            }
        }

        private void reset_txt()
        {
            txtfilename.Text = "";
            txtsize.Text = "";
            txtautosize.Text = "";
            cbbsize.Text = "";
            cbbauto.Text = "";
        }
    }
}
