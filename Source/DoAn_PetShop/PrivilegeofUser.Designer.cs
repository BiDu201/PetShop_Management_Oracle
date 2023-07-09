
namespace DoAn_PetShop
{
    partial class PrivilegeofUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivilegeofUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvprivsofuser = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnrevoke = new Guna.UI2.WinForms.Guna2Button();
            this.lbusn = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvroles = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLLECT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprivsofuser)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvroles)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.Black;
            this.guna2GradientPanel2.BorderRadius = 15;
            this.guna2GradientPanel2.BorderThickness = 2;
            this.guna2GradientPanel2.Controls.Add(this.btnrevoke);
            this.guna2GradientPanel2.Controls.Add(this.panel1);
            this.guna2GradientPanel2.Controls.Add(this.btnClose);
            this.guna2GradientPanel2.Controls.Add(this.panel5);
            this.guna2GradientPanel2.Controls.Add(this.label5);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(12, 12);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(592, 440);
            this.guna2GradientPanel2.TabIndex = 23;
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(563, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 20);
            this.btnClose.TabIndex = 66;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvprivsofuser);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(17, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(270, 336);
            this.panel5.TabIndex = 64;
            // 
            // dgvprivsofuser
            // 
            this.dgvprivsofuser.AllowUserToAddRows = false;
            this.dgvprivsofuser.BackgroundColor = System.Drawing.Color.White;
            this.dgvprivsofuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvprivsofuser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvprivsofuser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvprivsofuser.ColumnHeadersHeight = 30;
            this.dgvprivsofuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvprivsofuser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Select});
            this.dgvprivsofuser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvprivsofuser.EnableHeadersVisualStyles = false;
            this.dgvprivsofuser.Location = new System.Drawing.Point(0, 41);
            this.dgvprivsofuser.Name = "dgvprivsofuser";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(88)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvprivsofuser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvprivsofuser.RowHeadersVisible = false;
            this.dgvprivsofuser.RowHeadersWidth = 51;
            this.dgvprivsofuser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvprivsofuser.Size = new System.Drawing.Size(270, 295);
            this.dgvprivsofuser.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.lbusn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 41);
            this.panel3.TabIndex = 0;
            // 
            // btnrevoke
            // 
            this.btnrevoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrevoke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnrevoke.BorderRadius = 5;
            this.btnrevoke.BorderThickness = 2;
            this.btnrevoke.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnrevoke.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnrevoke.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnrevoke.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnrevoke.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(98)))), ((int)(((byte)(19)))));
            this.btnrevoke.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrevoke.ForeColor = System.Drawing.Color.Black;
            this.btnrevoke.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(167)))), ((int)(((byte)(39)))));
            this.btnrevoke.Location = new System.Drawing.Point(252, 398);
            this.btnrevoke.Name = "btnrevoke";
            this.btnrevoke.Size = new System.Drawing.Size(81, 31);
            this.btnrevoke.TabIndex = 69;
            this.btnrevoke.Text = "Revoke";
            this.btnrevoke.Click += new System.EventHandler(this.btnrevoke_Click);
            // 
            // lbusn
            // 
            this.lbusn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbusn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusn.ForeColor = System.Drawing.Color.White;
            this.lbusn.Location = new System.Drawing.Point(10, 12);
            this.lbusn.Name = "lbusn";
            this.lbusn.Size = new System.Drawing.Size(19, 19);
            this.lbusn.TabIndex = 54;
            this.lbusn.Text = "U";
            this.lbusn.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Quyền User";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.panel5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvroles);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(304, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 336);
            this.panel1.TabIndex = 67;
            // 
            // dgvroles
            // 
            this.dgvroles.AllowUserToAddRows = false;
            this.dgvroles.BackgroundColor = System.Drawing.Color.White;
            this.dgvroles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvroles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvroles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvroles.ColumnHeadersHeight = 30;
            this.dgvroles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvroles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.COLLECT});
            this.dgvroles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvroles.EnableHeadersVisualStyles = false;
            this.dgvroles.Location = new System.Drawing.Point(0, 41);
            this.dgvroles.Name = "dgvroles";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(88)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvroles.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvroles.RowHeadersVisible = false;
            this.dgvroles.RowHeadersWidth = 51;
            this.dgvroles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvroles.Size = new System.Drawing.Size(270, 295);
            this.dgvroles.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 41);
            this.panel2.TabIndex = 0;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 20;
            this.guna2Elipse3.TargetControl = this.panel1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "GRANTED_ROLE";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // COLLECT
            // 
            this.COLLECT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.COLLECT.HeaderText = "";
            this.COLLECT.Name = "COLLECT";
            this.COLLECT.Width = 5;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Width = 5;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Privilege";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // PrivilegeofUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 465);
            this.Controls.Add(this.guna2GradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrivilegeofUser";
            this.Text = "PrivilegeofUser";
            this.Load += new System.EventHandler(this.PrivilegeofUser_Load);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvprivsofuser)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvroles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvprivsofuser;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label lbusn;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        public Guna.UI2.WinForms.Guna2Button btnrevoke;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvroles;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COLLECT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
    }
}