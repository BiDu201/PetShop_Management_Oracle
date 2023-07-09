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
    public partial class PrivilegeofUser : Form
    {
        UserProfile us;
        TableSpace tb = new TableSpace();
        CSDL_Oracle oracle = new CSDL_Oracle();
        string title = "Dogily PetShop Management System";
        public PrivilegeofUser(UserProfile form)
        {
            InitializeComponent();
            us = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PrivilegeofUser_Load(object sender, EventArgs e)
        {
            tb.LoadDataGridView(oracle.Load_cbb(oracle.pri_user(lbusn.Text)), 2, dgvprivsofuser);
            tb.LoadDataGridView(oracle.Load_cbb(oracle.role_user(lbusn.Text)), 2, dgvroles);
        }

        private void btnrevoke_Click(object sender, EventArgs e)
        {
            int count_true = 0; //dem xem co bao nhieu checkbox duoc check
            string error = "";

            // Duyệt datagridview privilege
            foreach (DataGridViewRow dr in dgvprivsofuser.Rows)
            {
                bool chkbox = Convert.ToBoolean(dr.Cells["Select"].Value);

                if (chkbox)
                {
                    string pri = dr.Cells[0].Value.ToString();
                    if (oracle.revoke(lbusn.Text, pri))
                    {
                        count_true++;// +1 giá trị khi revoke thành công
                    }
                    else
                    {
                        error = error + pri + " | "; //chuỗi những quyền, role lỗi
                        continue;
                    }
                }
            }

            // Duyệt datagridview role
            foreach (DataGridViewRow dr in dgvroles.Rows)
            {
                bool chkbox = Convert.ToBoolean(dr.Cells["COLLECT"].Value);
                if (chkbox)
                {
                    string pri = dr.Cells[0].Value.ToString();
                    if (oracle.revoke(lbusn.Text, pri))
                    {
                        count_true++;// +1 giá trị khi revoke thành công
                    }
                    else
                    {
                        error = error + pri + "|"; //chuỗi những quyền, role lỗi
                        continue;
                    }
                }
            }

            if (count_true == 0) //nếu không có checkbox nào được check
            {
                MessageBox.Show("Bạn vui lòng chọn quyền hoặc role cần thu hồi", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thu hồi quyền?", "Revoke Privs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (error == "") // nếu không có lỗi
                    {
                        MessageBox.Show("Tất cả quyền lựa chọn đã được thu hồi.", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Thu hồi quyền | role " + error.TrimEnd('|') + " thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvprivsofuser.Rows.Clear();
            dgvroles.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.pri_user(lbusn.Text)), 2, dgvprivsofuser);
            tb.LoadDataGridView(oracle.Load_cbb(oracle.role_user(lbusn.Text)), 2, dgvroles);
        }
    }
}
