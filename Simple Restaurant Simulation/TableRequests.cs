using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public class TableRequests
    {
        object[][] _orders = new object[8][];

        public List<object> this[Type type]
        {
            get
            {
                List<object> items = new List<object> { };
                foreach (object[] order in _orders)
                {
                    foreach (var item in order)
                    {
                        if (item.GetType() == type)
                        {
                            items.Add(item);
                        }
                    }
                }

                return items;
            }
        }
        public object[] this[int customer]
        {
            get
            {
                return _orders[customer];
            }
        }

        public void Add(int customer, ItemInterface i)
        {
            _orders[0][0] = i;
        }
    }
}
