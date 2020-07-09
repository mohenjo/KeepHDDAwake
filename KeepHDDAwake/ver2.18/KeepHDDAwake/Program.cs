using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepHDDAwake
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 프로세스 중복 막는 부분
            // 프로그램 중복 실행을 막기 위한 설정입니다.
            // 필요 네임스페이스: System.Diagnostics
            try
            {
                int count = 0;
                Process[] procs = Process.GetProcesses();
                string currentProcessName = Process.GetCurrentProcess().ProcessName;
                foreach (Process p in procs)
                {
                    if (p.ProcessName.Equals(currentProcessName) == true)
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    MessageBox.Show("이 프로그램은 중복하여 실행할 수 없습니다.", "중복 실행 경고", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    // --------------------------------------
                    // 원래 존재하는 부분입니다. 윈폼을 실행시키기 위해 반드시 필요합니다.
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                    // --------------------------------------
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK);
            }
            #endregion
        }
    }
}
