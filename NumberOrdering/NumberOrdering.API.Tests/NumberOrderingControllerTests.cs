using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOrdering.API.Controllers;

namespace NumberOrdering.API.Tests
{
    [TestClass]
    public class NumberOrderingControllerTests
    {
        [TestMethod]
        public async Task Order_ValidNumbers_OkObjectResult()
        {
            // arrange
            var stubNumbers = new int[] { 5, 2, 8, 10, 1 };
            var controller = new NumberOrderingController();

            // act
            IActionResult result = await controller.Order(stubNumbers);
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task Order_LessThanOne_BadRequestResult()
        {
            // arrange
            var stubNumbers = new int[] { 5, -2, 8, 10, -1, 0 };
            var controller = new NumberOrderingController();

            // act
            IActionResult result = await controller.Order(stubNumbers);
            var badResult = result as BadRequestResult;

            // assert
            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [TestMethod]
        public async Task Order_BiggerThanTen_BadRequestResult()
        {
            // arrange
            var stubNumbers = new int[] { 5, 2, 8, 11, 12 };
            var controller = new NumberOrderingController();

            // act
            IActionResult result = await controller.Order(stubNumbers);
            var badResult = result as BadRequestResult;

            // assert
            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [TestMethod]
        public async Task Order_NotDistinct_BadRequestResult()
        {
            // arrange
            var stubNumbers = new int[] { 5, 2, 2, 8, 10, 10, 1 };
            var controller = new NumberOrderingController();

            // act
            IActionResult result = await controller.Order(stubNumbers);
            var badResult = result as BadRequestResult;

            // assert
            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [TestMethod]
        public async Task Order_Null_BadRequestResult()
        {
            // arrange
            var controller = new NumberOrderingController();

            // act
            IActionResult result = await controller.Order(null);
            var badResult = result as BadRequestResult;

            // assert
            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [TestMethod]
        public async Task Order_EmptyArray_BadRequestResult()
        {
            // arrange
            var stubNumbers = new int[]{};
            var controller = new NumberOrderingController();

            // act
            IActionResult result = await controller.Order(stubNumbers);
            var badResult = result as BadRequestResult;

            // assert
            Assert.IsNotNull(badResult);
            Assert.AreEqual(400, badResult.StatusCode);
        }
    }
}
