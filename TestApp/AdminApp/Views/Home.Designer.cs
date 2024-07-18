namespace AdminApp.Views
{
	partial class Home
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.policyComplianceTracker_btn = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tablespaceManagement_btn = new System.Windows.Forms.Button();
            this.sessionManagement_btn = new System.Windows.Forms.Button();
            this.databaseInformation_btn = new System.Windows.Forms.Button();
            this.tableViewer_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lastLogin_lbl = new System.Windows.Forms.Label();
            this.username_lbl = new System.Windows.Forms.Label();
            this.labelLogo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.butonhienanh = new System.Windows.Forms.Button();
            this.buttonMinimized1 = new AdminApp.CustomControls.ButtonMinimized();
            this.buttonClose1 = new AdminApp.CustomControls.ButtonClose();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.butonhienanh);
            this.panelMenu.Controls.Add(this.btnProfile);
            this.panelMenu.Controls.Add(this.policyComplianceTracker_btn);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.tablespaceManagement_btn);
            this.panelMenu.Controls.Add(this.sessionManagement_btn);
            this.panelMenu.Controls.Add(this.databaseInformation_btn);
            this.panelMenu.Controls.Add(this.tableViewer_btn);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(384, 1050);
            this.panelMenu.TabIndex = 1;
            // 
            // btnProfile
            // 
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(0, 721);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(384, 92);
            this.btnProfile.TabIndex = 9;
            this.btnProfile.Text = "Show and Create Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.button1_Click);
            this.btnProfile.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // policyComplianceTracker_btn
            // 
            this.policyComplianceTracker_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.policyComplianceTracker_btn.FlatAppearance.BorderSize = 0;
            this.policyComplianceTracker_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.policyComplianceTracker_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.policyComplianceTracker_btn.ForeColor = System.Drawing.Color.White;
            this.policyComplianceTracker_btn.Location = new System.Drawing.Point(0, 629);
            this.policyComplianceTracker_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.policyComplianceTracker_btn.Name = "policyComplianceTracker_btn";
            this.policyComplianceTracker_btn.Size = new System.Drawing.Size(384, 92);
            this.policyComplianceTracker_btn.TabIndex = 8;
            this.policyComplianceTracker_btn.Text = "Policy Compliance Tracker";
            this.policyComplianceTracker_btn.UseVisualStyleBackColor = true;
            this.policyComplianceTracker_btn.Click += new System.EventHandler(this.policyComplianceTracker_btn_Click);
            this.policyComplianceTracker_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::AdminApp.Properties.Resources.logout__2_;
            this.btnLogout.Location = new System.Drawing.Point(0, 958);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(384, 92);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tablespaceManagement_btn
            // 
            this.tablespaceManagement_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablespaceManagement_btn.FlatAppearance.BorderSize = 0;
            this.tablespaceManagement_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tablespaceManagement_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablespaceManagement_btn.ForeColor = System.Drawing.Color.White;
            this.tablespaceManagement_btn.Location = new System.Drawing.Point(0, 537);
            this.tablespaceManagement_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tablespaceManagement_btn.Name = "tablespaceManagement_btn";
            this.tablespaceManagement_btn.Size = new System.Drawing.Size(384, 92);
            this.tablespaceManagement_btn.TabIndex = 7;
            this.tablespaceManagement_btn.Text = "Tablespace Management";
            this.tablespaceManagement_btn.UseVisualStyleBackColor = true;
            this.tablespaceManagement_btn.Click += new System.EventHandler(this.tablespaceManagement_btn_Click);
            this.tablespaceManagement_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // sessionManagement_btn
            // 
            this.sessionManagement_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.sessionManagement_btn.FlatAppearance.BorderSize = 0;
            this.sessionManagement_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sessionManagement_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionManagement_btn.ForeColor = System.Drawing.Color.White;
            this.sessionManagement_btn.Location = new System.Drawing.Point(0, 445);
            this.sessionManagement_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sessionManagement_btn.Name = "sessionManagement_btn";
            this.sessionManagement_btn.Size = new System.Drawing.Size(384, 92);
            this.sessionManagement_btn.TabIndex = 3;
            this.sessionManagement_btn.Text = "Session Management";
            this.sessionManagement_btn.UseVisualStyleBackColor = true;
            this.sessionManagement_btn.Click += new System.EventHandler(this.sessionManagement_btn_Click);
            this.sessionManagement_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // databaseInformation_btn
            // 
            this.databaseInformation_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.databaseInformation_btn.FlatAppearance.BorderSize = 0;
            this.databaseInformation_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.databaseInformation_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseInformation_btn.ForeColor = System.Drawing.Color.White;
            this.databaseInformation_btn.Location = new System.Drawing.Point(0, 353);
            this.databaseInformation_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.databaseInformation_btn.Name = "databaseInformation_btn";
            this.databaseInformation_btn.Size = new System.Drawing.Size(384, 92);
            this.databaseInformation_btn.TabIndex = 2;
            this.databaseInformation_btn.Text = "Database Information";
            this.databaseInformation_btn.UseVisualStyleBackColor = true;
            this.databaseInformation_btn.Click += new System.EventHandler(this.databaseInformation_btn_Click);
            this.databaseInformation_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // tableViewer_btn
            // 
            this.tableViewer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.tableViewer_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableViewer_btn.FlatAppearance.BorderSize = 0;
            this.tableViewer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tableViewer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableViewer_btn.ForeColor = System.Drawing.Color.White;
            this.tableViewer_btn.Location = new System.Drawing.Point(0, 261);
            this.tableViewer_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableViewer_btn.Name = "tableViewer_btn";
            this.tableViewer_btn.Size = new System.Drawing.Size(384, 92);
            this.tableViewer_btn.TabIndex = 1;
            this.tableViewer_btn.Text = "Table Viewer";
            this.tableViewer_btn.UseVisualStyleBackColor = false;
            this.tableViewer_btn.Click += new System.EventHandler(this.tableViewer_btn_Click);
            this.tableViewer_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 203);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 58);
            this.panel1.TabIndex = 5;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.lastLogin_lbl);
            this.panelLogo.Controls.Add(this.username_lbl);
            this.panelLogo.Controls.Add(this.labelLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(384, 203);
            this.panelLogo.TabIndex = 0;
            // 
            // lastLogin_lbl
            // 
            this.lastLogin_lbl.AutoSize = true;
            this.lastLogin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogin_lbl.ForeColor = System.Drawing.Color.White;
            this.lastLogin_lbl.Location = new System.Drawing.Point(18, 172);
            this.lastLogin_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastLogin_lbl.Name = "lastLogin_lbl";
            this.lastLogin_lbl.Size = new System.Drawing.Size(104, 25);
            this.lastLogin_lbl.TabIndex = 2;
            this.lastLogin_lbl.Text = "last_login";
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_lbl.ForeColor = System.Drawing.Color.White;
            this.username_lbl.Location = new System.Drawing.Point(18, 131);
            this.username_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(107, 25);
            this.username_lbl.TabIndex = 1;
            this.username_lbl.Text = "username";
            this.username_lbl.Click += new System.EventHandler(this.username_lbl_Click);
            // 
            // labelLogo
            // 
            this.labelLogo.AccessibleDescription = "";
            this.labelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.labelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLogo.Image = global::AdminApp.Properties.Resources.test__1_;
            this.labelLogo.Location = new System.Drawing.Point(0, 0);
            this.labelLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(384, 131);
            this.labelLogo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.buttonMinimized1);
            this.panel2.Controls.Add(this.buttonClose1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(384, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1540, 38);
            this.panel2.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(736, 8);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Table Viewer";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(384, 38);
            this.panelDesktopPane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1540, 1012);
            this.panelDesktopPane.TabIndex = 3;
            this.panelDesktopPane.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktopPane_Paint);
            // 
            // butonhienanh
            // 
            this.butonhienanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.butonhienanh.FlatAppearance.BorderSize = 0;
            this.butonhienanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonhienanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonhienanh.ForeColor = System.Drawing.Color.White;
            this.butonhienanh.Location = new System.Drawing.Point(0, 813);
            this.butonhienanh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butonhienanh.Name = "butonhienanh";
            this.butonhienanh.Size = new System.Drawing.Size(384, 92);
            this.butonhienanh.TabIndex = 10;
            this.butonhienanh.Text = "Show data with Image";
            this.butonhienanh.UseVisualStyleBackColor = true;
            this.butonhienanh.Click += new System.EventHandler(this.butonhienanh_Click);
            this.butonhienanh.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDisablePaint);
            // 
            // buttonMinimized1
            // 
            this.buttonMinimized1.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimized1.Location = new System.Drawing.Point(1581, 0);
            this.buttonMinimized1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonMinimized1.Name = "buttonMinimized1";
            this.buttonMinimized1.Size = new System.Drawing.Size(38, 38);
            this.buttonMinimized1.TabIndex = 1;
            // 
            // buttonClose1
            // 
            this.buttonClose1.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose1.Location = new System.Drawing.Point(1628, 0);
            this.buttonClose1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(38, 38);
            this.buttonClose1.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.ControlBox = false;
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(2066, 1201);
            this.MinimumSize = new System.Drawing.Size(1310, 753);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelMenu;
		private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.Button tablespaceManagement_btn;
		private System.Windows.Forms.Button sessionManagement_btn;
		private System.Windows.Forms.Button databaseInformation_btn;
		private System.Windows.Forms.Button tableViewer_btn;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panelLogo;
		private System.Windows.Forms.Label labelLogo;
		private System.Windows.Forms.Panel panel2;
		private CustomControls.ButtonMinimized buttonMinimized1;
		private CustomControls.ButtonClose buttonClose1;
		private System.Windows.Forms.Panel panelDesktopPane;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label username_lbl;
		private System.Windows.Forms.Label lastLogin_lbl;
		private System.Windows.Forms.Button policyComplianceTracker_btn;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button butonhienanh;
    }
}