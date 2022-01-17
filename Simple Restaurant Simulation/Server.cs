using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public class Server
    {
        Cook _cook = new Cook();
        MenuItem[][] _orders = new MenuItem[8][];
        int _orderCount;
        List<object> _preparedOrders = new List<object> { };

        public void TakeOrder(string chickenQuantity, string eggQuantity, string drink)
        {
            if (_orderCount < 8)
            {
                int.TryParse(chickenQuantity, out int _chickenQuantity);
                int.TryParse(eggQuantity, out int _eggQuantity);
                MenuItem[] order = new MenuItem[_chickenQuantity + _eggQuantity + 1];

                for (int i = 0; i < _chickenQuantity; i++)
                {
                    order[i] = MenuItem.Chicken;
                }
                for (int i = _chickenQuantity; i < _eggQuantity + _chickenQuantity; i++)
                {
                    order[i] = MenuItem.Egg;
                }
                order[_chickenQuantity + _eggQuantity] = (MenuItem)Enum.Parse(typeof(MenuItem), drink);
                _orders[_orderCount] = order;
                _orderCount++;
            }
            else
            {
                throw new InvalidOperationException("Only eight people may be seated at one table.");
            }
        }
        public string SendOrder()
        {
            string eggQuality = "";

            for (int order = 0; order < _orderCount; order++)
            {
                int chickenQuantity = 0;
                int eggQuantity = 0;
                foreach (MenuItem item in _orders[order])
                {
                    switch (item.ToString())
                    {
                        case "Chicken":
                            chickenQuantity++;
                            break;
                        case "Egg":
                            eggQuantity++;
                            break;
                    }
                }

                if (chickenQuantity > 0)
                {
                    _preparedOrders.Add((ChickenOrder)_cook.NewRequest(true, chickenQuantity));
                }
                if (eggQuantity > 0)
                {
                    _preparedOrders.Add((EggOrder)_cook.NewRequest(false, eggQuantity));
                    eggQuality += ", " + _cook.Inspect(_preparedOrders.Last());
                }
            }

            return eggQuality;
        }
        public string ServeFood()
        {
            string summary = "";

            for (int order = 0; order < _preparedOrders.Count(); order++)
            {
                summary += _cook.PrepareFood(_preparedOrders[order]) + $" for Customer {order}. ";
            }

            return summary;
        }
    }
}