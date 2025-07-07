namespace WinFormsApp1
{
    partial class UserControl1
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
            title = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 129);
            title.Location = new Point(14, 18);
            title.Name = "title";
            title.Size = new Size(394, 146);
            title.TabIndex = 3;
            title.Text = "C#으로 만드는\r\n간편 스케줄러";
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7.5F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(title);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserControl1";
            Size = new Size(432, 182);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
    }
}
