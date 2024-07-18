namespace AdminApp.Views.DialogViews
{
    partial class AddProfile
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.txtPasswordLifeTime = new System.Windows.Forms.TextBox();
            this.btnTao = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPasswordGraceTime = new System.Windows.Forms.TextBox();
            this.txtPasswordReuseMax = new System.Windows.Forms.TextBox();
            this.txtPasswordReuseTime = new System.Windows.Forms.TextBox();
            this.txtFailedLoginAttempts = new System.Windows.Forms.TextBox();
            this.txtPasswordLockTime = new System.Windows.Forms.TextBox();
            this.txtThuocTinh = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Create new profile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên Profile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 147);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 100);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số ngày sử dụng\r\nmật khẩu mới kể từ\r\nkhi bắt đầu thay đổi\r\nmật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 265);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 75);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thời gian gia hạn\r\ncho việc thay đổi\r\nmật khẩu";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(247, 106);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(304, 26);
            this.txtProfileName.TabIndex = 10;
            // 
            // txtPasswordLifeTime
            // 
            this.txtPasswordLifeTime.Location = new System.Drawing.Point(247, 164);
            this.txtPasswordLifeTime.Name = "txtPasswordLifeTime";
            this.txtPasswordLifeTime.Size = new System.Drawing.Size(304, 26);
            this.txtPasswordLifeTime.TabIndex = 11;
            // 
            // btnTao
            // 
            this.btnTao.Location = new System.Drawing.Point(545, 464);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(227, 51);
            this.btnTao.TabIndex = 15;
            this.btnTao.Text = "Tạo";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 60);
            this.label5.TabIndex = 16;
            this.label5.Text = "Số lần tối đa có thể\r\nsử dụng lại một mật\r\nkhẩu.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(682, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 80);
            this.label6.TabIndex = 17;
            this.label6.Text = "Thời gian tối thiểu,\r\ntính theo ngày, có\r\nthể tái sử dụng mật\r\nkhẩu cũ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(682, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 80);
            this.label7.TabIndex = 18;
            this.label7.Text = "Số lần kết nối hỏng\r\n(do nhập sai tên\r\nhay mật khẩu) tối\r\nda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(682, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 100);
            this.label8.TabIndex = 19;
            this.label8.Text = "Số ngày khóa tài\r\nkhoản của người\r\ndùng kể từ khi hết\r\nhạn sử dụng mật\r\nkhâu";
            // 
            // txtPasswordGraceTime
            // 
            this.txtPasswordGraceTime.Location = new System.Drawing.Point(247, 268);
            this.txtPasswordGraceTime.Name = "txtPasswordGraceTime";
            this.txtPasswordGraceTime.Size = new System.Drawing.Size(304, 26);
            this.txtPasswordGraceTime.TabIndex = 20;
            // 
            // txtPasswordReuseMax
            // 
            this.txtPasswordReuseMax.Location = new System.Drawing.Point(247, 373);
            this.txtPasswordReuseMax.Name = "txtPasswordReuseMax";
            this.txtPasswordReuseMax.Size = new System.Drawing.Size(304, 26);
            this.txtPasswordReuseMax.TabIndex = 21;
            // 
            // txtPasswordReuseTime
            // 
            this.txtPasswordReuseTime.Location = new System.Drawing.Point(857, 106);
            this.txtPasswordReuseTime.Name = "txtPasswordReuseTime";
            this.txtPasswordReuseTime.Size = new System.Drawing.Size(304, 26);
            this.txtPasswordReuseTime.TabIndex = 22;
            // 
            // txtFailedLoginAttempts
            // 
            this.txtFailedLoginAttempts.Location = new System.Drawing.Point(857, 221);
            this.txtFailedLoginAttempts.Name = "txtFailedLoginAttempts";
            this.txtFailedLoginAttempts.Size = new System.Drawing.Size(304, 26);
            this.txtFailedLoginAttempts.TabIndex = 23;
            // 
            // txtPasswordLockTime
            // 
            this.txtPasswordLockTime.Location = new System.Drawing.Point(857, 352);
            this.txtPasswordLockTime.Name = "txtPasswordLockTime";
            this.txtPasswordLockTime.Size = new System.Drawing.Size(304, 26);
            this.txtPasswordLockTime.TabIndex = 24;
            // 
            // txtThuocTinh
            // 
            this.txtThuocTinh.FormattingEnabled = true;
            this.txtThuocTinh.Location = new System.Drawing.Point(191, 606);
            this.txtThuocTinh.Name = "txtThuocTinh";
            this.txtThuocTinh.Size = new System.Drawing.Size(239, 28);
            this.txtThuocTinh.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(609, 572);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Chọn giá trị";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(613, 595);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(239, 26);
            this.txtGiaTri.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 595);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Nhập giá trị";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 26);
            this.button1.TabIndex = 29;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 646);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtThuocTinh);
            this.Controls.Add(this.txtPasswordLockTime);
            this.Controls.Add(this.txtFailedLoginAttempts);
            this.Controls.Add(this.txtPasswordReuseTime);
            this.Controls.Add(this.txtPasswordReuseMax);
            this.Controls.Add(this.txtPasswordGraceTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.txtPasswordLifeTime);
            this.Controls.Add(this.txtProfileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "AddProfile";
            this.Text = "AddProfile";
            this.Load += new System.EventHandler(this.AddProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.TextBox txtPasswordLifeTime;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPasswordGraceTime;
        private System.Windows.Forms.TextBox txtPasswordReuseMax;
        private System.Windows.Forms.TextBox txtPasswordReuseTime;
        private System.Windows.Forms.TextBox txtFailedLoginAttempts;
        private System.Windows.Forms.TextBox txtPasswordLockTime;
        private System.Windows.Forms.ComboBox txtThuocTinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
    }
}