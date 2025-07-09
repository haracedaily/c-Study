using Sprache;
using Supabase.Core.Extensions;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WinFormsApp1
{

    public partial class ScheduleList : UserControl
    {
        Supabase.Client supa = DataBase.GetInstance().supa;
        int calendarYear; // 연도와 월을 저장할 변수
        int calendarMonth;
        int calendarDate;
        List<calendarData> entries = new List<calendarData>();
        [Table("schedule")]
        public class calendarData : BaseModel
        {
            //[PrimaryKey("id")]
            //[Column("id")]
            //public string id { get; set; }

            [Column("year")]
            public int year { get; set; }

            [Column("month")]
            public int month { get; set; }

            [Column("date")]
            public int date { get; set; }

            [Column("plan")]
            public string plan { get; set; }

            [Column("icon")]
            public string icon { get; set; }

            [Column("user_id")]
            public string user_id { get; set; }

        }
        public ScheduleList()
        {
            InitializeComponent();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(new string[] {
                "",
    "❤️",
    "⭐",
    "😂",
    "😭",
    "🎵",
    "⚡",
    "😡"
});
            comboBox1.DrawItem += ComboBox1_DrawItem;

            displayDays();

        }
        public class CalendarDateEventArgs : EventArgs
        {
            public calendarData Data { get; set; }
            public CalendarDateEventArgs(calendarData data)
            {
                Data = data;
            }
        }
        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string text = comboBox1.Items[e.Index].ToString();
            // 이모지를 지원하는 폰트 선택
            using (Font emojiFont = new Font("Segoe UI Emoji", e.Font.Size))
            {
                e.Graphics.DrawString(text, emojiFont, Brushes.Black, e.Bounds.Location);
            }

            e.DrawFocusRectangle();
        }

        private void displayDays()
        {

            // 현재 날짜를 기준으로 달력을 표시하는 로직을 구현합니다.
            DateTime today = DateTime.Now;
            calendarYear = today.Year;
            calendarMonth = today.Month;
            draw_calendar(); // 달력 그리기 메서드 호출

        }
        async private void draw_calendar()
        {
            comboBox1.SelectedItem = ""; // 선택한 날짜의 아이콘 설정
            textBox1.Text = ""; // 선택한 날짜의 계획 설정
            var result = await supa.From<calendarData>()
                .Select("icon,user_id,plan,date,year,month")
                .Filter("year", Operator.Equals, calendarYear)
                .Filter("month", Operator.Equals, calendarMonth)
                .Filter("user_id", Operator.Equals, Form1._id)
                .Get();
            entries = result.Models ?? new List<calendarData>();
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
                dateControl.OnDateClick += CalendarDate_OnClick;
                dateControl.SetDate(day);
                var matched = entries.FirstOrDefault(x =>
                    x.date == day
                );

                if (matched != null)
                {
                    // calendarDate 컨트롤에 정보 전달 (예: 색상, 텍스트 등)
                    dateControl.SetColor(Color.Bisque);
                    dateControl.setIcon(matched.icon);
                    dateControl.setData(matched);
                }
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
            draw_calendar(); // 달력 다시 그리기

        }

        private void CalendarDate_OnClick(object sender, CalendarDateEventArgs e)
        {
            calendarDate clickedDate = sender as calendarDate;
            if (clickedDate != null)
            {
                // 클릭된 날짜에 대한 처리 로직을 여기에 추가합니다.
                //MessageBox.Show($"선택한 날짜: {calendarYear}년 {calendarMonth}월 {clickedDate.label1.Text}일");
                selectDate.Text = $"{calendarYear}년 {calendarMonth}월 {clickedDate.label1.Text}일"; // 선택한 날짜 표시
                calendarDate=Int32.Parse(clickedDate.label1.Text); // 선택한 날짜의 일(day) 저장
                if (e.Data.plan != null)
                {
                    comboBox1.SelectedItem = e.Data.icon; // 선택한 날짜의 아이콘 설정
                    textBox1.Text = e.Data.plan; // 선택한 날짜의 계획 설정
                }
                else
                {
                    comboBox1.SelectedItem = ""; // 선택한 날짜의 아이콘 설정
                    textBox1.Text = ""; // 선택한 날짜의 계획 설정
                }
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
            draw_calendar(); // 달력 다시 그리기
        }

        async private void btn3_Click(object sender, EventArgs e)
        {
            var data = new calendarData
            {
                year = calendarYear,
                month = calendarMonth,
                date = calendarDate,
                plan = textBox1.Text,
                user_id = Form1._id,
                icon = comboBox1.SelectedItem.ToString()
            };
            var result = await supa.From<calendarData>().OnConflict("year,month,date,user_id")
                           .Upsert(data);
            draw_calendar();
        }
    }
}
