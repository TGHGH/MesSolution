using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frms.Helper
{
    public class FileLog
    {
        public static string FileName = "MessageLog.txt";
        public static string VersionFileName = "Version.txt";
        public static void FileLogOut(string fileName, string logStr)
        {
            StreamWriter streamWriter = null;
            try
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                streamWriter = File.AppendText(fileName);
                streamWriter.WriteLine(logStr);
            }
            catch
            {
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
        public static string GetLocalCSVersion(string fileName)
        {
            string text = string.Empty;
            if (File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                fileStream.Close();
                text = Encoding.Default.GetString(array);
            }
            return text.Trim();
        }
    }
}
