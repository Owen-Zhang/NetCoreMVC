using Microsoft.Extensions.Configuration;
using System;

namespace KJT.WebFrameWork.Common
{
    public class ConfigurationManager
    {
        public static IConfiguration ConfigurationT;

        /// <summary>
        /// 如：xxx:aaa节点
        /// </summary>
        public static T GetData<T>(string configPath) where T : class, new()
        {
            var result = default(T);
            if (ConfigurationT == null)
                return result;

            return ConfigurationT.GetSection(configPath).Get<T>();
        }

        /// <summary>
        /// 如：xxx:aaa节点, 获取单个节点的值
        /// </summary>
        public static string GetValue(string configPath)
        {
            return ConfigurationT[configPath];
        }
    }
}
