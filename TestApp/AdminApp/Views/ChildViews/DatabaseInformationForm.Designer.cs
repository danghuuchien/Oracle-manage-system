namespace AdminApp.Views.ChildViews
{
	partial class DatabaseInformationForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.infor_cbb = new System.Windows.Forms.ComboBox();
			this.information_dtgv = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.information_dtgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(40, 657);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.infor_cbb);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(40, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1165, 70);
			this.panel2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Information";
			// 
			// infor_cbb
			// 
			this.infor_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.infor_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infor_cbb.FormattingEnabled = true;
			this.infor_cbb.Items.AddRange(new object[] {
            "SGA",
            "PGA",
            "PROCESS",
            "INSTANCE",
            "DATABASE",
            "DATAFILE",
            "CONTROL FILE",
            "SPFILE"});
			this.infor_cbb.Location = new System.Drawing.Point(101, 40);
			this.infor_cbb.Name = "infor_cbb";
			this.infor_cbb.Size = new System.Drawing.Size(245, 24);
			this.infor_cbb.TabIndex = 0;
			this.infor_cbb.SelectedIndexChanged += new System.EventHandler(this.infor_cbb_SelectedIndexChanged);
			// 
			// information_dtgv
			// 
			this.information_dtgv.AllowUserToAddRows = false;
			this.information_dtgv.AllowUserToDeleteRows = false;
			this.information_dtgv.BackgroundColor = System.Drawing.Color.White;
			this.information_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.information_dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.information_dtgv.Location = new System.Drawing.Point(40, 70);
			this.information_dtgv.Name = "information_dtgv";
			this.information_dtgv.ReadOnly = true;
			this.information_dtgv.Size = new System.Drawing.Size(1165, 587);
			this.information_dtgv.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(1205, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(40, 657);
			this.panel3.TabIndex = 5;
			// 
			// DatabaseInformationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1245, 657);
			this.Controls.Add(this.information_dtgv);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Name = "DatabaseInformationForm";
			this.Text = "DatabaseInformationForm";
			this.Load += new System.EventHandler(this.DatabaseInformationForm_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.information_dtgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox infor_cbb;
		private System.Windows.Forms.DataGridView information_dtgv;
		private System.Windows.Forms.Panel panel3;
	}
}