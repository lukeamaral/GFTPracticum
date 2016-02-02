using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFTPracticum.Models;

namespace GFTPracticum.Tests
{
    [TestClass]
    public class DishListTest
    {
        private IList<Dish> morningDishList;
        private IList<Dish> nightDishList;

        public DishListTest()
        {
            morningDishList = new DishList();
            morningDishList.Add(new Dish { Code = 1, Description = "eggs" });
            morningDishList.Add(new Dish { Code = 2, Description = "toast" });
            morningDishList.Add(new Dish { Code = 3, Description = "coffee", AllowMultiple = true });

            nightDishList = new DishList();
            nightDishList.Add(new Dish { Code = 1, Description = "steak" });
            nightDishList.Add(new Dish { Code = 2, Description = "potato", AllowMultiple = true });
            nightDishList.Add(new Dish { Code = 3, Description = "wine" });
            nightDishList.Add(new Dish { Code = 4, Description = "cake" });
        }

        #region Add dish Tests

        [TestMethod]
        public void AddDishOrdered()
        {
            int index;
            DishList list = new DishList();
            Assert.AreEqual(0, list.Count, "List count is incorrect");

            list.Add(nightDishList[1]);
            Assert.AreEqual(1, list.Count, "List count is incorrect");
            list.Add(nightDishList[2]);
            Assert.AreEqual(2, list.Count, "List count is incorrect");
            list.Add(nightDishList[3]);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.Add(nightDishList[4]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            
            for (index = 1; index <= 4; index++)
            {
                Assert.AreEqual(list[index], nightDishList[index]);
                Assert.IsTrue(list.Contains(nightDishList[index]));
            }
        }

        [TestMethod]
        public void AddDishInverseOrder()
        {
            int index;
            DishList list = new DishList();
            Assert.AreEqual(0, list.Count, "List count is incorrect");

            list.Add(nightDishList[4]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Add(nightDishList[3]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Add(nightDishList[2]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Add(nightDishList[1]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");

            for (index = 1; index <= 4; index++)
            {
                Assert.AreEqual(list[index], nightDishList[index]);
                Assert.IsTrue(list.Contains(nightDishList[index]));
            }
        }

        [TestMethod]
        public void AddDishMixedOrder()
        {
            int index;
            DishList list = new DishList();
            Assert.AreEqual(0, list.Count, "List count is incorrect");

            list.Add(nightDishList[3]);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.Add(nightDishList[2]);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.Add(nightDishList[4]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Add(nightDishList[1]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");

            for (index = 1; index <= 4; index++)
            {
                Assert.AreEqual(list[index], nightDishList[index]);
                Assert.IsTrue(list.Contains(nightDishList[index]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDishRepeatedCode()
        {
            DishList list = new DishList();

            list.Add(nightDishList[1]);
            list.Add(nightDishList[2]);
            list.Add(nightDishList[3]);
            list.Add(nightDishList[4]);
            list.Add(morningDishList[1]);
        }

        #endregion

        #region Foreach Tests

        [TestMethod]
        public void ForeachTest()
        {
            int index;
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            index = 1;
            foreach (Dish dish in list)
            {
                Assert.AreEqual(index, dish.Code, "Incorrect index");
                index++;
            }
        }

        #endregion

        #region Remove dish Tests

        [TestMethod]
        public void RemoveOrdered()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Assert.AreEqual(4, list.Count, "List count is incorrect");

            list.Remove(nightDishList[1]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Remove(nightDishList[2]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Remove(nightDishList[3]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Remove(nightDishList[4]);
            Assert.AreEqual(0, list.Count, "List count is incorrect");
        }

        [TestMethod]
        public void RemoveAtOrdered()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Assert.AreEqual(4, list.Count, "List count is incorrect");

            list.RemoveAt(1);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.RemoveAt(2);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.RemoveAt(3);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.RemoveAt(4);
            Assert.AreEqual(0, list.Count, "List count is incorrect");
        }

        [TestMethod]
        public void RemoveInverseOrder()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Assert.AreEqual(4, list.Count, "List count is incorrect");

            list.Remove(nightDishList[4]);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.Remove(nightDishList[3]);
            Assert.AreEqual(2, list.Count, "List count is incorrect");
            list.Remove(nightDishList[2]);
            Assert.AreEqual(1, list.Count, "List count is incorrect");
            list.Remove(nightDishList[1]);
            Assert.AreEqual(0, list.Count, "List count is incorrect");
        }

        [TestMethod]
        public void RemoveAtInverseOrder()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Assert.AreEqual(4, list.Count, "List count is incorrect");

            list.RemoveAt(4);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.RemoveAt(3);
            Assert.AreEqual(2, list.Count, "List count is incorrect");
            list.RemoveAt(2);
            Assert.AreEqual(1, list.Count, "List count is incorrect");
            list.RemoveAt(1);
            Assert.AreEqual(0, list.Count, "List count is incorrect");
        }

        [TestMethod]
        public void RemoveMixedOrder()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Assert.AreEqual(4, list.Count, "List count is incorrect");

            list.Remove(nightDishList[2]);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.Remove(nightDishList[4]);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.Remove(nightDishList[1]);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.Remove(nightDishList[3]);
            Assert.AreEqual(0, list.Count, "List count is incorrect");
        }

        [TestMethod]
        public void RemoveAtMixedOrder()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Assert.AreEqual(4, list.Count, "List count is incorrect");

            list.RemoveAt(2);
            Assert.AreEqual(4, list.Count, "List count is incorrect");
            list.RemoveAt(4);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.RemoveAt(1);
            Assert.AreEqual(3, list.Count, "List count is incorrect");
            list.RemoveAt(3);
            Assert.AreEqual(0, list.Count, "List count is incorrect");
        }

        #endregion

        #region Accessing Tests

        [TestMethod]
        public void AccessingNonExistingItemOnList()
        {
            int code;
            DishList list = new DishList();

            list.Add(nightDishList[1]);
            list.Add(nightDishList[2]);
            list.Add(nightDishList[4]);

            Assert.IsNotNull(list[1]);
            Assert.IsNotNull(list[2]);
            Assert.IsNull(list[3]);
            Assert.IsNotNull(list[4]);
            
            code = 1;
            foreach (Dish dish in list)
            {
                if (code == 3)
                {
                    Assert.IsNull(dish);
                    Assert.IsFalse(list.Contains(dish));
                }
                else
                {
                    Assert.IsNotNull(dish);
                    Assert.IsTrue(list.Contains(dish));
                    Assert.AreEqual(code, dish.Code, "Incorrect index");
                }
                code++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AccessingIndexOutOfBound()
        {
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            Dish dish = list[5];
        }

        #endregion

        #region Get dishes by input Tests

        [TestMethod]
        public void GetDishesByInputMorning123()
        {
            int[] input = { 1, 2, 3 };
            DishList list = new DishList();

            foreach (Dish item in morningDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[3], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInputMorning213()
        {
            int[] input = { 2, 1, 3 };
            DishList list = new DishList();

            foreach (Dish item in morningDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[3], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInputMorning1234()
        {
            int[] input = { 1, 2, 3, 4 };
            DishList list = new DishList();

            foreach (Dish item in morningDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[3], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.IsNull(enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInputMorning12333()
        {
            int[] input = { 1, 2, 3, 3, 3 };
            DishList list = new DishList();

            foreach (Dish item in morningDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[3], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[3], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(morningDishList[3], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInputNight1234()
        {
            int[] input = { 1, 2, 3, 4 };
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[3], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[4], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInputNight1224()
        {
            int[] input = { 1, 2, 2, 4 };
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[4], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInputNight1124()
        {
            int[] input = { 1, 1, 2, 4 };
            DishList list = new DishList();

            foreach (Dish item in nightDishList)
            {
                list.Add(item);
            }

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[2], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[4], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        [TestMethod]
        public void GetDishesByInput1234Empty2()
        {
            int[] input = { 1, 2, 3, 4 };
            DishList list = new DishList();

            list.Add(nightDishList[1]);
            list.Add(nightDishList[3]);
            list.Add(nightDishList[4]);

            var dishes = list.GetDishesByIndexArray(input);

            var enumarator = dishes.GetEnumerator();

            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[1], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.IsNull(enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[3], enumarator.Current);
            Assert.IsTrue(enumarator.MoveNext());
            Assert.AreEqual(nightDishList[4], enumarator.Current);
            Assert.IsFalse(enumarator.MoveNext());
        }

        #endregion
    }
}
