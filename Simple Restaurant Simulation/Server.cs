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
        object[,] _preparedOrders;

        public void TakeOrder(string chickenQuantity, string eggQuantity, string drink)
        {
            if (_orderCount < 8)
            {
                int _chickenQuantity = 0;
                int _eggQuantity = 0;

                int.TryParse(chickenQuantity, out _chickenQuantity);
                int.TryParse(eggQuantity, out _eggQuantity);
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
            if (_orderCount > 0)
            {
                object[,] preparedOrders = new object[_orderCount, 3];
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

                    preparedOrders[order, 0] = ((ChickenOrder)_cook.NewRequest(true, chickenQuantity));
                    preparedOrders[order, 1] = ((EggOrder)_cook.NewRequest(false, eggQuantity));
                    if (eggQuantity > 0)
                    {
                        if (order > 0)
                            eggQuality += ", ";
                        eggQuality += _cook.Inspect(preparedOrders[order, 1]);
                    }
                    preparedOrders[order, 2] = _orders[order][_orders[order].Length - 1];
                }

                _preparedOrders = preparedOrders;
                _orderCount = 0;
                Array.Clear(_orders, 0, _orders.Length);
                return eggQuality;
            }
            else
            {
                throw new InvalidOperationException("There are no orders to send to the cook.");
            }
        }
        public string ServeFood()
        {
            try
            {
                string summary = "";

                for (int order = 0; order < _preparedOrders.GetLength(0); order++)
                {
                    string drink = "no drink";
                    switch (_preparedOrders[order, 2])
                    {
                        case MenuItem.ChocolateMilk:
                            drink = "Chocolate Milk";
                            break;
                        case MenuItem.Coffee:
                            drink = "Coffee";
                            break;
                        case MenuItem.JockoFuel:
                            drink = "Jocko Fuel";
                            break;
                        case MenuItem.Tea:
                            drink = "Tea";
                            break;
                        case MenuItem.Water:
                            drink = "Water";
                            break;
                        default:
                            drink = "no drink";
                            break;
                    }

                    summary += _cook.PrepareFood(_preparedOrders[order, 0]) + ", " + _cook.PrepareFood(_preparedOrders[order, 1]) + " and " + drink + $" for Customer {order}\n";
                }

                Array.Clear(_preparedOrders, 0, _preparedOrders.Length);
                return summary;
            }
            catch
            {
                throw new InvalidOperationException("There are no prepared orders to serve.");
            }
        }
    }
}