
namespace DoAn_PetShop
{
    partial class BillingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingForm));
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvBilling = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Increase = new System.Windows.Forms.DataGridViewImageColumn();
            this.Decrease = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTinhTien = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTransno = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnlshd = new Guna.UI2.WinForms.Guna2Button();
            this.lbRole = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvBilling);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(46, 234);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(638, 414);
            this.panel5.TabIndex = 15;
            // 
            // dgvBilling
            // 
            this.dgvBilling.AllowUserToAddRows = false;
            this.dgvBilling.BackgroundColor = System.Drawing.Color.White;
            this.dgvBilling.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBilling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBilling.ColumnHeadersHeight = 30;
            this.dgvBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBilling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column9,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Increase,
            this.Decrease,
            this.Delete});
            this.dgvBilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBilling.EnableHeadersVisualStyles = false;
            this.dgvBilling.Location = new System.Drawing.Point(0, 53);
            this.dgvBilling.Name = "dgvBilling";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(88)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBilling.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBilling.RowHeadersVisible = false;
            this.dgvBilling.Size = new System.Drawing.Size(638, 361);
            this.dgvBilling.TabIndex = 7;
            this.dgvBilling.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBilling_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 46;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Mã SP";
            this.Column3.Name = "Column3";
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Tên SP";
            this.Column9.Name = "Column9";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column6.HeaderText = "Số lượng";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column7.HeaderText = "Giá";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column8.HeaderText = "Tổng tiền";
            this.Column8.Name = "Column8";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Khách hàng";
            this.Column4.Name = "Column4";
            this.Column4.Width = 110;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Thu ngân";
            this.Column5.Name = "Column5";
            // 
            // Increase
            // 
            this.Increase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Increase.HeaderText = "";
            this.Increase.Image = ((System.Drawing.Image)(resources.GetObject("Increase.Image")));
            this.Increase.Name = "Increase";
            this.Increase.Width = 5;
            // 
            // Decrease
            // 
            this.Decrease.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Decrease.HeaderText = "";
            this.Decrease.Image = ((System.Drawing.Image)(resources.GetObject("Decrease.Image")));
            this.Decrease.Name = "Decrease";
            this.Decrease.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.btnTinhTien);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblTransno);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 53);
            this.panel2.TabIndex = 6;
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.AutoRoundedCorners = true;
            this.btnTinhTien.BorderRadius = 14;
            this.btnTinhTien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTinhTien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTinhTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTinhTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTinhTien.FillColor = System.Drawing.Color.White;
            this.btnTinhTien.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhTien.ForeColor = System.Drawing.Color.Black;
            this.btnTinhTien.Location = new System.Drawing.Point(514, 11);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(111, 31);
            this.btnTinhTien.TabIndex = 4;
            this.btnTinhTien.Text = "Khách hàng";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(408, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 19);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransno
            // 
            this.lblTransno.ForeColor = System.Drawing.Color.White;
            this.lblTransno.Location = new System.Drawing.Point(221, 16);
            this.lblTransno.Name = "lblTransno";
            this.lblTransno.Size = new System.Drawing.Size(104, 19);
            this.lblTransno.TabIndex = 3;
            this.lblTransno.Text = "000000000000";
            this.lblTransno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(96)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(331, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total price: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(96)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(119, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transaction no:";
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(96)))), ((int)(((byte)(135)))));
            this.btnAdd.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.HoverState.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(96)))), ((int)(((byte)(135)))));
            this.btnAdd.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(8, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(98, 31);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Sản phẩm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnlshd);
            this.panel4.Controls.Add(this.lbRole);
            this.panel4.Controls.Add(this.guna2CirclePictureBox1);
            this.panel4.Controls.Add(this.guna2GradientPanel1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lbUsername);
            this.panel4.Location = new System.Drawing.Point(46, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(638, 173);
            this.panel4.TabIndex = 16;
            // 
            // btnlshd
            // 
            this.btnlshd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlshd.BackColor = System.Drawing.Color.White;
            this.btnlshd.BorderRadius = 5;
            this.btnlshd.BorderThickness = 2;
            this.btnlshd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlshd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlshd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlshd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlshd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(98)))), ((int)(((byte)(19)))));
            this.btnlshd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlshd.ForeColor = System.Drawing.Color.Black;
            this.btnlshd.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(167)))), ((int)(((byte)(39)))));
            this.btnlshd.Location = new System.Drawing.Point(489, 130);
            this.btnlshd.Name = "btnlshd";
            this.btnlshd.Size = new System.Drawing.Size(136, 34);
            this.btnlshd.TabIndex = 60;
            this.btnlshd.Text = "Lịch sử hóa đơn";
            this.btnlshd.Click += new System.EventHandler(this.btnlshd_Click);
            // 
            // lbRole
            // 
            this.lbRole.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lbRole.Location = new System.Drawing.Point(490, 60);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(135, 18);
            this.lbRole.TabIndex = 14;
            this.lbRole.Text = "role";
            this.lbRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::DoAn_PetShop.Properties.Resources._53eb004e08cad43e1f568feb99ff7d1c;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(536, 11);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(45, 45);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 13;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.Black;
            this.guna2GradientPanel1.BorderRadius = 15;
            this.guna2GradientPanel1.BorderThickness = 2;
            this.guna2GradientPanel1.Controls.Add(this.pictureBox3);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(93)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(93)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(19, 14);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(154, 142);
            this.guna2GradientPanel1.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::DoAn_PetShop.Properties.Resources.bill_gif;
            this.pictureBox3.Location = new System.Drawing.Point(3, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(147, 110);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Những sản phẩm bạn cần mua đã sẵn sàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(37)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(202, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chào mừng trở lại";
            // 
            // lbUsername
            // 
            this.lbUsername.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(37)))), ((int)(((byte)(83)))));
            this.lbUsername.Location = new System.Drawing.Point(338, 45);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(97, 18);
            this.lbUsername.TabIndex = 5;
            this.lbUsername.Text = "Username";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this.panel5;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.panel4;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn3.Image")));
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            // 
            // BillingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(729, 690);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillingForm";
            this.Text = "BillingForm";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnTinhTien;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblTransno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbUsername;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label lbRole;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        public Guna.UI2.WinForms.Guna2Button btnlshd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Increase;
        private System.Windows.Forms.DataGridViewImageColumn Decrease;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}