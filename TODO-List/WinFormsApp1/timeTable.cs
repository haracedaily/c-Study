using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class timeTable : UserControl
    {
        Supabase.Client supa = DataBase.GetInstance().supa;
        public timeTable()
        {
            InitializeComponent();
            
        }

        public void SetTimeTable(List<ScheduleList.calendarData> entries)
        {
            // 시간표를 설정하는 로직을 구현합니다.
            // 예: entries를 기반으로 시간표를 그립니다.
            foreach (var entry in entries)
            {
                // 각 entry에 대해 시간표에 표시할 내용을 설정합니다.
                // 예: 특정 위치에 레이블을 추가하거나 색상을 변경하는 등의 작업
                Console.WriteLine($"Year: {entry.year}, Month: {entry.month}, Date: {entry.date}, Plan: {entry.plan}, Icon: {entry.icon}");
            }
        }

        public void tableClick(object sender, EventArgs e)
        {
            // 시간표 클릭 이벤트 처리 로직을 구현합니다.
            // 예: 사용자가 시간표의 특정 셀을 클릭했을 때의 동작
            MessageBox.Show("시간표 셀이 클릭되었습니다.");
            Console.WriteLine(sender);
        }

    }
}
