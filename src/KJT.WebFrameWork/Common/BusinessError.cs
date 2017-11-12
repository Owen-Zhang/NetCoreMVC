using System;

namespace KJT.WebFrameWork.Common
{
    public class BusinessError : Exception
    {
        public BusinessError(string message) :base(message)
        {

        }
    }
}
