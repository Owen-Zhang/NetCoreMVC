using KJT.WebFrameWork.Common;

namespace DataInter
{
    public interface DataInterface : IDependency
    {
        string TestData(string value);
    }
}
