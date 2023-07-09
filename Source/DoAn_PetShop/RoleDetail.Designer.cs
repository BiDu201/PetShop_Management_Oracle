
namespace DoAn_PetShop
{
    partial class RoleDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleDetail));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvRoleDetail = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revoke = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnrevoke = new Guna.UI2.WinForms.Guna2Button();
            this.lbrole = new System.Windows.Forms.Label();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.panel5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvRoleDetail);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(17, 49);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 409);
            this.panel5.TabIndex = 64;
            // 
            // dgvRoleDetail
            // 
            this.dgvRoleDetail.AllowUserToAddRows = false;
            this.dgvRoleDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoleDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoleDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoleDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoleDetail.ColumnHeadersHeight = 30;
            this.dgvRoleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoleDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column1,
            this.Revoke});
            this.dgvRoleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoleDetail.EnableHeadersVisualStyles = false;
            this.dgvRoleDetail.Location = new System.Drawing.Point(0, 49);
            this.dgvRoleDetail.Name = "dgvRoleDetail";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(88)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoleDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoleDetail.RowHeadersVisible = false;
            this.dgvRoleDetail.RowHeadersWidth = 51;
            this.dgvRoleDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRoleDetail.Size = new System.Drawing.Size(564, 360);
            this.dgvRoleDetail.TabIndex = 6;
            this.dgvRoleDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoleDetail_CellContentClick);
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "TABLE_NAME";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "PRIVILEGE";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 93;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TYPE";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Revoke
            // 
            this.Revoke.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Revoke.HeaderText = "SELECT";
            this.Revoke.Name = "Revoke";
            this.Revoke.Width = 54;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.btnrevoke);
            this.panel3.Controls.Add(this.lbrole);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 49);
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
            this.btnrevoke.Location = new System.Drawing.Point(473, 7);
            this.btnrevoke.Name = "btnrevoke";
            this.btnrevoke.Size = new System.Drawing.Size(79, 34);
            this.btnrevoke.TabIndex = 97;
            this.btnrevoke.Text = "Thu hồi";
            this.btnrevoke.Click += new System.EventHandler(this.btnrevoke_Click);
            // 
            // lbrole
            // 
            this.lbrole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbrole.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrole.ForeColor = System.Drawing.Color.White;
            this.lbrole.Location = new System.Drawing.Point(15, 20);
            this.lbrole.Name = "lbrole";
            this.lbrole.Size = new System.Drawing.Size(18, 21);
            this.lbrole.TabIndex = 54;
            this.lbrole.Text = "R";
            this.lbrole.Visible = false;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.Black;
            this.guna2GradientPanel2.BorderRadius = 15;
            this.guna2GradientPanel2.BorderThickness = 2;
            this.guna2GradientPanel2.Controls.Add(this.btnClose);
            this.guna2GradientPanel2.Controls.Add(this.panel5);
            this.guna2GradientPanel2.Controls.Add(this.label5);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(12, 12);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(601, 478);
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
            this.btnClose.Location = new System.Drawing.Point(573, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 20);
            this.btnClose.TabIndex = 67;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Chi tiết Role";
            // 
            // RoleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 508);
            this.Controls.Add(this.guna2GradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoleDetail";
            this.Text = "RoleDetail";
            this.Load += new System.EventHandler(this.RoleDetail_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvRoleDetail;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label lbrole;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Revoke;
        public Guna.UI2.WinForms.Guna2Button btnrevoke;
    }
}