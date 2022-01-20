using System;
using System.Collections.Generic;

namespace Simple_Restaurant_Simulation
{
    public class Server
    {
        readonly Cook _cook = new Cook();
        TableRequests _tableRequests;
        int _customer;

        public void TakeOrder(int chickenQuantity, int eggQuantity, string drink)
        {
            if (_customer == 0)
            {
                _tableRequests = new TableRequests();
            }

            _tableRequests.Add(_customer, new ChickenOrder(chickenQuantity));
            _tableRequests.Add(_customer, new EggOrder(eggQuantity));
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
                case "Chocolate Milk":
                    _drink = new ChocolateMilk();
                    break;
                case "Jocko Fuel":
                    _drink = new JockoFuel();
                    break;
                default:
                    _drink = null;
                    break;
            }
            _tableRequests.Add(_customer, _drink);

            _customer++;
        }
        public void SendOrder()
        {
            if (_customer > 0)
            {
                _cook.Process(_tableRequests);
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

                for (int i = 0; i < _customer; i++)
                {
                    string chicken = ((ChickenOrder)_tableRequests[i][0]).Serve();
                    string egg = ((EggOrder)_tableRequests[i][1]).Serve();
                    string drink = ((Drink)_tableRequests[i][2]).Serve();
                    summary += $"{chicken}, {egg} and {drink} for Customer {i}\n";
                }

                return summary;
            }
            catch
            {
                throw new InvalidOperationException("There are no prepared orders to serve.");
            }
        }
    }
}