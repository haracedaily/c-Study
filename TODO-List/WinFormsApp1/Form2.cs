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
    public partial class Form2 : Form
    {
        public event EventHandler<LoginEventArgs> OnSubmit;
        public event EventHandler<LoginEventArgs> OnSignUp;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = id.Text;
            string userPw = pw.Text;
            if(userId.Length > 0 && userPw.Length > 0)
            {
                Console.WriteLine(userPw);
                // 이벤트 발생
                OnSubmit?.Invoke(this, new LoginEventArgs(userId, userPw, this));
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userId = id.Text;
            string userPw = pw.Text;
            MessageBox.Show(userId.Length.ToString());
            if (userId.Length>0 && userPw.Length>0)
            {
                OnSignUp?.Invoke(this, new LoginEventArgs(userId, userPw,this));
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요");
            }

        }
    }
}
