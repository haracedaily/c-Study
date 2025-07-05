namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            status = new Label();
            loginBtn = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            sideBtn = new Button();
            btn1 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleTurquoise;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(status);
            panel1.Controls.Add(loginBtn);
            panel1.Controls.Add(btn4);
            panel1.Controls.Add(btn3);
            panel1.Controls.Add(btn2);
            panel1.Controls.Add(sideBtn);
            panel1.Controls.Add(btn1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(155, 452);
            panel1.TabIndex = 1;
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(-1, 346);
            status.Name = "status";
            status.Size = new Size(0, 20);
            status.TabIndex = 6;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(-1, 419);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(155, 32);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "로그인";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += button6_Click;
            // 
            // btn4
            // 
            btn4.BackColor = Color.MediumSpringGreen;
            btn4.ForeColor = SystemColors.ActiveCaptionText;
            btn4.Location = new Point(-1, 263);
            btn4.Name = "btn4";
            btn4.Size = new Size(155, 80);
            btn4.TabIndex = 4;
            btn4.Text = "일정";
            btn4.UseVisualStyleBackColor = false;
            btn4.Click += btn4_Click;
            // 
            // btn3
            // 
            btn3.BackColor = Color.MediumSpringGreen;
            btn3.ForeColor = SystemColors.ActiveCaptionText;
            btn3.Location = new Point(-1, 188);
            btn3.Name = "btn3";
            btn3.Size = new Size(155, 80);
            btn3.TabIndex = 3;
            btn3.Text = "시간표";
            btn3.UseVisualStyleBackColor = false;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.BackColor = Color.MediumSpringGreen;
            btn2.ForeColor = SystemColors.ActiveCaptionText;
            btn2.Location = new Point(-1, 113);
            btn2.Name = "btn2";
            btn2.Size = new Size(155, 80);
            btn2.TabIndex = 2;
            btn2.Text = "TODO";
            btn2.UseVisualStyleBackColor = false;
            btn2.Click += btn2_Click;
            // 
            // sideBtn
            // 
            sideBtn.Location = new Point(120, 3);
            sideBtn.Name = "sideBtn";
            sideBtn.Size = new Size(30, 30);
            sideBtn.TabIndex = 1;
            sideBtn.Text = "≡";
            sideBtn.UseVisualStyleBackColor = true;
            sideBtn.Click += sideBtn_Click;
            // 
            // btn1
            // 
            btn1.BackColor = Color.MediumSpringGreen;
            btn1.ForeColor = SystemColors.ActiveCaptionText;
            btn1.Location = new Point(-1, 37);
            btn1.Name = "btn1";
            btn1.Size = new Size(155, 80);
            btn1.TabIndex = 0;
            btn1.Text = "메인화면";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 450);
            panel2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Form1";
            Text = "간편 스케줄러";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btn1;
        private Button btn4;
        private Button btn3;
        private Button btn2;
        private Button sideBtn;
        private Label status;
        private Button loginBtn;
        private Panel panel2;
    }
}
