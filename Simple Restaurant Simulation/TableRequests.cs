using System;
using System.Collections.Generic;

namespace Simple_Restaurant_Simulation
{
    public class TableRequests
    {
        object[,] _orders = new object[8, 3];

        public List<object> this[ItemInterface type]
        {
            get
            {
                List<object> items = new List<object> { };
                foreach (object item in _orders)
                {
                    if (item is null)
                    {
                        break;
                    }
                    Type i = item.GetType();
                    if (item != null && i == type.GetType())
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
        }
        public object[] this[int customer]
        {
            get
            {
                return new object[3] { _orders[customer, 0], _orders[customer, 1], _orders[customer, 2] };
            }
        }

        public void Add(int customer, ItemInterface i)
        {
            try
            {
                if (i is ChickenOrder)
                    _orders[customer, 0] = i;
                else if (i is EggOrder)
                    _orders[customer, 1] = i;
                else if (i is Drink)
                {
                    _orders[customer, 2] = i;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Only eight customers may be seated at one table.");
            }
        }
    }
}
