using DataInter;

namespace DataImplement
{
    public class DataImp : DataInterface
    {
        public string TestData(string value)
        {
            return $"from data {value}";
        }
    }
}
