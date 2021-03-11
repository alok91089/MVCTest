using MVCDateApp.Controllers;
using NUnit.Framework;
using MVCDateApp.Helper;

namespace MVCDateApp.Test
{
    public class Tests
    {
        private IDateHelper _helper;
        [SetUp]
        public void Setup()
        {
            _helper = new DateHelper();
        }

        [Test]
        public void Test1()
        {
            //int diff = _helper.GetDifference("11/02/2021", "11/03/2021");
            Assert.AreEqual(1, _helper.GetDifference("11/02/2021", "11/03/2021"));
            Assert.AreEqual(29, _helper.GetDifference("11/02/2021", "12/01/2021"));
            Assert.AreEqual(60, _helper.GetDifference("10/02/2021", "12/01/2021"));
            Assert.AreEqual(2203, _helper.GetDifference("03/15/2016", "03/27/2022"));

            //int diff = _helper.GetDifference("11/02/2021", "11/03/2021");
        }
    }
}