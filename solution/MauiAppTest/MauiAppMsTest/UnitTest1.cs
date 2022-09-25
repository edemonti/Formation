using MauiAppTest.Services;
using MauiAppTest.Validators;

namespace MauiAppMsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public  async void TestMethod1()
        {
            var lotService = new LotService(Connectivity.Current, new LotValidator());
            var list = await lotService.GetLots();
            Assert.IsTrue(list.Count>0);

        }
    }
}