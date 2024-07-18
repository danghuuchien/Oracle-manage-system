namespace AdminApp.Views.DialogViews
{
	partial class AddAuditUser
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
			this.label1 = new System.Windows.Forms.Label();
			this.username_cbb = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.table_cbb = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.inser_checkbox = new System.Windows.Forms.CheckBox();
			this.update_checkbox = new System.Windows.Forms.CheckBox();
			this.delete_checkbox = new System.Windows.Forms.CheckBox();
			this.select_checkbox = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// username_cbb
			// 
			this.username_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.username_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.username_cbb.FormattingEnabled = true;
			this.username_cbb.Location = new System.Drawing.Point(109, 50);
			this.username_cbb.Name = "username_cbb";
			this.username_cbb.Size = new System.Drawing.Size(206, 28);
			this.username_cbb.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Table";
			// 
			// table_cbb
			// 
			this.table_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.table_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.table_cbb.FormattingEnabled = true;
			this.table_cbb.Location = new System.Drawing.Point(109, 116);
			this.table_cbb.Name = "table_cbb";
			this.table_cbb.Size = new System.Drawing.Size(206, 28);
			this.table_cbb.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.select_checkbox);
			this.panel1.Controls.Add(this.delete_checkbox);
			this.panel1.Controls.Add(this.update_checkbox);
			this.panel1.Controls.Add(this.inser_checkbox);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(16, 183);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(378, 96);
			this.panel1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Action";
			// 
			// inser_checkbox
			// 
			this.inser_checkbox.AutoSize = true;
			this.inser_checkbox.Location = new System.Drawing.Point(7, 41);
			this.inser_checkbox.Name = "inser_checkbox";
			this.inser_checkbox.Size = new System.Drawing.Size(66, 17);
			this.inser_checkbox.TabIndex = 6;
			this.inser_checkbox.Text = "INSERT";
			this.inser_checkbox.UseVisualStyleBackColor = true;
			// 
			// update_checkbox
			// 
			this.update_checkbox.AutoSize = true;
			this.update_checkbox.Location = new System.Drawing.Point(93, 41);
			this.update_checkbox.Name = "update_checkbox";
			this.update_checkbox.Size = new System.Drawing.Size(70, 17);
			this.update_checkbox.TabIndex = 7;
			this.update_checkbox.Text = "UPDATE";
			this.update_checkbox.UseVisualStyleBackColor = true;
			// 
			// delete_checkbox
			// 
			this.delete_checkbox.AutoSize = true;
			this.delete_checkbox.Location = new System.Drawing.Point(191, 41);
			this.delete_checkbox.Name = "delete_checkbox";
			this.delete_checkbox.Size = new System.Drawing.Size(68, 17);
			this.delete_checkbox.TabIndex = 8;
			this.delete_checkbox.Text = "DELETE";
			this.delete_checkbox.UseVisualStyleBackColor = true;
			// 
			// select_checkbox
			// 
			this.select_checkbox.AutoSize = true;
			this.select_checkbox.Location = new System.Drawing.Point(284, 41);
			this.select_checkbox.Name = "select_checkbox";
			this.select_checkbox.Size = new System.Drawing.Size(67, 17);
			this.select_checkbox.TabIndex = 9;
			this.select_checkbox.Text = "SELECT";
			this.select_checkbox.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Red;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(167, 308);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 37);
			this.button1.TabIndex = 5;
			this.button1.Text = "Create";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// AddAuditUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 421);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.table_cbb);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.username_cbb);
			this.Controls.Add(this.label1);
			this.Name = "AddAuditUser";
			this.Text = "AddAuditUser";
			this.Load += new System.EventHandler(this.AddAuditUser_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox username_cbb;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox table_cbb;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox select_checkbox;
		private System.Windows.Forms.CheckBox delete_checkbox;
		private System.Windows.Forms.CheckBox update_checkbox;
		private System.Windows.Forms.CheckBox inser_checkbox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
	}
}