namespace WinFormsApp1
{
    partial class Form2
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
            button1 = new Button();
            id = new TextBox();
            pw = new TextBox();
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(169, 122);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(73, 22);
            button1.TabIndex = 0;
            button1.Text = "로그인";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // id
            // 
            id.Location = new Point(72, 51);
            id.Margin = new Padding(2);
            id.Name = "id";
            id.Size = new Size(171, 23);
            id.TabIndex = 1;
            // 
            // pw
            // 
            pw.Location = new Point(72, 85);
            pw.Margin = new Padding(2);
            pw.Name = "pw";
            pw.Size = new Size(171, 23);
            pw.TabIndex = 2;
            pw.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pw);
            panel1.Controls.Add(id);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(163, 79);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(264, 180);
            panel1.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Location = new Point(72, 122);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(73, 22);
            button3.TabIndex = 6;
            button3.Text = "회원가입";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Location = new Point(169, 148);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(73, 22);
            button2.TabIndex = 5;
            button2.Text = "닫기";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 87);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "비밀번호";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 53);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "아이디";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 338);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TextBox id;
        private TextBox pw;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button3;
    }
}