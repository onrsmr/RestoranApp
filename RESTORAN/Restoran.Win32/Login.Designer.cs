namespace Restoran.Win32
{
    partial class Login
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxLoginGirisYontem = new System.Windows.Forms.ComboBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoginKA = new System.Windows.Forms.TextBox();
            this.txtLoginSifre = new System.Windows.Forms.TextBox();
            this.btnGirisLogin = new System.Windows.Forms.Button();
            this.btnIptalLogin = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 233);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(354, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusLogin
            // 
            this.lblStatusLogin.Name = "lblStatusLogin";
            this.lblStatusLogin.Size = new System.Drawing.Size(16, 17);
            this.lblStatusLogin.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Giriş Yöntemi:";
            // 
            // cmbxLoginGirisYontem
            // 
            this.cmbxLoginGirisYontem.FormattingEnabled = true;
            this.cmbxLoginGirisYontem.Items.AddRange(new object[] {
            "Yönetici",
            "Garson"});
            this.cmbxLoginGirisYontem.Location = new System.Drawing.Point(86, 44);
            this.cmbxLoginGirisYontem.Name = "cmbxLoginGirisYontem";
            this.cmbxLoginGirisYontem.Size = new System.Drawing.Size(228, 21);
            this.cmbxLoginGirisYontem.TabIndex = 2;
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Şifre:";
            // 
            // txtLoginKA
            // 
            this.txtLoginKA.Location = new System.Drawing.Point(86, 74);
            this.txtLoginKA.Name = "txtLoginKA";
            this.txtLoginKA.Size = new System.Drawing.Size(228, 20);
            this.txtLoginKA.TabIndex = 3;
            // 
            // txtLoginSifre
            // 
            this.txtLoginSifre.Location = new System.Drawing.Point(86, 101);
            this.txtLoginSifre.Name = "txtLoginSifre";
            this.txtLoginSifre.Size = new System.Drawing.Size(228, 20);
            this.txtLoginSifre.TabIndex = 3;
            // 
            // btnGirisLogin
            // 
            this.btnGirisLogin.Location = new System.Drawing.Point(239, 152);
            this.btnGirisLogin.Name = "btnGirisLogin";
            this.btnGirisLogin.Size = new System.Drawing.Size(75, 23);
            this.btnGirisLogin.TabIndex = 4;
            this.btnGirisLogin.Text = "Giriş";
            this.btnGirisLogin.UseVisualStyleBackColor = true;
            this.btnGirisLogin.Click += new System.EventHandler(this.btnGirisLogin_Click);
            // 
            // btnIptalLogin
            // 
            this.btnIptalLogin.Location = new System.Drawing.Point(86, 152);
            this.btnIptalLogin.Name = "btnIptalLogin";
            this.btnIptalLogin.Size = new System.Drawing.Size(75, 23);
            this.btnIptalLogin.TabIndex = 5;
            this.btnIptalLogin.Text = "İptal";
            this.btnIptalLogin.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 255);
            this.Controls.Add(this.btnIptalLogin);
            this.Controls.Add(this.btnGirisLogin);
            this.Controls.Add(this.txtLoginSifre);
            this.Controls.Add(this.txtLoginKA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbxLoginGirisYontem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxLoginGirisYontem;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoginKA;
        private System.Windows.Forms.TextBox txtLoginSifre;
        private System.Windows.Forms.Button btnGirisLogin;
        private System.Windows.Forms.Button btnIptalLogin;
    }
}