using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOrdering.API.Services;

namespace NumberOrdering.API.Tests
{
    [TestClass]
    public class NumberOrderingServiceTests
    {
        [TestMethod]
        public void Order_ValidNumbers_OrderedNumbers()
        {
            var stubNumbers = new int[] { 5, 2, 8, 10, 1 };
            var expectedNumbers = new int[] { 1, 2, 5, 8, 10 };

            var service = new NumberOrderingService(stubNumbers);

            service.Order();

            CollectionAssert.AreEqual(expectedNumbers, service.Numbers);
        }
    }
}
