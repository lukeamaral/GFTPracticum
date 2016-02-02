using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFTPracticum.Models;
using GFTPracticum.Exceptions;

namespace GFTPracticum.Tests
{
    [TestClass]
    public class OrderProcessorTest
    {
        OrderProcessor orderProcessor;

        public OrderProcessorTest()
        {
            orderProcessor = new OrderProcessor();

            DishList morningDishList = new DishList();
            DishList nightDishList = new DishList();

            morningDishList.Add(new Dish { Code = 1, Description = "eggs" });
            morningDishList.Add(new Dish { Code = 2, Description = "toast" });
            morningDishList.Add(new Dish { Code = 3, Description = "coffee", AllowMultiple = true });

            nightDishList.Add(new Dish { Code = 1, Description = "steak" });
            nightDishList.Add(new Dish { Code = 2, Description = "potato", AllowMultiple = true });
            nightDishList.Add(new Dish { Code = 3, Description = "wine" });
            nightDishList.Add(new Dish { Code = 4, Description = "cake" });

            orderProcessor.DishLists.Add("morning", morningDishList);
            orderProcessor.DishLists.Add("night", nightDishList);
        }

        [TestMethod]
        public void ProcessInputMorning123()
        {
            string input = "morning, 1, 2, 3";
            string expectedOutput = "eggs, toast, coffee";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputMorning213()
        {
            string input = "morning, 2, 1, 3";
            string expectedOutput = "eggs, toast, coffee";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputMorning1234()
        {
            string input = "morning, 1, 2, 3, 4";
            string expectedOutput = "eggs, toast, coffee, error";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputMorning12333()
        {
            string input = "morning, 1, 2, 3, 3, 3";
            string expectedOutput = "eggs, toast, coffee(x3)";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputNight1234()
        {
            string input = "night, 1, 2, 3, 4";
            string expectedOutput = "steak, potato, wine, cake";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputNight1224()
        {
            string input = "night, 1, 2, 2, 4";
            string expectedOutput = "steak, potato(x2), cake";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputNight1124()
        {
            string input = "night, 1, 1, 2, 4";
            string expectedOutput = "error";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputNightEmpty()
        {
            string input = "night";
            string expectedOutput = "error";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMealException))]
        public void ProcessInputInvalidMeal()
        {
            string input = "afternoon, 1, 2, 2, 4";

            orderProcessor.ProcessInput(input);
        }

        [TestMethod]
        public void ProcessInputCaseInsensitivity1()
        {
            string input = "Morning, 1, 2, 3";
            string expectedOutput = "eggs, toast, coffee";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }

        [TestMethod]
        public void ProcessInputCaseInsensitivity2()
        {
            string input = "MORNING, 1, 2, 3";
            string expectedOutput = "eggs, toast, coffee";

            Assert.AreEqual(expectedOutput, orderProcessor.ProcessInput(input));
        }
    }
}
