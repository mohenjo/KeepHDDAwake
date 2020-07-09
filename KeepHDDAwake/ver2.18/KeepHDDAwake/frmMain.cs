using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepHDDAwake
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            // 폼 사용자 초기화
            SetUIOnFormInit();
        }

        #region 사용자 메소드

        // 폼 및 콘트롤 설정 - 폼 로드 전
        public void SetUIOnFormInit()
        {
            this.Text = Globals.ApplicationTitle;
            lblAuthor.Text = Globals.AuthorLabel;
        }

        // 폼 및 콘트롤 설정 - 폼 로드 중
        public void SetUIOnFormLoad()
        {
            nudTimeSpan.Maximum = Globals.MAX_TIME_SPAN;
            nudTimeSpan.Minimum = Globals.MIN_TIME_SPAN;
            nudTimeSpan.Value = Globals.HddAccessTimeSpan;
            btnSaveConfig.Enabled = false;
            Globals.IsActive = true;
            UpdateTimerStatus();
            // 시작할 때 윈도우 최소화
            this.WindowState = FormWindowState.Minimized;

        }

        /// <summary>
        /// 메인창 표시 상태에 따라 트레이 아이콘 표시를 업데이트합니다.
        /// </summary>
        public void UpdateNotifyIcon()
        {
            bool isFormMinimized = this.WindowState == FormWindowState.Minimized;
            notifyIcon.Text = Globals.ApplicationTitle;
            notifyIcon.BalloonTipTitle = Globals.ApplicationTitle;
            if (Globals.IsActive)
            {
                notifyIcon.BalloonTipText = "백그라운드에서 작업을 진행합니다.";
            }
            else
            {
                notifyIcon.BalloonTipText = "백그라운드로 전환하나, 작업은 비활성 상태입니다.";
            }

            if (isFormMinimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

        /// <summary>
        /// 작업 활성화 여부에 따라 타이머 동작을 설정합니다.
        /// </summary>
        public void UpdateTimerStatus()
        {
            timer.Interval = Globals.HddAccessTimeSpan * 1000;
            if (Globals.IsActive)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
            this.Text = Globals.ApplicationTitle;
        }

        /// <summary>
        /// 로그 텍스트 박스에 로그를 출력합니다.
        /// </summary>
        /// <param name="logMessage">로그 메세지</param>
        /// <param name="isInfo">참인 경우 정보 로그를 나타냄</param>
        public void UpdateLog(string logMessage = "", bool isInfo = false)
        {
            if (logMessage.Equals(""))
            {
                txtLog.AppendText(Environment.NewLine);
            }
            else if (isInfo)
            {
                string foo = $"[정보] {logMessage}" + Environment.NewLine;
                txtLog.AppendText(foo);
            }
            else
            {
                string logTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string foo = $"[{logTime}] {logMessage}" + Environment.NewLine;
                txtLog.AppendText(foo);
            }
        }

        /// <summary>
        /// 현재 설정 상태를 로그에 출력함
        /// </summary>
        public void LogCurrentStatus()
        {
            UpdateLog(" ");
            UpdateLog($"하드디스크 접근 간격은 {Globals.HddAccessTimeSpan}초입니다.", isInfo: true);
            string currentStatus = Globals.IsActive ? "활성화" : "비활성화";
            UpdateLog($"하드디스크 접근 작업이 {currentStatus} 상태입니다.", isInfo: true);

        }

        #endregion


        private void frmMain_Shown(object sender, EventArgs e)
        {
        }

        private void nudTimeSpan_ValueChanged(object sender, EventArgs e)
        {
            btnSaveConfig.Enabled = true;
            if (Globals.HddAccessTimeSpan == (int)nudTimeSpan.Value)
            {
                btnSaveConfig.Enabled = false;
            }

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            btnSaveConfig.Enabled = false;
            Globals.HddAccessTimeSpan = (int)nudTimeSpan.Value;
            UpdateTimerStatus();
            LogCurrentStatus();
        }

        private void nudTimeSpan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnSaveConfig.Enabled == true)
            {
                btnSaveConfig.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            if (txtLog.Lines.Length > 1000)
            {
                txtLog.Clear();
            }
        }

        private void btnRunProcess_Click(object sender, EventArgs e)
        {
            Globals.IsActive = !Globals.IsActive;
            UpdateTimerStatus();
            LogCurrentStatus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool IsGoodJob = Utilities.WakeHddOnce(out string errorMessage);
            if (IsGoodJob)
            {
                UpdateLog("활성화 작업이 성공적으로 수행되었습니다.");
                Globals.RetryOnError = 0;
            }
            else
            {
                UpdateLog("활성화 작업에 문제가 발생했습니다.");
                UpdateLog($"에러 메세지: {errorMessage}", isInfo: true);
                if (Globals.RetryOnError <= Globals.MAX_RETRY_ON_ERROR)
                {
                    Globals.RetryOnError++;
                }
                else
                {
                    UpdateLog("연속된 오류로 인해 활성화 작업을 중단합니다.");
                    Globals.IsActive = false;
                    UpdateTimerStatus();
                    LogCurrentStatus();
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
            }
            UpdateNotifyIcon();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            UpdateNotifyIcon();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetUIOnFormLoad();
            UpdateLog("어플리케이션이 실행되었습니다.");
            UpdateLog($"현재 실행 경로는 {Globals.CurrentWorkingPath}입니다.", isInfo: true);
            LogCurrentStatus();
        }
    }
}
