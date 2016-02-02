using GFTPracticum.Exceptions;
using GFTPracticum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTPracticum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output;
            OrderProcessor orderProcessor = new OrderProcessor();
            InitializeOrderProcessor(orderProcessor);

            for (;;)
            {
                Console.Write("Input: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                output = null;
                try
                {
                    output = orderProcessor.ProcessInput(input);
                }
                catch (InvalidMealException)
                {
                    Console.WriteLine("Invalid meal. Valid options are: morning and night");
                }

                if (output != null)
                {
                    Console.Write("Output: ");
                    Console.WriteLine(output);
                }

                Console.WriteLine();
            }
        }

        private static void InitializeOrderProcessor(OrderProcessor orderProcessor)
        {
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
    }
}
