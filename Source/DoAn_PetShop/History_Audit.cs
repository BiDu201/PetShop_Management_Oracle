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
    public partial class History_Audit : Form
    {
        Policy po;
        CSDL_Oracle oracle = new CSDL_Oracle();
        TableSpace tb = new TableSpace();
        string title = "Dogily PetShop Management System";
        public History_Audit(Policy form)
        {
            InitializeComponent();
            po = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void History_Audit_Load(object sender, EventArgs e)
        {
            tb.LoadDataGridView(oracle.history_audit(lbname.Text), 7, dgvhistory);
        }
    }
}
