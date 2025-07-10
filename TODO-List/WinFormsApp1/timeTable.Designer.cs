namespace WinFormsApp1
{
    partial class timeTable
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            timetableLayout = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label9 = new Label();
            label2 = new Label();
            label3 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label16 = new Label();
            label17 = new Label();
            titlebox = new TextBox();
            memobox = new TextBox();
            label18 = new Label();
            label19 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(70, 29);
            label1.TabIndex = 1;
            label1.Text = "시간표";
            // 
            // timetableLayout
            // 
            timetableLayout.ColumnCount = 5;
            timetableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999962F));
            timetableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            timetableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            timetableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            timetableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            timetableLayout.Location = new Point(82, 75);
            timetableLayout.Name = "timetableLayout";
            timetableLayout.RowCount = 9;
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            timetableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            timetableLayout.Size = new Size(491, 255);
            timetableLayout.TabIndex = 2;
            timetableLayout.MouseClick += timetableLayout_MouseClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label8.Location = new Point(501, 53);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 15;
            label8.Text = "금요일";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label7.Location = new Point(404, 53);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 14;
            label7.Text = "목요일";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label6.Location = new Point(304, 53);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 13;
            label6.Text = "수요일";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label5.Location = new Point(205, 53);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 12;
            label5.Text = "화요일";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label4.Location = new Point(107, 53);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 11;
            label4.Text = "월요일";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 251);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 22;
            label9.Text = "15:00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 223);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 21;
            label2.Text = "14:00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 195);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 20;
            label3.Text = "13:00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 167);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 19;
            label10.Text = "12:00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 139);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 18;
            label11.Text = "11:00";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 111);
            label12.Name = "label12";
            label12.Size = new Size(38, 15);
            label12.TabIndex = 17;
            label12.Text = "10:00";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(14, 82);
            label13.Name = "label13";
            label13.Size = new Size(38, 15);
            label13.TabIndex = 16;
            label13.Text = "09:00";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(14, 308);
            label14.Name = "label14";
            label14.Size = new Size(38, 15);
            label14.TabIndex = 24;
            label14.Text = "17:00";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(14, 280);
            label15.Name = "label15";
            label15.Size = new Size(38, 15);
            label15.TabIndex = 23;
            label15.Text = "16:00";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(82, 336);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(101, 23);
            comboBox1.TabIndex = 25;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(82, 367);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(101, 23);
            comboBox2.TabIndex = 26;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(14, 339);
            label16.Name = "label16";
            label16.Size = new Size(31, 15);
            label16.TabIndex = 27;
            label16.Text = "요일";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(14, 370);
            label17.Name = "label17";
            label17.Size = new Size(31, 15);
            label17.TabIndex = 28;
            label17.Text = "시간";
            // 
            // titlebox
            // 
            titlebox.Location = new Point(275, 336);
            titlebox.Name = "titlebox";
            titlebox.Size = new Size(100, 23);
            titlebox.TabIndex = 29;
            // 
            // memobox
            // 
            memobox.Location = new Point(275, 367);
            memobox.Name = "memobox";
            memobox.Size = new Size(198, 23);
            memobox.TabIndex = 30;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(205, 339);
            label18.Name = "label18";
            label18.Size = new Size(43, 15);
            label18.TabIndex = 31;
            label18.Text = "일정명";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(205, 370);
            label19.Name = "label19";
            label19.Size = new Size(31, 15);
            label19.TabIndex = 32;
            label19.Text = "내용";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(498, 366);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 33;
            button1.Text = "저장";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // timeTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(memobox);
            Controls.Add(titlebox);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label9);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(timetableLayout);
            Controls.Add(label1);
            Name = "timeTable";
            Size = new Size(607, 397);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TableLayoutPanel timetableLayout;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label2;
        private Label label3;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label16;
        private Label label17;
        private TextBox titlebox;
        private TextBox memobox;
        private Label label18;
        private Label label19;
        private Button button1;
    }
}
