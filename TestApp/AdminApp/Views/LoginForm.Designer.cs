namespace AdminApp.Views
{
	partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.login_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.password_txt = new AdminApp.CustomControls.CustomTextbox();
            this.username_txt = new AdminApp.CustomControls.CustomTextbox();
            this.buttonClose1 = new AdminApp.CustomControls.ButtonClose();
            this.buttonMinimized1 = new AdminApp.CustomControls.ButtonMinimized();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(56, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 238);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 340);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.Red;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.ForeColor = System.Drawing.Color.White;
            this.login_btn.Location = new System.Drawing.Point(396, 437);
            this.login_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(291, 55);
            this.login_btn.TabIndex = 5;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(450, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Exam App";
            // 
            // password_txt
            // 
            this.password_txt.BackColor = System.Drawing.Color.White;
            this.password_txt.BorderColor = System.Drawing.Color.Black;
            this.password_txt.BorderSize = 2;
            this.password_txt.FocusBorderColor = System.Drawing.Color.Black;
            this.password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_txt.Location = new System.Drawing.Point(328, 323);
            this.password_txt.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.password_txt.Name = "password_txt";
            this.password_txt.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.password_txt.PasswordChar = '*';
            this.password_txt.ReadOnly = false;
            this.password_txt.Size = new System.Drawing.Size(428, 47);
            this.password_txt.TabIndex = 8;
            this.password_txt.Texts = "";
            this.password_txt.UnderlineStyle = true;
            // 
            // username_txt
            // 
            this.username_txt.BackColor = System.Drawing.Color.White;
            this.username_txt.BorderColor = System.Drawing.Color.Black;
            this.username_txt.BorderSize = 2;
            this.username_txt.FocusBorderColor = System.Drawing.Color.Black;
            this.username_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_txt.Location = new System.Drawing.Point(328, 222);
            this.username_txt.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.username_txt.Name = "username_txt";
            this.username_txt.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.username_txt.PasswordChar = '\0';
            this.username_txt.ReadOnly = false;
            this.username_txt.Size = new System.Drawing.Size(428, 47);
            this.username_txt.TabIndex = 7;
            this.username_txt.Texts = "";
            this.username_txt.UnderlineStyle = true;
            this.username_txt._TextChanged += new System.EventHandler(this.username_txt__TextChanged);
            // 
            // buttonClose1
            // 
            this.buttonClose1.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose1.Location = new System.Drawing.Point(948, 14);
            this.buttonClose1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(38, 38);
            this.buttonClose1.TabIndex = 9;
            // 
            // buttonMinimized1
            // 
            this.buttonMinimized1.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimized1.Location = new System.Drawing.Point(902, 14);
            this.buttonMinimized1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonMinimized1.Name = "buttonMinimized1";
            this.buttonMinimized1.Size = new System.Drawing.Size(38, 38);
            this.buttonMinimized1.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 614);
            this.ControlBox = false;
            this.Controls.Add(this.buttonMinimized1);
            this.Controls.Add(this.buttonClose1);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button login_btn;
		private System.Windows.Forms.Label label4;
		private CustomControls.CustomTextbox username_txt;
		private CustomControls.CustomTextbox password_txt;
		private CustomControls.ButtonClose buttonClose1;
		private CustomControls.ButtonMinimized buttonMinimized1;
	}
}