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
using static WinFormsApp1.ScheduleList;

namespace WinFormsApp1
{
    public partial class calendarDate : UserControl
    {
        ScheduleList.calendarData plan = new ScheduleList.calendarData();
        public event EventHandler<CalendarDateEventArgs> OnDateClick;
        public calendarDate()
        {
            InitializeComponent();
        }

        public void SetDate(int day)
        {
            label1.Text = day.ToString(); // 레이블에 날짜 표시
        }

        public void SetColor(Color color)
        {
            this.BackColor = color; // 배경색 설정
        }

        public void setIcon(string icon)
        {
            calendarIcon.Text = icon; // 아이콘 설정
        }
        public void setData(ScheduleList.calendarData data)
        {
            plan = data;
        }
        private void calendarDate_Click(object sender, EventArgs e)
        {
            OnDateClick.Invoke(this, new CalendarDateEventArgs(this.plan)); // 날짜 클릭 이벤트 발생
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
