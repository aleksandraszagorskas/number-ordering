using System;
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
            //arrange
            var stubNumbers = new int[] { 5, 2, 8, 10, 1 };
            var expectedNumbers = new int[] { 1, 2, 5, 8, 10 };
            var service = new NumberOrderingService(stubNumbers);

            //act
            service.Order();

            //assert
            CollectionAssert.AreEqual(expectedNumbers, service.Numbers);
        }

        [TestMethod]
        public void Order_LessThanOne_OrderedNumbers()
        {
            //arrange
            var stubNumbers = new int[] { 5, -2, 8, 10, -1, 0 };
            var expectedNumbers = new int[] { -2, -1, 0, 5, 8, 10 };
            var service = new NumberOrderingService(stubNumbers);

            //act
            service.Order();

            //assert
            CollectionAssert.AreEqual(expectedNumbers, service.Numbers);
        }

        [TestMethod]
        public void Order_BiggerThanTen_OrderedNumbers()
        {
            //arrange
            var stubNumbers = new int[] { 5, 2, 8, 11, 12 };
            var expectedNumbers = new int[] { 2, 5, 8, 11, 12 };
            var service = new NumberOrderingService(stubNumbers);

            //act
            service.Order();

            //assert
            CollectionAssert.AreEqual(expectedNumbers, service.Numbers);
        }

        [TestMethod]
        public void Order_NotDistinct_OrderedNumbers()
        {
            //arrange
            var stubNumbers = new int[] { 5, 2, 8, 10, 1, 10, 5 };
            var expectedNumbers = new int[] { 1, 2, 5, 5, 8, 10, 10 };
            var service = new NumberOrderingService(stubNumbers);

            //act
            service.Order();

            //assert
            CollectionAssert.AreEqual(expectedNumbers, service.Numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Order_Null_ArgumentNullException()
        {
            var service = new NumberOrderingService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Order_EmptyArray_ArgumentException()
        {
            var stubNumbers = new int[] { };
            var service = new NumberOrderingService(stubNumbers);
        }
    }
}
