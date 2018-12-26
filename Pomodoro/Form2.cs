using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;



namespace Pomodoro
{
    public partial class Form2 : Form
    {
        private WebClient _client = null;
        private DateTime currentTime;
        private int pomodoroTimes;
        private static int _workTime;
        private int _shortBreak;
        private int _longBreak;
        private int _checkMarks;
        private char _twoDots = ':';
        private int _value;
        private static int _seconds;

        public Form2()
        {
            InitializeComponent();
            SetEvent(OnTimer, timer);
            SetEvent(ShortTimer, timer1);
            SetEvent(LongTimer, timer2);
            countdown.Value = 0;
            MessageBallons(1);
            MaximizeBox = false;
            Stop.Visible = false;
        }

        private void InitialValues()
        {
            _workTime = 25;
            _shortBreak = 5;
            _longBreak = 15;
            _checkMarks = 0;
            _value = 0;
            pomodoroTimes = 0;
            _seconds = 60;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            InitialValues();
            Stop.Visible = true;
            Start.Enabled = false;
            SetPresence("away");
            SetProgressValue(_workTime);

            timer.Start();

            MinimizeForm();
            MessageBallons(_workTime);
        }

        private void SetPresence(string status)
        {
            _client = new WebClient();
            var appSettings = ConfigurationManager.AppSettings;
            var key = appSettings.GetKey(0);
            _client.UploadValues("https://polirock.slack.com/api/users.setPresence", "POST",
                new NameValueCollection()
                {
                    {"token", appSettings[key]},
                    {"presence", status}
                });
        }

        private void OnTimer(object sender, EventArgs e)
        {
            _seconds--;

            if (_workTime == 0)
            {

                _workTime = 25;

                SetPresence("auto");
                _checkMarks++;
                timer.Stop();

                if (_checkMarks < 4)
                {
                    SetProgressValue(_shortBreak);
                    timer1.Start();

                    MaximizeForm();
                    MessageBallons(_shortBreak);
                }

                else
                {
                    pomodoroTimes++;
                    SetProgressValue(_longBreak);
                    _checkMarks = 0;                    
                    timer2.Start();

                    MaximizeForm();
                    MessageBallons(_longBreak);
                }

                return;
            }

            WriteTimetoText(_workTime - 1, _seconds);

            if (_seconds == 0)
            {
                _workTime--;
                WriteTimetoText(_workTime, _seconds);
                _seconds = 60;
            }

            countdown.Value += _value;
            countdown.Update();
        }

        private void ShortTimer(object sender, EventArgs e)
        {
            _seconds--;

            countdown.Value += _value;
            countdown.Update();

            if (_shortBreak == 0)
            {
                timer1.Stop();
                _shortBreak = 5;

                SetPresence("away");

                SetProgressValue(_workTime);
                timer.Start();

                MinimizeForm();
                MessageBallons(_workTime);

                return;
            }

            WriteTimetoText(_shortBreak - 1, _seconds);

            if (_seconds == 0)
            {
                _shortBreak--;
                WriteTimetoText(_shortBreak, _seconds);
                _seconds = 60;
            }
        }

        private void LongTimer(object sender, EventArgs e)
        {
            _seconds--;


            countdown.Value += _value;
            countdown.Update();

            if (_longBreak == 0)
            {
                timer2.Stop();
                _longBreak = 15;

                SetPresence("away");

                SetProgressValue(_workTime);
                timer.Start();

                MinimizeForm();
                MessageBallons(_workTime);

                timer.Start();

                return;
            }

            WriteTimetoText(_longBreak - 1, _seconds);

            if (_seconds == 0)
            {
                _longBreak--;
                WriteTimetoText(_longBreak, _seconds);
                _seconds = 60;
            }
        }

        private void SetProgressValue(int val)
        {
            countdown.Value = 0;
            countdown.Minimum = 0;
            countdown.Maximum = 2000;
            _value = (2000 / (60 * val));

            if (val == _workTime)
            {
                countdown.ProgressColor = System.Drawing.Color.Tomato;
            }
            else
            {
                countdown.ProgressColor = System.Drawing.Color.Green;
            }
        }

        private void MinimizeForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            Pomodoro.Visible = true;
        }

        private void MaximizeForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            Pomodoro.Visible = true;
        }

        private void WriteTimetoText(int val, int sec)
        {
            time.Text = val.ToString() + _twoDots.ToString() + sec.ToString();
        }

        private void WriteToFileTimes()
        {
            currentTime = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            sb.Append(currentTime + "   " + pomodoroTimes + "  pomodoros completed.");
            File.AppendAllText(path + ".log", sb.ToString() + Environment.NewLine);
        }

        private void MessageBallons(int val)
        {
            if (val == _workTime)
            {
                Pomodoro.BalloonTipText = "Süreniz başladı! Kolay gelsin. 🤓";
                Pomodoro.ShowBalloonTip(1000);
            }
            else if (val == _shortBreak)
            {
                Pomodoro.BalloonTipText = "Kahvelerimizi yenilesek mi? ☕";
                Pomodoro.ShowBalloonTip(1000);
            }
            else if (val == _longBreak)
            {
                Pomodoro.BalloonTipText = "Çok çalıştık bunu hak ettik. 15 dk sonra görüşürüz! ☺️";
                Pomodoro.ShowBalloonTip(1000);
            }
            else if (val == 0)
            {
                if (pomodoroTimes >= 3)
                {
                    Pomodoro.BalloonTipText = "Bugün " + pomodoroTimes + " pomodoro uygulamışsın 😎 Harikasın! Tekrar görüşürüz 👋🏽";
                    Pomodoro.ShowBalloonTip(1000);
                }
                else
                {
                    Pomodoro.BalloonTipText = "Bugün " + pomodoroTimes + " pomodoro uygulamışsın 🤔 Pomodoroyu daha fazla kullanarak çalışma akışının verimini arttırmalısın. Tekrar görüşürüz 👋🏽";
                    Pomodoro.ShowBalloonTip(1000);
                }

            }
            else if (val == 1)
            {
                Pomodoro.BalloonTipText = "Pomodoro'ya hoşgeldin! ☺️";
                Pomodoro.ShowBalloonTip(1000);
            }
        }

        private void SetEvent(EventHandler handler, Timer time)
        {
            time.Tick += new EventHandler(handler);
            time.Interval = 1000;
        }


        private void Stop_Click(object sender, EventArgs e)
        {
            SetPresence("auto");
            timer.Dispose();
            timer1.Dispose();
            timer2.Dispose();
            Start.Enabled = true;
            Stop.Visible = false;
            MessageBallons(0);
            WriteTimetoText(0, 0);
            WriteToFileTimes();
        }

        private void Pomodoro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaximizeForm();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult close = new DialogResult();
                close = MessageBox.Show("Emin misiniz?", "Çıkış",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (close == DialogResult.Yes)
                {
                    this.Visible = false;
                    SetPresence("auto");
                    timer.Dispose();
                    timer1.Dispose();
                    timer2.Dispose();
                    WriteToFileTimes();
                    e.Cancel = false;
                }

                else
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }

    }



}
