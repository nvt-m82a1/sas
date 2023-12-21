﻿using SAS.Public.Def.Convert;
using ZTests.SAS.Public.ModelTemplateTests;
using ZTests.SAS.Public.ModelTests;

namespace ZTests.SAS.Public.Def.Convert
{
    [TestClass]
    public class ClassConvert
    {
        [TestMethod]
        public void Class_props()
        {
            var template = PropsTemplate.PropsValueSample;
            var bytes = DataConvert.Instance.ToBytes(template);
            var output = DataConvert.Instance.ToClass<PropsValue>(bytes);

            Assert.AreEqual(template.mbool, output.mbool);
            Assert.AreEqual(template.mbyte, output.mbyte);
            Assert.AreEqual(template.msbyte, output.msbyte);
            Assert.AreEqual(template.mchar, output.mchar);
            Assert.AreEqual(template.mdecimal, output.mdecimal);
            Assert.AreEqual(template.mdouble, output.mdouble);
            Assert.AreEqual(template.mfloat, output.mfloat);
            Assert.AreEqual(template.mint, output.mint);
            Assert.AreEqual(template.muint, output.muint);
            Assert.AreEqual(template.mlong, output.mlong);
            Assert.AreEqual(template.mshort, output.mshort);
            Assert.AreEqual(template.mushort, output.mushort);
            Assert.AreEqual(template.mstring, output.mstring);
            Assert.AreEqual(template.mdatetime, output.mdatetime);
            Assert.AreEqual(template.mguid, output.mguid);
        }
    }
}
