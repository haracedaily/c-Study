using DotNetEnv;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Security.Policy;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string url;
        private string key;
        private Supabase.Client supa;

        [Table("users")]
        public class Users : BaseModel
        {
            [PrimaryKey("id")]
            [Column("id")]
            public string id { get; set; }

            [Column("password")]
            public string password { get; set; }

            [Column("created_at")]
            public DateTime CreatedAt { get; set; }
        }
        private static string? _id;
        
        private bool isCollapsed = false;
        public class LoginEventArgs : EventArgs
        {
            public string id { get; set; }
            public string pw { get; set; }
            public Form2 form2 { get; set; }
            public LoginEventArgs(string ID, string PW, Form2 form)
            {
                id = ID;
                pw = PW;
                this.form2 = form;
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

        //시작 run start
        public Form1()
        {
            Env.Load(); // .env 파일 로드
            InitializeComponent();
            url = Environment.GetEnvironmentVariable("SUPABASE_URL");
            key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
            UserControl1 userControl1 = new UserControl1();
            StartFadeTransition(userControl1);
            //userControl.Dock = DockStyle.Fill; // UserControl을 패널에 꽉 차게 설정
            //panel2.Controls.Add(userControl);
            //userControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //userControl.Location = new Point(200, 100); // UserControl의 위치 설정
            //userControl.BringToFront(); // UserControl을 최상위로 가져오기
            
            if (url is not null && key is not null)
            {
                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true
                };
                supa = new Supabase.Client(url, key, options);
                
                // Supabase 초기화 (비동기)
                Task.Run(async () =>
                {
                    await supa.InitializeAsync();
                    // DB 연결 테스트: 예를 들어 users 테이블 조회
                    //var resp = await supa.From<User>().Get();
                    ////MessageBox.Show(resp.Models.ToString());
                    //foreach (var u in resp.Models)
                    //{
                    //    MessageBox.Show(u.ToString());
                    //}
                    //if (resp.Models != null)
                    //{
                    //    foreach (var item in resp.Models)
                    //        Console.WriteLine(item);
                    //}
                });


                

            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (loginBtn.Text == "로그인")
            {


                Form2 form2 = new Form2();
                // 이벤트 구독
                form2.OnSubmit += Form2_login;
                form2.OnSignUp += Form2_SignUp;
                
                form2.Show(); // 또는 form2.ShowDialog();
            }
            else
            {
                _id = null;
                status.Text = "";
                loginBtn.Text = "로그인"; // 로그인 버튼으로 변경
            }
        }

        async private void Form2_login(object sender, LoginEventArgs e)
        {
            // 전달받은 값 처리
            if (e.id == "" || e.pw == "")
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요.");
                return;
            }
            else
            {
                var result = await supa
  .From<Users>()
  .Select("id, password")
  .Filter("id", Operator.Equals, e.id)
  .Get();
                if(result.Model != null)
                {
                    if (result.Model.password == e.pw)
                    {
                        _id = e.id;
                        status.Text = "환영합니다\n" + e.id + "님";
                        loginBtn.Text = "로그아웃"; // 로그아웃 버튼으로 변경
                        e.form2.Close();
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 틀렸습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("존재하지 않는 아이디 입니다.");
                }
            }
        }

        async private void Form2_SignUp(object sender, LoginEventArgs e)
        {
            var result  = await supa
  .From<Users>()
  .Select("id, password")
  .Filter("id", Operator.Equals, e.id)
  .Get();

            if (result.Models.Count > 0)
            {
                MessageBox.Show("중복되는 아이디가 있습니다.");
                return;
            }
            else
            {
                
                var data = new Users { 
                   id = e.id,
                   password = e.pw,
                    CreatedAt = DateTime.UtcNow
                };
                
                await supa.From<Users>().Insert(data);
                MessageBox.Show("성공적으로 회원가입 되었습니다.");
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
            UserControl userControl = new TodoList();
            StartFadeTransition(userControl);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            UserControl userControl = new UserControl3();
            StartFadeTransition(userControl);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            UserControl userControl = new ScheduleList();
            StartFadeTransition(userControl);
        }
    }
}
