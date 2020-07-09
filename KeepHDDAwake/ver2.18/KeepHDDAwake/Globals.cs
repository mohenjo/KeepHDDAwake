using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace KeepHDDAwake
{
    sealed class Globals
    {
        // ----- 폼 관련

        public static string AuthorLabel = "Powered 2018 by Haennim Park";

        // 하드 디스크 접근 시간 간격(초)의 최대/최소/기본값 
        public const int MAX_TIME_SPAN = 300;
        public const int MIN_TIME_SPAN = 1;
        public const int DEFAULT_TIME_SPAN = 60;

        // ----- 프로그램 논리 관련

        public static bool IsActive { get; set; } = false;

        public static string ApplicationNetTitle { get; } = "Keep HDD Awake";

        public static string ApplicationTitle
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                string activeStatus = IsActive ? "활성화" : "비활성화";

                return $"{ApplicationNetTitle} v{version} - {activeStatus}";
            }
        }

        public static string CurrentWorkingPath
        {
            get
            {
                string cwp = string.Empty;
                try
                {
                    cwp = Environment.CurrentDirectory;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "현재 작업 폴더를 확인하지 못하였습니다."
                        + Environment.NewLine + ex.Message,
                        ApplicationNetTitle, MessageBoxButtons.OK);
                    throw;
                }

                return cwp;
            }
        }

        public static string ConfigFilePath => CurrentWorkingPath + @"\MyConfig.txt";

        public static string HddAccessFilePath => CurrentWorkingPath + @"\AccessLogToBeDeleted.txt";

        public static int HddAccessTimeSpan
        {
            get
            {
                return Utilities.ReadTimeSpanFromConfig();
            }
            set
            {
                Utilities.SetTimeSpanToConfig(value);
            }
        }

        public const int MAX_RETRY_ON_ERROR = 5;

        public static int RetryOnError = 0;

    }
}
