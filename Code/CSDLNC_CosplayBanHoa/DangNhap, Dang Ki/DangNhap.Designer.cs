namespace CSDLNC_CosplayBanHoa
{
    partial class DangNhap
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
            this.btn_dangki = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.txtBox_matkhau = new System.Windows.Forms.TextBox();
            this.txtBox_tendangnhap = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_dangki
            // 
            this.btn_dangki.BackColor = System.Drawing.Color.Crimson;
            this.btn_dangki.FlatAppearance.BorderSize = 0;
            this.btn_dangki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_dangki.ForeColor = System.Drawing.Color.White;
            this.btn_dangki.Location = new System.Drawing.Point(280, 400);
            this.btn_dangki.Name = "btn_dangki";
            this.btn_dangki.Size = new System.Drawing.Size(135, 44);
            this.btn_dangki.TabIndex = 13;
            this.btn_dangki.Text = "Đăng Kí";
            this.btn_dangki.UseVisualStyleBackColor = false;
            this.btn_dangki.Click += new System.EventHandler(this.btn_dangki_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(140, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 38);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đăng Nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 248);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 143);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên đăng nhập";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.BackColor = System.Drawing.Color.Crimson;
            this.btn_dangnhap.FlatAppearance.BorderSize = 0;
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_dangnhap.ForeColor = System.Drawing.Color.White;
            this.btn_dangnhap.Location = new System.Drawing.Point(38, 400);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(135, 44);
            this.btn_dangnhap.TabIndex = 9;
            this.btn_dangnhap.Text = "Đăng Nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // txtBox_matkhau
            // 
            this.txtBox_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBox_matkhau.Location = new System.Drawing.Point(38, 278);
            this.txtBox_matkhau.Multiline = true;
            this.txtBox_matkhau.Name = "txtBox_matkhau";
            this.txtBox_matkhau.PasswordChar = '*';
            this.txtBox_matkhau.Size = new System.Drawing.Size(377, 40);
            this.txtBox_matkhau.TabIndex = 8;
            this.txtBox_matkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_matkhau_KeyDown);
            // 
            // txtBox_tendangnhap
            // 
            this.txtBox_tendangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBox_tendangnhap.Location = new System.Drawing.Point(38, 173);
            this.txtBox_tendangnhap.Multiline = true;
            this.txtBox_tendangnhap.Name = "txtBox_tendangnhap";
            this.txtBox_tendangnhap.Size = new System.Drawing.Size(377, 40);
            this.txtBox_tendangnhap.TabIndex = 7;
            this.txtBox_tendangnhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_tendangnhap_KeyDown);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 495);
            this.Controls.Add(this.btn_dangki);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txtBox_matkhau);
            this.Controls.Add(this.txtBox_tendangnhap);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_dangki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.TextBox txtBox_matkhau;
        private System.Windows.Forms.TextBox txtBox_tendangnhap;
    }
}