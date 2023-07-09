
namespace DoAn_PetShop
{
    partial class AlterUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btndmk = new Guna.UI2.WinForms.Guna2Button();
            this.txtpassold = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbtt = new System.Windows.Forms.Label();
            this.txtpassnew = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtrepass = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbqmk = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lberror = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btndmk
            // 
            this.btndmk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndmk.BackColor = System.Drawing.SystemColors.Control;
            this.btndmk.BorderRadius = 10;
            this.btndmk.BorderThickness = 2;
            this.btndmk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndmk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndmk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndmk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndmk.Enabled = false;
            this.btndmk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(98)))), ((int)(((byte)(19)))));
            this.btndmk.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndmk.ForeColor = System.Drawing.Color.Black;
            this.btndmk.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.btndmk.Location = new System.Drawing.Point(28, 305);
            this.btndmk.Name = "btndmk";
            this.btndmk.Size = new System.Drawing.Size(371, 34);
            this.btndmk.TabIndex = 10;
            this.btndmk.Text = "Đổi mật khẩu";
            this.btndmk.Click += new System.EventHandler(this.btndmk_Click);
            // 
            // txtpassold
            // 
            this.txtpassold.BorderRadius = 5;
            this.txtpassold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpassold.DefaultText = "";
            this.txtpassold.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpassold.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpassold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpassold.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpassold.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpassold.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassold.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpassold.IconRightOffset = new System.Drawing.Point(2, 0);
            this.txtpassold.Location = new System.Drawing.Point(28, 81);
            this.txtpassold.Multiline = true;
            this.txtpassold.Name = "txtpassold";
            this.txtpassold.PasswordChar = '•';
            this.txtpassold.PlaceholderText = "Mật khẩu hiện tại";
            this.txtpassold.SelectedText = "";
            this.txtpassold.Size = new System.Drawing.Size(373, 36);
            this.txtpassold.TabIndex = 11;
            this.txtpassold.TextChanged += new System.EventHandler(this.txtrepass_TextChanged);
            // 
            // lbtt
            // 
            this.lbtt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtt.ForeColor = System.Drawing.Color.Black;
            this.lbtt.Location = new System.Drawing.Point(27, 46);
            this.lbtt.Name = "lbtt";
            this.lbtt.Size = new System.Drawing.Size(146, 20);
            this.lbtt.TabIndex = 57;
            this.lbtt.Text = "Đổi mật khẩu";
            // 
            // txtpassnew
            // 
            this.txtpassnew.BorderRadius = 5;
            this.txtpassnew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpassnew.DefaultText = "";
            this.txtpassnew.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpassnew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpassnew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpassnew.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpassnew.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpassnew.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassnew.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpassnew.IconRightOffset = new System.Drawing.Point(2, 0);
            this.txtpassnew.Location = new System.Drawing.Point(28, 144);
            this.txtpassnew.Multiline = true;
            this.txtpassnew.Name = "txtpassnew";
            this.txtpassnew.PasswordChar = '•';
            this.txtpassnew.PlaceholderText = "Mật khẩu mới";
            this.txtpassnew.SelectedText = "";
            this.txtpassnew.Size = new System.Drawing.Size(373, 36);
            this.txtpassnew.TabIndex = 58;
            this.txtpassnew.TextChanged += new System.EventHandler(this.txtrepass_TextChanged);
            // 
            // txtrepass
            // 
            this.txtrepass.BorderRadius = 5;
            this.txtrepass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtrepass.DefaultText = "";
            this.txtrepass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtrepass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtrepass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtrepass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtrepass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtrepass.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrepass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtrepass.IconRightOffset = new System.Drawing.Point(2, 0);
            this.txtrepass.Location = new System.Drawing.Point(30, 209);
            this.txtrepass.Multiline = true;
            this.txtrepass.Name = "txtrepass";
            this.txtrepass.PasswordChar = '•';
            this.txtrepass.PlaceholderText = "Nhập lại mật khẩu mới";
            this.txtrepass.SelectedText = "";
            this.txtrepass.Size = new System.Drawing.Size(371, 36);
            this.txtrepass.TabIndex = 59;
            this.txtrepass.TextChanged += new System.EventHandler(this.txtrepass_TextChanged);
            // 
            // lbqmk
            // 
            this.lbqmk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbqmk.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbqmk.ForeColor = System.Drawing.Color.Black;
            this.lbqmk.Location = new System.Drawing.Point(27, 267);
            this.lbqmk.Name = "lbqmk";
            this.lbqmk.Size = new System.Drawing.Size(170, 20);
            this.lbqmk.TabIndex = 60;
            this.lbqmk.Text = "Bạn quên mật khẩu?";
            this.lbqmk.Click += new System.EventHandler(this.lbqmk_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(37)))), ((int)(((byte)(83)))));
            this.lbUsername.Location = new System.Drawing.Point(28, 16);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(371, 18);
            this.lbUsername.TabIndex = 61;
            this.lbUsername.Text = "Username";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lberror
            // 
            this.lberror.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lberror.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(37)))), ((int)(((byte)(83)))));
            this.lberror.Location = new System.Drawing.Point(30, 241);
            this.lberror.Name = "lberror";
            this.lberror.Size = new System.Drawing.Size(371, 18);
            this.lberror.TabIndex = 62;
            this.lberror.Text = " ";
            this.lberror.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 351);
            this.Controls.Add(this.lberror);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lbqmk);
            this.Controls.Add(this.txtrepass);
            this.Controls.Add(this.txtpassnew);
            this.Controls.Add(this.lbtt);
            this.Controls.Add(this.txtpassold);
            this.Controls.Add(this.btndmk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AlterUser";
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.AlterUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btndmk;
        public Guna.UI2.WinForms.Guna2TextBox txtpassold;
        public System.Windows.Forms.Label lbtt;
        public Guna.UI2.WinForms.Guna2TextBox txtpassnew;
        public Guna.UI2.WinForms.Guna2TextBox txtrepass;
        public System.Windows.Forms.Label lbqmk;
        public System.Windows.Forms.Label lbUsername;
        public System.Windows.Forms.Label lberror;
    }
}