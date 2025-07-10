using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;
using static WinFormsApp1.ScheduleList;


namespace WinFormsApp1
{
    public partial class timeTable : UserControl
    {
        Supabase.Client supa = DataBase.GetInstance().supa;
        public int row = 9;
        public int col = 5;
        [Table("timetable")]
        public class timeTableData : BaseModel
        {
            //[PrimaryKey("id")]
            //[Column("id")]
            //public string id { get; set; }

            [Column("time")]
            public int time { get; set; }

            [Column("day")]
            public int day { get; set; }

            [Column("memo")]
            public string memo { get; set; }

            [Column("title")]
            public string title { get; set; }

            [Column("user_id")]
            public string user_id { get; set; }

        }

        List<timeTableData> entries = new List<timeTableData>();

        public timeTable()
        {
            InitializeComponent();
            
            GetTimeTable();
            comboBox1.Items.AddRange(new string[] {
                "월요일",
    "화요일",
    "수요일",
    "목요일",
    "금요일"
});
            comboBox2.Items.AddRange(new string[] {
                "09:00",
                "10:00",
                "11:00",
                "12:00",
                "13:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00"
            });
        }

        async public void GetTimeTable()
        {
            var result = await supa.From<timeTableData>()
                .Select("title,day,time,memo,user_id")
                .Filter("user_id", Operator.Equals, Form1._id)
                .Get();

            // 시간표를 가져오는 로직을 구현합니다.
            // 예: 데이터베이스에서 시간표 데이터를 조회하여 반환
            entries = result.Models ?? new List<timeTableData>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var matched = entries.FirstOrDefault(x =>
                    x.time == j && x.day == i
                     );
                    if (matched != null)
                    {
                        Label label = new Label();
                        label.Text = matched.title;

                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.BackColor = Color.LightBlue;
                        label.MouseClick += timetableLayout_MouseClick;
                        timetableLayout.Controls.Add(label, i, j);
                    }

                }
            }
        }

        public void tableClick(object sender, EventArgs e)
        {

            // 시간표 클릭 이벤트 처리 로직을 구현합니다.
            // 예: 사용자가 시간표의 특정 셀을 클릭했을 때의 동작
            MessageBox.Show("시간표 셀이 클릭되었습니다.");
            Console.WriteLine(sender);
        }

        private void timetableLayout_MouseClick(object sender, MouseEventArgs e)
        {
            TableLayoutPanel panel = sender as TableLayoutPanel;
            int locationX, locationY;
            if (panel == null)
            {
                Label clickedLabel = sender as Label;
                 locationX = clickedLabel.Location.X;
                locationY = clickedLabel.Location.Y;
                panel = clickedLabel?.Parent as TableLayoutPanel;
            }
            else
            {
                locationX = e.X;
                locationY = e.Y;
            }
                //여기까지 정상
                int totalWidth = panel.Width;
            int totalHeight = panel.Height;
            
            int colcell = -1, rowcell = -1;
            
            int x = 0;
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                int colWidth = panel.GetColumnWidths()[i];
                if (locationX < x + colWidth)
                {
                    colcell = i;
                    break;
                }
                x += colWidth;
            }

            int y = 0;
            for (int i = 0; i < panel.RowCount; i++)
            {
                int rowHeight = panel.GetRowHeights()[i];
                if (locationY < y + rowHeight)
                {
                    rowcell = i;
                    break;
                }
                y += rowHeight;
            }

            if (row != -1 && col != -1)
            {
                comboBox1.SelectedIndex = colcell;
                comboBox2.SelectedIndex = rowcell;
                var match = entries.FirstOrDefault(x => x.day == colcell && x.time == rowcell);
                if (match != null)
                {
                    titlebox.Text = match.title;
                    memobox.Text = match.memo;
                }
                else
                {
                    titlebox.Text = "";
                    memobox.Text = "";
                }
            }
        }

        async private void button1_Click(object sender, EventArgs e)
        { 
            if(Form1._id == null)
            {
                MessageBox.Show("로그인 후 사용해주세요.");
                return;
            }
            else if(titlebox.Text == "")
            {
                MessageBox.Show("제목을 입력해주세요.");
                return;
            }else if(memobox.Text == "")
            {
                MessageBox.Show("내용을 입력해주세요.");
                return;
            }
            Console.WriteLine(comboBox1.SelectedIndex);
            Console.WriteLine(comboBox2.SelectedIndex);
            var data = new timeTableData
                {
                    day = comboBox1.SelectedIndex,
                    time = comboBox2.SelectedIndex,
                    title = titlebox.Text,
                    memo = memobox.Text,
                    user_id = Form1._id
                };
            await supa.From<timeTableData>()
                .OnConflict("time,day,user_id")
                .Upsert(data);
            timetableLayout.Controls.Clear();
            GetTimeTable();
        }
    }
}
