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

        public Form1()
        {
            InitializeComponent();
            
            UserControl1 userControl1 = new UserControl1();
            StartFadeTransition(userControl1);
            //userControl.Dock = DockStyle.Fill; // UserControl�� �гο� �� ���� ����
            //panel2.Controls.Add(userControl);
            //userControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //userControl.Location = new Point(200, 100); // UserControl�� ��ġ ����
            //userControl.BringToFront(); // UserControl�� �ֻ����� ��������

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (loginBtn.Text == "�α���")
            {


                Form2 form2 = new Form2();
                // �̺�Ʈ ����
                form2.OnSubmit += Form2_login;

                form2.Show(); // �Ǵ� form2.ShowDialog();
            }
            else
            {
                status.Text = "";
                loginBtn.Text = "�α���"; // �α��� ��ư���� ����
            }
        }

        private void Form2_login(object sender, LoginEventArgs e)
        {
            // ���޹��� �� ó��
            if (e.id == "" || e.pw == "")
            {
                MessageBox.Show("���̵�� ��й�ȣ�� �Է����ּ���.");
                return;
            }
            else
            {
                status.Text = "ȯ���մϴ�\n" + e.id + "��";
                loginBtn.Text = "�α׾ƿ�"; // �α׾ƿ� ��ư���� ����
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
