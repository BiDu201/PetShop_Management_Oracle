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
    public partial class RoleDetail : Form
    {
        UserProfile us;
        CSDL_Oracle oracle = new CSDL_Oracle();
        TableSpace tb = new TableSpace();
        string title = "Dogily PetShop Management System";
        public RoleDetail(UserProfile form)
        {
            InitializeComponent();
            us = form;
        }

        private int revoke_privs_role()
        {
            int count = 0;           
            foreach (DataGridViewRow dr in dgvRoleDetail.Rows)
            {                             
                string dr0 = dr.Cells[0].Value.ToString();
                string dr1 = dr.Cells[1].Value.ToString();
                bool chkbox = Convert.ToBoolean(dr.Cells["Revoke"].Value);
                if (chkbox)
                {
                    if(oracle.revoke_privs_role(dr1,dr0,lbrole.Text))
                    {
                        count++;
                    }
                    else
                    {
                       MessageBox.Show("Lỗi! Không thể revoke lệnh " + dr1 + " trên table " + dr0);
                       //error = error + "Lỗi! Không thể revoke lệnh " + dr1 + " trên table " + dr0 + "\n";
                        continue;
                    }
                }
            }
            return count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RoleDetail_Load(object sender, EventArgs e)
        {
            tb.LoadDataGridView(oracle.privs_Role(lbrole.Text), 4, dgvRoleDetail);
        }

        private void btnrevoke_Click(object sender, EventArgs e)
        {
            if(revoke_privs_role() == 0)
            {
                MessageBox.Show("Vui lòng chọn quyền cần xóa!", title, MessageBoxButtons.OK, MessageBoxIcon.Question);             
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thu hồi role?", "Revoke Role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Revoke thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            dgvRoleDetail.Rows.Clear();
            tb.LoadDataGridView(oracle.privs_Role(lbrole.Text), 4, dgvRoleDetail);
        }

        private void dgvRoleDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
