
namespace DoAn_PetShop
{
    partial class History_Audit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History_Audit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvhistory = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhistory)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
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
            this.btnClose.Location = new System.Drawing.Point(890, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 20);
            this.btnClose.TabIndex = 66;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.Black;
            this.guna2GradientPanel2.BorderRadius = 15;
            this.guna2GradientPanel2.BorderThickness = 2;
            this.guna2GradientPanel2.Controls.Add(this.panel5);
            this.guna2GradientPanel2.Controls.Add(this.btnClose);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(108)))), ((int)(((byte)(237)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(12, 12);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(921, 509);
            this.guna2GradientPanel2.TabIndex = 67;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvhistory);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(15, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(892, 459);
            this.panel5.TabIndex = 64;
            // 
            // dgvhistory
            // 
            this.dgvhistory.AllowUserToAddRows = false;
            this.dgvhistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvhistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvhistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvhistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvhistory.ColumnHeadersHeight = 30;
            this.dgvhistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvhistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column5});
            this.dgvhistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvhistory.EnableHeadersVisualStyles = false;
            this.dgvhistory.Location = new System.Drawing.Point(0, 49);
            this.dgvhistory.Name = "dgvhistory";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(88)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvhistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvhistory.RowHeadersVisible = false;
            this.dgvhistory.RowHeadersWidth = 51;
            this.dgvhistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvhistory.Size = new System.Drawing.Size(892, 410);
            this.dgvhistory.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "ACTION_NAME";
            this.Column1.Name = "Column1";
            this.Column1.Width = 124;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "DBUSERNAME";
            this.Column2.Name = "Column2";
            this.Column2.Width = 114;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "OBJECT_SCHEMA";
            this.Column3.Name = "Column3";
            this.Column3.Width = 138;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "OBJECT_NAME";
            this.Column6.Name = "Column6";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "EVENT_TIMESTAMP";
            this.Column4.Name = "Column4";
            this.Column4.Width = 141;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "SQL_TEXT";
            this.Column5.Name = "Column5";
            this.Column5.Width = 86;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lbname);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(892, 49);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "Bản ghi audit:";
            // 
            // lbname
            // 
            this.lbname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbname.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbname.ForeColor = System.Drawing.Color.White;
            this.lbname.Location = new System.Drawing.Point(130, 15);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(301, 20);
            this.lbname.TabIndex = 68;
            this.lbname.Text = "A";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.panel5;
            // 
            // History_Audit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 533);
            this.Controls.Add(this.guna2GradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "History_Audit";
            this.Text = "History_Audit";
            this.Load += new System.EventHandler(this.History_Audit_Load);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhistory)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvhistory;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbname;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}