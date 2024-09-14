
namespace WindowsFormsApp1
{
    partial class menu
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
            this.P1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Backbtn = new System.Windows.Forms.Button();
            this.P2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // P1
            // 
            this.P1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.P1.BackColor = System.Drawing.Color.Transparent;
            this.P1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.P1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.P1.FlatAppearance.BorderSize = 0;
            this.P1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.P1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.P1.Font = new System.Drawing.Font("Stencil", 50F);
            this.P1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.P1.Location = new System.Drawing.Point(795, 425);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(346, 72);
            this.P1.TabIndex = 0;
            this.P1.Text = "1 Player";
            this.P1.UseCompatibleTextRendering = true;
            this.P1.UseVisualStyleBackColor = false;
            this.P1.Click += new System.EventHandler(this.P1_click);
            this.P1.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.P1.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Stencil", 50F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(717, 292);
            this.button1.MaximumSize = new System.Drawing.Size(517, 100);
            this.button1.MinimumSize = new System.Drawing.Size(517, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(517, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "Instructions";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Instruction_Click);
            this.button1.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Stencil", 50F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(775, 647);
            this.button2.MaximumSize = new System.Drawing.Size(419, 100);
            this.button2.MinimumSize = new System.Drawing.Size(419, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(419, 100);
            this.button2.TabIndex = 2;
            this.button2.Text = "Highscore";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Highscore_Click);
            this.button2.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button2.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // Backbtn
            // 
            this.Backbtn.BackColor = System.Drawing.Color.Transparent;
            this.Backbtn.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Back_Button;
            this.Backbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Backbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Backbtn.FlatAppearance.BorderSize = 0;
            this.Backbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Backbtn.Location = new System.Drawing.Point(1693, 53);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(151, 77);
            this.Backbtn.TabIndex = 13;
            this.Backbtn.UseVisualStyleBackColor = false;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // P2
            // 
            this.P2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.P2.BackColor = System.Drawing.Color.Transparent;
            this.P2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.P2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.P2.FlatAppearance.BorderSize = 0;
            this.P2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.P2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.P2.Font = new System.Drawing.Font("Stencil", 50F);
            this.P2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.P2.Location = new System.Drawing.Point(790, 548);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(386, 72);
            this.P2.TabIndex = 14;
            this.P2.Text = "2 Players";
            this.P2.UseCompatibleTextRendering = true;
            this.P2.UseVisualStyleBackColor = false;
            this.P2.Click += new System.EventHandler(this.P2_Click);
            this.P2.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.P2.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._4ba04f101507243_5f2072732e578;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.P2);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.P1);
            this.Name = "menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button P1;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button P2;
    }
}

