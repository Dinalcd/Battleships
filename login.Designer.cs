
namespace WindowsFormsApp1
{
    partial class login
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.password = new System.Windows.Forms.TextBox();
            this.PassW = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.Log_in = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Battleships = new System.Windows.Forms.Label();
            this.userNm = new System.Windows.Forms.TextBox();
            this.Exitbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.password.Location = new System.Drawing.Point(987, 482);
            this.password.MaximumSize = new System.Drawing.Size(200, 46);
            this.password.MinimumSize = new System.Drawing.Size(200, 46);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.password.Size = new System.Drawing.Size(200, 53);
            this.password.TabIndex = 5;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PassW
            // 
            this.PassW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PassW.BackColor = System.Drawing.Color.White;
            this.PassW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassW.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PassW.Enabled = false;
            this.PassW.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.PassW.Location = new System.Drawing.Point(747, 482);
            this.PassW.MaximumSize = new System.Drawing.Size(200, 46);
            this.PassW.MinimumSize = new System.Drawing.Size(200, 46);
            this.PassW.Name = "PassW";
            this.PassW.ReadOnly = true;
            this.PassW.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PassW.Size = new System.Drawing.Size(200, 46);
            this.PassW.TabIndex = 6;
            this.PassW.Text = "Password";
            this.PassW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userName
            // 
            this.userName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.userName.Location = new System.Drawing.Point(987, 365);
            this.userName.MaximumSize = new System.Drawing.Size(200, 46);
            this.userName.MinimumSize = new System.Drawing.Size(200, 46);
            this.userName.Name = "userName";
            this.userName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userName.Size = new System.Drawing.Size(200, 53);
            this.userName.TabIndex = 1;
            this.userName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Log_in
            // 
            this.Log_in.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Log_in.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Log_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Log_in.Location = new System.Drawing.Point(864, 576);
            this.Log_in.MaximumSize = new System.Drawing.Size(200, 46);
            this.Log_in.MinimumSize = new System.Drawing.Size(200, 46);
            this.Log_in.Name = "Log_in";
            this.Log_in.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Log_in.Size = new System.Drawing.Size(200, 46);
            this.Log_in.TabIndex = 8;
            this.Log_in.Text = "Log in";
            this.Log_in.UseVisualStyleBackColor = true;
            this.Log_in.Click += new System.EventHandler(this.Login_Click);
            // 
            // Register
            // 
            this.Register.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Register.Location = new System.Drawing.Point(864, 652);
            this.Register.MaximumSize = new System.Drawing.Size(200, 46);
            this.Register.MinimumSize = new System.Drawing.Size(200, 46);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(200, 46);
            this.Register.TabIndex = 9;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Battleships
            // 
            this.Battleships.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Battleships.AutoSize = true;
            this.Battleships.BackColor = System.Drawing.Color.Transparent;
            this.Battleships.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Battleships.Font = new System.Drawing.Font("Stencil", 50F);
            this.Battleships.ForeColor = System.Drawing.Color.White;
            this.Battleships.Location = new System.Drawing.Point(733, 209);
            this.Battleships.MaximumSize = new System.Drawing.Size(472, 80);
            this.Battleships.MinimumSize = new System.Drawing.Size(472, 80);
            this.Battleships.Name = "Battleships";
            this.Battleships.Size = new System.Drawing.Size(472, 80);
            this.Battleships.TabIndex = 11;
            this.Battleships.Text = "Battleships";
            // 
            // userNm
            // 
            this.userNm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userNm.BackColor = System.Drawing.Color.White;
            this.userNm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userNm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.userNm.Enabled = false;
            this.userNm.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.userNm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.userNm.Location = new System.Drawing.Point(747, 365);
            this.userNm.Name = "userNm";
            this.userNm.ReadOnly = true;
            this.userNm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userNm.Size = new System.Drawing.Size(200, 46);
            this.userNm.TabIndex = 0;
            this.userNm.Text = "Username";
            this.userNm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userNm.WordWrap = false;
            this.userNm.TextChanged += new System.EventHandler(this.userNm_TextChanged);
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.Transparent;
            this.Exitbtn.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Exit_button;
            this.Exitbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exitbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exitbtn.FlatAppearance.BorderSize = 0;
            this.Exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbtn.Location = new System.Drawing.Point(1695, 60);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(157, 65);
            this.Exitbtn.TabIndex = 12;
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._4ba04f101507243_5f2072732e578;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Battleships);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Log_in);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.PassW);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userNm);
            this.Name = "login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox PassW;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button Log_in;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label Battleships;
        private System.Windows.Forms.TextBox userNm;
        private System.Windows.Forms.Button Exitbtn;
    }
}