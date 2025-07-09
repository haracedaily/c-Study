namespace WinFormsApp1
{
    partial class TodoList
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
            textBox1 = new TextBox();
            button1 = new Button();
            TODO = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(88, 29);
            label1.TabIndex = 1;
            label1.Text = "TODO";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(414, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(458, 71);
            button1.Name = "button1";
            button1.Size = new Size(98, 24);
            button1.TabIndex = 3;
            button1.Text = "추가";
            button1.UseMnemonic = false;
            button1.UseVisualStyleBackColor = false;
            // 
            // TODO
            // 
            TODO.FormattingEnabled = true;
            TODO.ItemHeight = 15;
            TODO.Items.AddRange(new object[] { "TODO" });
            TODO.Location = new Point(23, 114);
            TODO.Name = "TODO";
            TODO.Size = new Size(533, 244);
            TODO.TabIndex = 4;
            // 
            // TodoList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TODO);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "TodoList";
            Size = new Size(607, 397);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private ListBox TODO;
    }
}
