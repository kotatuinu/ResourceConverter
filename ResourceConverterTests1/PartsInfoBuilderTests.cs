using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceConverter.Tests
{
    [TestClass()]
    public class PartsInfoBuilderTests
    {
        [TestMethod()]
        public void GetPartsInfoTest_引数無し()
        {
            PartsInfoBuilder instance = new PartsInfoBuilder();
            var result = instance.GetPartsInfo();

            Assert.IsTrue(result.GetType() == typeof(PartsInfoForm));
        }

        [TestMethod()]
        public void GetPartsInfoTest_引数UNKNOWN()
        {
            PartsInfoBuilder instance = new PartsInfoBuilder();
            var result = instance.GetPartsInfo(PartsInfo.RESOURCE_STATUE.UNKNOWN);

            Assert.IsTrue(result.GetType() == typeof(PartsInfoForm));
        }

        [TestMethod()]
        public void GetPartsInfoTest_引数FORM()
        {
            PartsInfoBuilder instance = new PartsInfoBuilder();
            var result = instance.GetPartsInfo(PartsInfo.RESOURCE_STATUE.FORM);

            Assert.IsTrue(result.GetType() == typeof(PartsInfoFormParams));
        }

        [TestMethod()]
        public void GetPartsInfoTest_引数FORMPARTS()
        {
            PartsInfoBuilder instance = new PartsInfoBuilder();
            var result = instance.GetPartsInfo(PartsInfo.RESOURCE_STATUE.FORMPARTS);

            Assert.IsTrue(result.GetType() == typeof(PartsInfoFormParts));
        }
    }
}