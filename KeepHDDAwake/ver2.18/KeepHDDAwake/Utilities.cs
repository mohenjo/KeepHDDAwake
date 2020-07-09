using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace KeepHDDAwake
{
    sealed class Utilities
    {
        /// <summary>
        /// 설정 파일로부터 하드 디스크 접근 간격(초)을 얻습니다.
        /// </summary>
        /// <returns></returns>
        public static int ReadTimeSpanFromConfig()
        {
            string timeSpanString = string.Empty;

            try
            {
                timeSpanString = File.ReadAllText(Globals.ConfigFilePath);
            }
            catch (FileNotFoundException ex)
            {
                SetTimeSpanToConfig(Globals.DEFAULT_TIME_SPAN);
                timeSpanString = Globals.DEFAULT_TIME_SPAN.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        "설정 파일을 여는 중에 오류가 발생했습니다."
                        + Environment.NewLine + ex.Message,
                        Globals.ApplicationNetTitle, MessageBoxButtons.OK);
                throw;
            }

            if (int.TryParse(timeSpanString, out int timeSpan))
            {
                if (timeSpan > Globals.MAX_TIME_SPAN || timeSpan < Globals.MIN_TIME_SPAN)
                {
                    timeSpan = Globals.DEFAULT_TIME_SPAN;
                    SetTimeSpanToConfig(Globals.DEFAULT_TIME_SPAN);
                }
            }
            else
            {
                timeSpan = Globals.DEFAULT_TIME_SPAN;
                SetTimeSpanToConfig(Globals.DEFAULT_TIME_SPAN);
            }

            return timeSpan;
        }


        /// <summary>
        /// 설정 파일에 하드 디스크 접근 간격(초)를 저장합니다.
        /// </summary>
        /// <param name="newTimeSpan">하드 디스크 접근 간격(초)</param>
        public static void SetTimeSpanToConfig(int newTimeSpan)
        {
            try
            {
                File.WriteAllText(Globals.ConfigFilePath, newTimeSpan.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        "사용자 설정 파일을 저장하는 중에 오류가 발생하였습니다."
                        + Environment.NewLine + ex.Message,
                        Globals.ApplicationNetTitle, MessageBoxButtons.OK);
                throw;
            }
        }

        /// <summary>
        /// 하드 디스크에 임시 파일을 작성 및 삭제하여 해당 드라이브를 깨워둡니다.
        /// <para>
        /// 거짓이 반환될 경우 이 과정에 예외가 발생한 것입니다.
        /// 이 경우 인자로서 예외 메세지가 같이 반환됩니다.
        /// </para>
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool WakeHddOnce(out string errorMessage)
        {
            StringBuilder ShoudNotSeeMe = new StringBuilder();
            ShoudNotSeeMe.AppendLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ShoudNotSeeMe.AppendLine(
                $"이 내용을 보고 있다면, '{Globals.ApplicationTitle}'가(이) 정상적으로 동작하고 있지 않다는 의미입니다.");
            ShoudNotSeeMe.AppendLine("이 파일을 수동 삭제하여도 무방합니다.");

            bool isJobSuccessful = true;
            errorMessage = string.Empty;
            try
            {
                File.WriteAllText(Globals.HddAccessFilePath, ShoudNotSeeMe.ToString());
                File.Delete(Globals.HddAccessFilePath);
//#if DEBUG
//                throw new Exception("디버그 용으로 발생시키는 예외 메세지입니다.");
//#endif
            }
            catch (Exception ex)
            {
                isJobSuccessful = false;
                errorMessage = ex.Message;
            }

            return isJobSuccessful;
        }
    }
}
