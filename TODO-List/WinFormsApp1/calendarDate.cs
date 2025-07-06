using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
    public partial class calendarDate : UserControl
    {
        public event EventHandler<EventArgs> OnDateClick;
        public calendarDate()
        {
            InitializeComponent();
        }

        public void SetDate(int day)
        {
            label1.Text = day.ToString(); // 레이블에 날짜 표시
        }

        private void calendarDate_Click(object sender, EventArgs e)
        {
            OnDateClick.Invoke(this, EventArgs.Empty); // 날짜 클릭 이벤트 발생
        }


        private void calendarDate_MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle; // 마우스 오버 시 테두리 표시
        }

        private void calendarDate_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None; // 마우스가 벗어나면 테두리 제거
        }
    }
}
