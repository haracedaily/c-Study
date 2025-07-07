namespace WinFormsApp1
{
    partial class ScheduleList
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
            calendarPan = new FlowLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            calendarTitle = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            btn3 = new Button();
            label2 = new Label();
            label10 = new Label();
            comboBox1 = new ComboBox();
            label11 = new Label();
            selectDate = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(51, 29);
            label1.TabIndex = 0;
            label1.Text = "일정";
            // 
            // calendarPan
            // 
            calendarPan.Location = new Point(23, 86);
            calendarPan.Name = "calendarPan";
            calendarPan.Size = new Size(565, 190);
            calendarPan.TabIndex = 1;
            //calendarPan.Paint += this.calendarPan_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 66);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 3;
            label3.Text = "일요일";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 66);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 4;
            label4.Text = "월요일";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 66);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 5;
            label5.Text = "화요일";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(281, 66);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 6;
            label6.Text = "수요일";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(359, 66);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 7;
            label7.Text = "목요일";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(440, 66);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 8;
            label8.Text = "금요일";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(523, 66);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 9;
            label9.Text = "토요일";
            // 
            // calendarTitle
            // 
            calendarTitle.AutoSize = true;
            calendarTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            calendarTitle.Location = new Point(241, 21);
            calendarTitle.Name = "calendarTitle";
            calendarTitle.Size = new Size(93, 21);
            calendarTitle.TabIndex = 10;
            calendarTitle.Text = "2025년 7월";
            // 
            // button1
            // 
            button1.Location = new Point(496, 19);
            button1.Name = "button1";
            button1.Size = new Size(28, 26);
            button1.TabIndex = 11;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(529, 19);
            button2.Name = "button2";
            button2.Size = new Size(28, 26);
            button2.TabIndex = 12;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 313);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(509, 48);
            textBox1.TabIndex = 13;
            // 
            // btn3
            // 
            btn3.Location = new Point(500, 366);
            btn3.Name = "btn3";
            btn3.Size = new Size(88, 26);
            btn3.TabIndex = 14;
            btn3.Text = "저장";
            btn3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 327);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 15;
            label2.Text = "일정";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(238, 288);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 16;
            label10.Text = "아이콘";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(294, 283);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(141, 23);
            comboBox1.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 286);
            label11.Name = "label11";
            label11.Size = new Size(31, 15);
            label11.TabIndex = 18;
            label11.Text = "날짜";
            // 
            // selectDate
            // 
            selectDate.AutoSize = true;
            selectDate.Location = new Point(79, 288);
            selectDate.Name = "selectDate";
            selectDate.Size = new Size(0, 15);
            selectDate.TabIndex = 19;
            selectDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ScheduleList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(selectDate);
            Controls.Add(label11);
            Controls.Add(comboBox1);
            Controls.Add(label10);
            Controls.Add(label2);
            Controls.Add(btn3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(calendarTitle);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(calendarPan);
            Controls.Add(label1);
            Name = "ScheduleList";
            Size = new Size(607, 397);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel calendarPan;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label calendarTitle;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button btn3;
        private Label label2;
        private Label label10;
        private ComboBox comboBox1;
        private Label label11;
        private Label selectDate;
    }
}
