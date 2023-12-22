using SAS.Public.Def.Convert;
using SAS.Public.Def.Data;
using SAS.Public.Def.Extensions;
using ZTests.SAS.Public.ModelTests;

namespace ZTests.SAS.Public.Def.Extensions
{
    [TestClass]
    public class PropsCompareClass
    {
        [TestMethod]
        public void Props_fill_min()
        {
            var propsValue = new PropsValue();
            DataRandom.Instance.FillPropsMin(propsValue);

            var bytes = DataConvert.Instance.ToBytes(propsValue);
            var propsValueRended = DataConvert.Instance.ToClass<PropsValue>(bytes);
            var compare = PropsCompare.Compare(propsValue, propsValueRended);
            Assert.IsTrue(compare.same);
        }

        [TestMethod]
        public void Props_fill_max()
        {
            var propsValue = new PropsValue();
            DataRandom.Instance.FillPropsMax(propsValue);

            var bytes = DataConvert.Instance.ToBytes(propsValue);
            var propsValueRended = DataConvert.Instance.ToClass<PropsValue>(bytes);
            var compare = PropsCompare.Compare(propsValue, propsValueRended);
            Assert.IsTrue(compare.same);
        }

        [TestMethod]
        public void Props_fill_random()
        {
            var propsValue = new PropsValue();
            DataRandom.Instance.FillPropsRandom(propsValue);

            var bytes = DataConvert.Instance.ToBytes(propsValue);
            var propsValueRended = DataConvert.Instance.ToClass<PropsValue>(bytes);
            var compare = PropsCompare.Compare(propsValue, propsValueRended);
            Assert.IsTrue(compare.same);
        }
    }
}
