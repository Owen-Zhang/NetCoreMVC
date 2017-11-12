namespace NetCore2MVC.Common
{
    public class AjaxResult
    {
        /// <summary>
        /// 是否成功的标志(１成功，０失败)
        /// </summary>
        public int Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public AjaxResult()
        {
            Status = 1;
            Message = string.Empty;
            Data = null;
        }
    }
}
