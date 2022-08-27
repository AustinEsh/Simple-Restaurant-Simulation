using System;
using System.Collections.Generic;

namespace Simple_Restaurant_Simulation
{
    public class Server
    {
        public TableRequests _tableRequests;
        string[] _customers = new string[8];
        int _customerCount = 0;

        public void TakeOrder(string name, int chickenQuantity, int eggQuantity, string drink)
        {
            if (_customerCount == 0)
            {
                _tableRequests = new TableRequests();
            }

            _tableRequests.Add(name, new ChickenOrder(chickenQuantity));
            _tableRequests.Add(name, new EggOrder(eggQuantity));
            ItemInterface _drink;
            switch (drink)
            {
                case "Coffee":
                    _drink = new Coffee();
                    break;
                case "Tea":
                    _drink = new Tea();
                    break;
                case "Water":
                    _drink = new Water();
                    break;
                case "ChocolateMilk":
                    _drink = new ChocolateMilk();
                    break;
                case "JockoFuel":
                    _drink = new JockoFuel();
                    break;
                default:
                    _drink = null;
                    break;
            }
            _tableRequests.Add(name, _drink);
            _customers[_customerCount] = name;
        }
        public delegate string OrdersTakenEventHandler(TableRequests _tableRequests);
        public event OrdersTakenEventHandler OrdersTaken;
        public string SendOrder()
        {
            if (_customers.Length > 0)
            {
                return OnOrdersTaken(_tableRequests);
            }
            else
            {
                throw new InvalidOperationException("There are no orders to send to the cook.");
            }
        }
        //protected virtual string OnOrdersTaken(TableRequests _tableRequests)
        //{
        //    if (OrdersTaken != null)
        //    {
        //        return OrdersTaken(_tableRequests);
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        public string OnOrdersPrepared()
        {
            string summary = "";

            for (int i = 0; i < 8; i++)
            {
                if (_customers[i] is null)
                {
                    break;
                }

                object[] order = _tableRequests[_customers[i]];
                EggOrder eggObj = (EggOrder)order[1];
                string chicken = ((ChickenOrder)order[0]).Serve();
                string egg = eggObj.Serve();
                if (order[2] is null)
                {
                    summary += $"{chicken} and {egg} for {_customers[i]}\n";
                }
                else
                {
                    string drink = ((Drink)order[2]).Serve();
                    summary += $"{chicken}, {egg}, and {drink} for {_customers[i]}\n";
                }

                ((IDisposable)eggObj).Dispose();

                _customers[i] = null;
            }
            return summary;
        }
    }
}