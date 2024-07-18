namespace AdminApp.Views.ChildViews
{
	partial class PolicyComplianceTrackerForm
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
			this.panel4 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.user_cbb = new System.Windows.Forms.ComboBox();
			this.table_cbb = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.table_cbb);
			this.panel4.Controls.Add(this.user_cbb);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1086, 70);
			this.panel4.TabIndex = 9;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Red;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(884, 37);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(199, 27);
			this.button1.TabIndex = 3;
			this.button1.Text = "Audit user";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(404, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Audit";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(46, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Policy";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 70);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(40, 387);
			this.panel1.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(40, 387);
			this.panel2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(1046, 70);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(40, 387);
			this.panel3.TabIndex = 8;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView2.Location = new System.Drawing.Point(0, 70);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.Size = new System.Drawing.Size(1086, 387);
			this.dataGridView2.TabIndex = 11;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGridView1.Location = new System.Drawing.Point(40, 70);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(358, 387);
			this.dataGridView1.TabIndex = 10;
			// 
			// user_cbb
			// 
			this.user_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.user_cbb.FormattingEnabled = true;
			this.user_cbb.Location = new System.Drawing.Point(544, 41);
			this.user_cbb.Name = "user_cbb";
			this.user_cbb.Size = new System.Drawing.Size(121, 21);
			this.user_cbb.TabIndex = 5;
			this.user_cbb.SelectedIndexChanged += new System.EventHandler(this.user_cbb_SelectedIndexChanged);
			// 
			// table_cbb
			// 
			this.table_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.table_cbb.FormattingEnabled = true;
			this.table_cbb.Location = new System.Drawing.Point(726, 41);
			this.table_cbb.Name = "table_cbb";
			this.table_cbb.Size = new System.Drawing.Size(129, 21);
			this.table_cbb.TabIndex = 6;
			this.table_cbb.SelectedIndexChanged += new System.EventHandler(this.user_cbb_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(496, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "User";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(671, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Table";
			// 
			// PolicyComplianceTrackerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1086, 457);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.panel4);
			this.Name = "PolicyComplianceTrackerForm";
			this.Text = "PolicyComplianceTrackerForm";
			this.Load += new System.EventHandler(this.PolicyComplianceTrackerForm_Load);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox table_cbb;
		private System.Windows.Forms.ComboBox user_cbb;
	}
}