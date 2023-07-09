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
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }
        int starPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            starPoint += 10;
            guna2ProgressBar1.Value = starPoint;
            if (guna2ProgressBar1.Value == 100)
            {
                guna2ProgressBar1.Value = 0;
                timer1.Stop();
                LoginForm login = new LoginForm();
                this.Hide();
                login.ShowDialog();
                login.Close();
                this.Close();
            }
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
