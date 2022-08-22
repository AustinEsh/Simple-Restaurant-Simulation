using System;
using System.Collections;
using System.Collections.Generic;

namespace Simple_Restaurant_Simulation
{
    public class TableRequests : IEnumerable<object>
    {
        Dictionary<string, object[]> _orders = new Dictionary<string, object[]>();

        public List<object> this[Type type]
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
                    if (item != null && i == type)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
        }
        public object[] this[string customer]
        {
            get
            {
                return new object[3] { _orders[customer][0], _orders[customer][1], _orders[customer][2] };
            }
        }

        public void Add<T>(string customer, T i)
        {
            try
            {
                if (!_orders.ContainsKey(customer))
                {
                    _orders[customer] = new object[3];
                }
                if (i is ChickenOrder)
                    _orders[customer][0] = i;
                else if (i is EggOrder)
                    _orders[customer][1] = i;
                else if (i is Drink)
                {
                    _orders[customer][2] = i;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Only eight customers may be seated at one table.");
            }
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            yield return _orders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
