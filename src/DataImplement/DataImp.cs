using DataInter;
using KJT.Resouce;

namespace DataImplement
{
    public class DataImp : DataInterface
    {
        public string TestData(string value)
        {
            var value1 = Message.key;
            var value2 = Message.adsfafdasdf;
            return $"from data {value}";
        }
    }
}
