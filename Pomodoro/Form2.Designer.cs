namespace Pomodoro
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Stop = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.countdown = new CircularProgressBar.CircularProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Pomodoro = new System.Windows.Forms.NotifyIcon(this.components);
            this.time = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Stop
            // 
            resources.ApplyResources(this.Stop, "Stop");
            this.Stop.Name = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Start
            // 
            resources.ApplyResources(this.Start, "Start");
            this.Start.Name = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // countdown
            // 
            this.countdown.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.countdown.AnimationSpeed = 500;
            this.countdown.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.countdown, "countdown");
            this.countdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.countdown.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.countdown.InnerMargin = 2;
            this.countdown.InnerWidth = -1;
            this.countdown.MarqueeAnimationSpeed = 2000;
            this.countdown.Maximum = 2000;
            this.countdown.Name = "countdown";
            this.countdown.OuterColor = System.Drawing.Color.Gray;
            this.countdown.OuterMargin = -25;
            this.countdown.OuterWidth = 26;
            this.countdown.ProgressColor = System.Drawing.Color.Tomato;
            this.countdown.ProgressWidth = 25;
            this.countdown.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.countdown.StartAngle = 270;
            this.countdown.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.countdown.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.countdown.SubscriptText = "";
            this.countdown.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.countdown.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.countdown.SuperscriptText = "";
            this.countdown.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.countdown.Value = 68;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // Pomodoro
            // 
            resources.ApplyResources(this.Pomodoro, "Pomodoro");
            this.Pomodoro.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Pomodoro_MouseDoubleClick);
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.time, "time");
            this.time.Name = "time";
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CausesValidation = false;
            this.Controls.Add(this.time);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.countdown);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Pomodoro.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("MaximumSize", global::Pomodoro.Properties.Settings.Default, "LastLoc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::Pomodoro.Properties.Settings.Default.Location;
            this.MaximumSize = global::Pomodoro.Properties.Settings.Default.LastLoc;
            this.MinimumSize = this.Size;
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CircularProgressBar.CircularProgressBar countdown;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.NotifyIcon Pomodoro;
        private System.Windows.Forms.TextBox time;
    }
}