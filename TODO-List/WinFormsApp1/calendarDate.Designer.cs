﻿namespace WinFormsApp1
{
    partial class calendarDate
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
            calendarIcon = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // calendarIcon
            // 
            calendarIcon.AutoSize = true;
            calendarIcon.Location = new Point(11, 3);
            calendarIcon.Name = "calendarIcon";
            calendarIcon.Size = new Size(0, 15);
            calendarIcon.TabIndex = 1;
            // 
            // calendarDate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(calendarIcon);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "calendarDate";
            Size = new Size(75, 22);
            Click += calendarDate_Click;
            MouseEnter += calendarDate_MouseEnter;
            MouseLeave += calendarDate_MouseLeave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        private Label calendarIcon;
    }
}
