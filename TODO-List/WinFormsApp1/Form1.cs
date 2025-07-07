using System.Windows.Forms;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isCollapsed = false;
        public class LoginEventArgs : EventArgs
        {
            public string id { get; set; }
            public string pw { get; set; }

            public LoginEventArgs(string ID, string PW)
            {
                id = ID;
                pw = PW;
            }
        }
        private System.Windows.Forms.Timer fadeTimer;
        private int fadeStep = 10;
        private UserControl currentControl;
        private UserControl nextControl;
        private int opacityValue = 0; // 0~255로 색 투명도 흉내


        private void StartFadeTransition(UserControl newControl)
        {
            nextControl = newControl;
            nextControl.BackColor = Color.FromArgb(0, 255, 255, 255); // 완전 투명 흉내
            nextControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(nextControl);
            if (nextControl is UserControl1)
            {

                nextControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                nextControl.Location = new Point(200, 100); // UserControl의 위치 설정
            }else
            {
                nextControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                nextControl.Location = new Point(150, 0); // UserControl의 위치 설정
            }
            nextControl.BringToFront();

            opacityValue = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            opacityValue += fadeStep;
            if (opacityValue >= 255)
            {
                fadeTimer.Stop();
                

                currentControl = nextControl;
                nextControl = null;
            }
            else
            {
                // 색상의 투명도만 조절 (흉내)
                nextControl.BackColor = Color.FromArgb(opacityValue, 255, 255, 255);
            }
        }

        public Form1()
        {
            InitializeComponent();
            
            UserControl1 userControl1 = new UserControl1();
            StartFadeTransition(userControl1);
            //userControl.Dock = DockStyle.Fill; // UserControl을 패널에 꽉 차게 설정
            //panel2.Controls.Add(userControl);
            //userControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //userControl.Location = new Point(200, 100); // UserControl의 위치 설정
            //userControl.BringToFront(); // UserControl을 최상위로 가져오기

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (loginBtn.Text == "로그인")
            {


                Form2 form2 = new Form2();
                // 이벤트 구독
                form2.OnSubmit += Form2_login;

                form2.Show(); // 또는 form2.ShowDialog();
            }
            else
            {
                status.Text = "";
                loginBtn.Text = "로그인"; // 로그인 버튼으로 변경
            }
        }

        private void Form2_login(object sender, LoginEventArgs e)
        {
            // 전달받은 값 처리
            if (e.id == "" || e.pw == "")
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요.");
                return;
            }
            else
            {
                status.Text = "환영합니다\n" + e.id + "님";
                loginBtn.Text = "로그아웃"; // 로그아웃 버튼으로 변경
            }
        }

        private void sideBtn_Click(object sender, EventArgs e)
        {


            if (isCollapsed)
            {
                panel1.Width = 155; // 펼치기
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl != sideBtn) // sideBtn은 제외
                        ctrl.Width = 155;  
                }
                foreach (Control ctrl in panel2.Controls)
                {
                    if (ctrl is UserControl1)
                    {

                        ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        ctrl.Location = new Point(200, 100); // UserControl의 위치 설정
                    }
                    else
                    {
                        ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        ctrl.Location = new Point(150, 0); // UserControl의 위치 설정
                    }
                }   
                sideBtn.Text = "≡";
                isCollapsed = false;
            }
            else
            {
                panel1.Width = 36;  // 접기
                sideBtn.Text = "▶";
                isCollapsed = true;
                sideBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                sideBtn.Location = new Point(36 - 30 - 3, 3);

                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl != sideBtn) // sideBtn은 제외
                        ctrl.Width = 0;  
                }
                foreach (Control ctrl in panel2.Controls)
                {
                    if (ctrl is UserControl1)
                    {
                        ctrl.Location = new Point(200, 100); // UserControl의 위치 설정
                    }
                    else
                    {
                        ctrl.Location = new Point(50, 0); // UserControl의 위치 설정
                    }
                }

            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl1 userControl = new UserControl1();
            StartFadeTransition(userControl);


        }

        private void btn2_Click(object sender, EventArgs e)
        {
            UserControl userControl = new UserControl2();
            StartFadeTransition(userControl);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            UserControl userControl = new UserControl3();
            StartFadeTransition(userControl);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            UserControl userControl = new UserControl4();
            StartFadeTransition(userControl);
        }
    }
}
