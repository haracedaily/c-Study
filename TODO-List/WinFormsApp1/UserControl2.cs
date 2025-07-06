using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WinFormsApp1
{
    public partial class UserControl2 : UserControl
    {
        int calendarYear; // 연도와 월을 저장할 변수
        int calendarMonth;
        public UserControl2()
        {
            InitializeComponent();
            displayDays();
        }

        private void displayDays()
        {
            // 현재 날짜를 기준으로 달력을 표시하는 로직을 구현합니다.
            DateTime today = DateTime.Now;
            calendarYear = today.Year;
            calendarMonth = today.Month;
            int daysInMonth = DateTime.DaysInMonth(calendarYear, calendarMonth);
            int firstDayOfWeek = (int)new DateTime(calendarYear, calendarMonth, 1).DayOfWeek;
            calendarTitle.Text = $"{calendarYear}년 {calendarMonth}월"; // 달력 제목 설정
            // 달력의 첫 번째 날을 표시하기 위한 위치 계산
            for (int i = 1; i <= firstDayOfWeek; i++)
            {
                calendarBlank blank = new calendarBlank();
                calendarPan.Controls.Add(blank);
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                calendarDate dateControl = new calendarDate();
                dateControl.SetDate(day);
                calendarPan.Controls.Add(dateControl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (calendarMonth == 1)
            {
                calendarYear--;
                calendarMonth = 12;
            }
            else
                calendarMonth--;


            calendarTitle.Text = $"{calendarYear}년 {calendarMonth}월";
            calendarPan.Visible = false; // 달력 패널을 보이도록 설정
            calendarPan.Controls.Clear(); // 이전 달력 내용 제거
            calendarPan.Visible = true; // 달력 패널을 다시 보이도록 설정
            int daysInMonth = DateTime.DaysInMonth(calendarYear, calendarMonth);
            int firstDayOfWeek = (int)new DateTime(calendarYear, calendarMonth, 1).DayOfWeek;
            // 달력의 첫 번째 날을 표시하기 위한 위치 계산
            for (int i = 1; i <= firstDayOfWeek; i++)
            {
                calendarBlank blank = new calendarBlank();
                calendarPan.Controls.Add(blank);
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                calendarDate dateControl = new calendarDate();
                dateControl.SetDate(day);
                calendarPan.Controls.Add(dateControl);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (calendarMonth == 12)
            {
                calendarYear++;
                calendarMonth = 1;
            }
            else
                calendarMonth++;


            calendarTitle.Text = $"{calendarYear}년 {calendarMonth}월";
            calendarPan.Visible = false; // 달력 패널을 보이도록 설정
            calendarPan.Controls.Clear(); // 이전 달력 내용 제거
            calendarPan.Visible = true; // 달력 패널을 다시 보이도록 설정
            int daysInMonth = DateTime.DaysInMonth(calendarYear, calendarMonth);
            int firstDayOfWeek = (int)new DateTime(calendarYear, calendarMonth, 1).DayOfWeek;
            // 달력의 첫 번째 날을 표시하기 위한 위치 계산
            for (int i = 1; i <= firstDayOfWeek; i++)
            {
                calendarBlank blank = new calendarBlank();
                calendarPan.Controls.Add(blank);
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                calendarDate dateControl = new calendarDate();
                dateControl.SetDate(day);
                calendarPan.Controls.Add(dateControl);
            }
        }

    }
}
