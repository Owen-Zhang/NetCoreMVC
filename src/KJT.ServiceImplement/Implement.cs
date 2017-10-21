using DataInter;
using KJT.ServiceInterface;

namespace KJT.ServiceImplement
{
    public class Implement : Inter
    {
        public readonly DataInterface data;

        public Implement(DataInterface data)
        {
            this.data = data;
        }
        public string TestInterfaceInfo(string input)
        {
            return string.Format("iocData from {0}", data.TestData(input));
        }
    }
}
