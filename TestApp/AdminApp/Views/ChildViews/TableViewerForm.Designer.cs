namespace AdminApp.Views.ChildViews
{
	partial class TableViewerForm
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
            this.tables_cbb = new System.Windows.Forms.ComboBox();
            this.tableStructure_dtgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_dtgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableStructure_dtgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 1011);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tables_cbb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(60, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1748, 108);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table:";
            // 
            // tables_cbb
            // 
            this.tables_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tables_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tables_cbb.FormattingEnabled = true;
            this.tables_cbb.Location = new System.Drawing.Point(99, 62);
            this.tables_cbb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tables_cbb.Name = "tables_cbb";
            this.tables_cbb.Size = new System.Drawing.Size(366, 33);
            this.tables_cbb.TabIndex = 0;
            this.tables_cbb.SelectedIndexChanged += new System.EventHandler(this.tables_cbb_SelectedIndexChanged);
            // 
            // tableStructure_dtgv
            // 
            this.tableStructure_dtgv.AllowUserToAddRows = false;
            this.tableStructure_dtgv.AllowUserToDeleteRows = false;
            this.tableStructure_dtgv.BackgroundColor = System.Drawing.Color.White;
            this.tableStructure_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableStructure_dtgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tableStructure_dtgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableStructure_dtgv.Location = new System.Drawing.Point(60, 108);
            this.tableStructure_dtgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableStructure_dtgv.Name = "tableStructure_dtgv";
            this.tableStructure_dtgv.ReadOnly = true;
            this.tableStructure_dtgv.RowHeadersWidth = 62;
            this.tableStructure_dtgv.Size = new System.Drawing.Size(526, 903);
            this.tableStructure_dtgv.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column Name";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data Type";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // table_dtgv
            // 
            this.table_dtgv.AllowUserToAddRows = false;
            this.table_dtgv.AllowUserToDeleteRows = false;
            this.table_dtgv.BackgroundColor = System.Drawing.Color.White;
            this.table_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_dtgv.Location = new System.Drawing.Point(586, 108);
            this.table_dtgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.table_dtgv.Name = "table_dtgv";
            this.table_dtgv.ReadOnly = true;
            this.table_dtgv.RowHeadersWidth = 62;
            this.table_dtgv.Size = new System.Drawing.Size(1222, 903);
            this.table_dtgv.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1808, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(60, 1011);
            this.panel3.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(725, 33);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(298, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Bảng bài thi";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TableViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1868, 1011);
            this.Controls.Add(this.table_dtgv);
            this.Controls.Add(this.tableStructure_dtgv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TableViewerForm";
            this.Text = "TableViewerForm";
            this.Load += new System.EventHandler(this.TableViewerForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableStructure_dtgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_dtgv)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView tableStructure_dtgv;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox tables_cbb;
		private System.Windows.Forms.DataGridView table_dtgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
    }
}