using KJT.WebFrameWork.Utility;

namespace KJT.WebFrameWork.Cookie
{
    public class CookieConfig
    {
        private const string COOKIE_CONFIG_FILE_PATH = "Configuration/Cookie.config";
        private const string COOKIE_CONFIG_FILE_PATH_NODE_NAME = "CookieConfigPath";

        /// <summary>
        /// 根据配制节点去相关的Cookie信息
        /// </summary>
        public static T GetCookieConfig<T>(string nodeName) where T : class, new()
        {
            //string path = ConfigurationManager.AppSettings[COOKIE_CONFIG_FILE_PATH_NODE_NAME];
            //if (string.IsNullOrWhiteSpace(path))
            //{
              //  path = COOKIE_CONFIG_FILE_PATH;
           // }

            T result = default(T);

            //FileUtil.ReadFileText()

            return result;
        }
    }
}
