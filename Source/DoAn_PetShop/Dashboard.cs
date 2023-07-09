using DoAn_PetShop.CSDL;
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
    public partial class Dashboard : Form
    {
        CSDL_Dashboard csdl_dashboard = new CSDL_Dashboard();
        public Dashboard()
        {
            InitializeComponent();
        }



        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblDog.Text = csdl_dashboard.ExtracData("Cho").ToString();
            lblCat.Text = csdl_dashboard.ExtracData("Meo").ToString();
            //lblFish.Text = csdl_dashboard.ExtracData("").ToString();
            //lblBird.Text = csdl_dashboard.ExtracData("").ToString();
            lbUsername.Text = csdl_dashboard.getName();
            lbRole.Text = csdl_dashboard.getRole();
        }

        private void lbRole_Click(object sender, EventArgs e)
        {

        }
    }
}
