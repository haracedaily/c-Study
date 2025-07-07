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
        private int opacityValue = 0; // 0~255�� �� ���� �䳻


        private void StartFadeTransition(UserControl newControl)
        {
            nextControl = newControl;
            nextControl.BackColor = Color.FromArgb(0, 255, 255, 255); // ���� ���� �䳻
            nextControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(nextControl);
            if (nextControl is UserControl1)
            {

                nextControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                nextControl.Location = new Point(200, 100); // UserControl�� ��ġ ����
            }else
            {
                nextControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                nextControl.Location = new Point(150, 0); // UserControl�� ��ġ ����
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
                // ������ ������ ���� (�䳻)
                nextControl.BackColor = Color.FromArgb(opacityValue, 255, 255, 255);
            }
        }

        //���� run start
        public Form1()
        {
            Env.Load(); // .env ���� �ε�
            InitializeComponent();
            url = Environment.GetEnvironmentVariable("SUPABASE_URL");
            key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
            UserControl1 userControl1 = new UserControl1();
            StartFadeTransition(userControl1);
            //userControl.Dock = DockStyle.Fill; // UserControl�� �гο� �� ���� ����
            //panel2.Controls.Add(userControl);
            //userControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //userControl.Location = new Point(200, 100); // UserControl�� ��ġ ����
            //userControl.BringToFront(); // UserControl�� �ֻ����� ��������
            
            if (url is not null && key is not null)
            {
                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true
                };
                supa = new Supabase.Client(url, key, options);
                
                // Supabase �ʱ�ȭ (�񵿱�)
                Task.Run(async () =>
                {
                    await supa.InitializeAsync();
                    // DB ���� �׽�Ʈ: ���� ��� users ���̺� ��ȸ
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
            if (loginBtn.Text == "�α���")
            {


                Form2 form2 = new Form2();
                // �̺�Ʈ ����
                form2.OnSubmit += Form2_login;
                form2.OnSignUp += Form2_SignUp;
                
                form2.Show(); // �Ǵ� form2.ShowDialog();
            }
            else
            {
                _id = null;
                status.Text = "";
                loginBtn.Text = "�α���"; // �α��� ��ư���� ����
            }
        }

        async private void Form2_login(object sender, LoginEventArgs e)
        {
            // ���޹��� �� ó��
            if (e.id == "" || e.pw == "")
            {
                MessageBox.Show("���̵�� ��й�ȣ�� �Է����ּ���.");
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
                        status.Text = "ȯ���մϴ�\n" + e.id + "��";
                        loginBtn.Text = "�α׾ƿ�"; // �α׾ƿ� ��ư���� ����
                        e.form2.Close();
                    }
                    else
                    {
                        MessageBox.Show("��й�ȣ�� Ʋ�Ƚ��ϴ�.");
                    }
                }
                else
                {
                    MessageBox.Show("�������� �ʴ� ���̵� �Դϴ�.");
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
                MessageBox.Show("�ߺ��Ǵ� ���̵� �ֽ��ϴ�.");
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
                MessageBox.Show("���������� ȸ������ �Ǿ����ϴ�.");
            }



        }



        private void sideBtn_Click(object sender, EventArgs e)
        {


            if (isCollapsed)
            {
                panel1.Width = 155; // ��ġ��
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl != sideBtn) // sideBtn�� ����
                        ctrl.Width = 155;  
                }
                foreach (Control ctrl in panel2.Controls)
                {
                    if (ctrl is UserControl1)
                    {

                        ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        ctrl.Location = new Point(200, 100); // UserControl�� ��ġ ����
                    }
                    else
                    {
                        ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        ctrl.Location = new Point(150, 0); // UserControl�� ��ġ ����
                    }
                }   
                sideBtn.Text = "��";
                isCollapsed = false;
            }
            else
            {
                panel1.Width = 36;  // ����
                sideBtn.Text = "��";
                isCollapsed = true;
                sideBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                sideBtn.Location = new Point(36 - 30 - 3, 3);

                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl != sideBtn) // sideBtn�� ����
                        ctrl.Width = 0;  
                }
                foreach (Control ctrl in panel2.Controls)
                {
                    if (ctrl is UserControl1)
                    {
                        ctrl.Location = new Point(200, 100); // UserControl�� ��ġ ����
                    }
                    else
                    {
                        ctrl.Location = new Point(50, 0); // UserControl�� ��ġ ����
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
