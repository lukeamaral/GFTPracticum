using GFTPracticum.Exceptions;
using GFTPracticum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTPracticum
{
    public class OrderProcessor
    {
        public IDictionary<string, DishList> DishLists { get; private set; }

        public OrderProcessor()
        {
            DishLists = new Dictionary<string, DishList>();
        }

        public string ProcessInput(string input)
        {
            string[] inputArray = input.Split(',');

            string key = inputArray[0].ToLowerInvariant();

            if (!DishLists.ContainsKey(key))
            {
                throw new InvalidMealException();
            }

            DishList dishList = DishLists[key];
            
            var indexes = from s in inputArray.Skip(1)
                          select int.Parse(s.Trim());

            var dishes = dishList.GetDishesByIndexArray(indexes.ToArray());

            var groupedDishes = from dish in dishes
                                group dish by dish into repeatedDish
                                let count = repeatedDish.Count()
                                select repeatedDish.Key == null ? "error" :
                                       (count == 1 ? repeatedDish.Key.Description :
                                       (repeatedDish.Key.AllowMultiple ? string.Format("{0}(x{1})", repeatedDish.Key.Description, count) :
                                        "error"));

            string output = JoinDishesDescription(groupedDishes);

            return string.IsNullOrEmpty(output) ? "error" : output;
        }

        private static string JoinDishesDescription(IEnumerable<string> descriptions)
        {
            StringBuilder output = new StringBuilder();
            bool addComma = false;

            foreach (string description in descriptions)
            {
                if (addComma)
                {
                    output.Append(", ");
                }
                else
                {
                    addComma = true;
                }

                output.Append(description);

                if ("error".Equals(description))
                {
                    break;
                }
            }

            return output.ToString();
        }
    }
}
