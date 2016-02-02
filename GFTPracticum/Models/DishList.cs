using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTPracticum.Models
{
    public class DishList : IList<Dish>
    {
        private IDictionary<int, Dish> dishes;

        #region IList properties

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return dishes.IsReadOnly;
            }
        }

        public Dish this[int index]
        {
            get
            {
                if (dishes.ContainsKey(index))
                {
                    return dishes[index];
                }
                else if (index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    dishes[index] = value;
                }
            }
        }

        #endregion

        public DishList()
        {
            dishes = new Dictionary<int, Dish>();
            Count = 0;
        }

        #region IList methods

        public int IndexOf(Dish item)
        {
            return item.Code;
        }

        public void Insert(int index, Dish item)
        {
            Add(item);
        }

        public void RemoveAt(int index)
        {
            dishes.Remove(index);

            checkCountAfterRemove();
        }

        public void Add(Dish item)
        {
            if (dishes.ContainsKey(item.Code))
            {
                throw new ArgumentException("A dish with the same code has already been added");
            }
            else if (item.Code <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                dishes.Add(item.Code, item);
                if (Count < item.Code)
                {
                    Count = item.Code;
                }
            }
        }

        public void Clear()
        {
            dishes.Clear();
        }

        public bool Contains(Dish item)
        {
            return item != null && item.Equals(dishes[item.Code]);
        }

        public void CopyTo(Dish[] array, int arrayIndex)
        {
            dishes.Values.CopyTo(array, arrayIndex);
        }

        public bool Remove(Dish item)
        {
            bool result = dishes.Remove(item.Code);

            checkCountAfterRemove();

            return result;
        }

        public IEnumerator<Dish> GetEnumerator()
        {
            for (int index = 1; index <= Count; index++)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 1; index <= Count; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        private void checkCountAfterRemove()
        {
            for (int index = Count; index > 0; index--)
            {
                if (this[index] != null)
                {
                    Count = index;
                    return;
                }
            }

            Count = 0;
        }

        public IEnumerable<Dish> GetDishesByIndexArray(int[] array)
        {
            foreach (int index in array.OrderBy(x => x))
            {
                if (dishes.ContainsKey(index))
                {
                    yield return this[index];
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}
