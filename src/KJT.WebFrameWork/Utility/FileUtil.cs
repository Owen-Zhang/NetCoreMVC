using System;
using System.IO;

namespace KJT.WebFrameWork.Utility
{
    public class FileUtil
    {
        /// <summary>
        /// 读取文件文本内容
        /// </summary>
        public static string ReadFileText(string filePath)
        {
            string p = Path.GetPathRoot(filePath);
            if (p == null || p.Trim().Length <= 0)
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            try
            {
                return File.ReadAllText(filePath).Trim();
            }
            catch (Exception e)
            {
                //记录日志
                return string.Empty;
            }
        }
    }
}
