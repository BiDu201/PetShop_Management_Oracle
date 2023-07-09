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
    public partial class ProfileDetail : Form
    {
        CSDL_Oracle oracle = new CSDL_Oracle();
        TableSpace tb = new TableSpace();
        string title = "Dogily PetShop Management System";
        UserProfile up;
        public ProfileDetail(UserProfile form)
        {
            InitializeComponent();
            up = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ProfileDetail_Load(object sender, EventArgs e)
        {
            tb.LoadDataGridView(oracle.Profile(lbprof.Text), 4, dgvProfDetail);
        }       
    }
}
