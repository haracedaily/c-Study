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
    public partial class calendarDate : UserControl
    {
        public calendarDate()
        {
            InitializeComponent();
        }

        public void SetDate(int day)
        {
            label1.Text = day.ToString(); // 레이블에 날짜 표시
        }
    }
}
