using ZTests.SAS.Public.ModelTests;

namespace ZTests.SAS.Public.ModelTemplateTests
{
    public class PropsTemplate
    {
        public static PropsValue PropsValueSample = new PropsValue()
        {
            mbool = true,
            mbyte = 1,
            msbyte = 2,
            mchar = '3',
            mdecimal = 4.1578558m,
            mdouble = 5.2554d,
            mfloat = 6.3545748f,
            mint = 7,
            mlong = 8,
            mshort = 9,
            mushort = 10,

            mstring = "5s4ad65f55d",
            mguid = Guid.NewGuid(),
            mdatetime = DateTime.Now,
        };
    }
}
