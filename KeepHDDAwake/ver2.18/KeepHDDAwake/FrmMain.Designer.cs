namespace KeepHDDAwake
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.nudTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnRunProcess = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSpan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "하드디스크 액세스 간격(초):";
            // 
            // nudTimeSpan
            // 
            this.nudTimeSpan.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudTimeSpan.Location = new System.Drawing.Point(185, 24);
            this.nudTimeSpan.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudTimeSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeSpan.Name = "nudTimeSpan";
            this.nudTimeSpan.Size = new System.Drawing.Size(71, 23);
            this.nudTimeSpan.TabIndex = 1;
            this.nudTimeSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudTimeSpan.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudTimeSpan.ValueChanged += new System.EventHandler(this.nudTimeSpan_ValueChanged);
            this.nudTimeSpan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudTimeSpan_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "로그:";
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("나눔고딕코딩", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLog.Location = new System.Drawing.Point(12, 154);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(438, 183);
            this.txtLog.TabIndex = 3;
            this.txtLog.TabStop = false;
            this.txtLog.WordWrap = false;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveConfig.ImageIndex = 0;
            this.btnSaveConfig.Location = new System.Drawing.Point(276, 17);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(156, 34);
            this.btnSaveConfig.TabIndex = 4;
            this.btnSaveConfig.Text = "설정 저장";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnRunProcess
            // 
            this.btnRunProcess.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRunProcess.ImageIndex = 1;
            this.btnRunProcess.Location = new System.Drawing.Point(12, 81);
            this.btnRunProcess.Name = "btnRunProcess";
            this.btnRunProcess.Size = new System.Drawing.Size(208, 34);
            this.btnRunProcess.TabIndex = 5;
            this.btnRunProcess.Text = "작업 상태 전환 (&C)";
            this.btnRunProcess.UseVisualStyleBackColor = true;
            this.btnRunProcess.Click += new System.EventHandler(this.btnRunProcess_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.ImageIndex = 3;
            this.btnExit.Location = new System.Drawing.Point(242, 81);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(208, 34);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "프로그램 종료 (&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveConfig);
            this.groupBox1.Controls.Add(this.nudTimeSpan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(12, 350);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(438, 25);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "작성자 정보";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(460, 384);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRunProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLog);
            this.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSpan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTimeSpan;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnRunProcess;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

