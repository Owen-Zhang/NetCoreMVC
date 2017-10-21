using Autofac;

namespace NetCore2MVC.Common
{
    public class AutofacProvider
    {
        static IContainer container = null;

        AutofacProvider()
        {
        }

        /// <summary>
        /// 这个方法不要乱去设置(程序初始化注入)
        /// </summary>
        public static IContainer Container
        {
            set
            {
                container = value;
            }
        }

        /// <summary>
        /// 通过接口去获取相应的类实例
        /// </summary>
        public static T GetService<T>()
        {
            return container.Resolve<T>();
        }
    }
}
