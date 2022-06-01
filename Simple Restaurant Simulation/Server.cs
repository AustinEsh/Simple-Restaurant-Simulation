using System;

namespace Simple_Restaurant_Simulation
{
    public class Server
    {
        readonly Cook _cook = new Cook();
        TableRequests _tableRequests;
        int _customer;
        object[] _drinks = new object[8];

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
            string summary = "";

            for (int i = 0; i < _customer; i++)
            {
                string chicken = ((ChickenOrder)_tableRequests[i][0]).Serve();
                string egg = ((EggOrder)_tableRequests[i][1]).Serve();
                if (_tableRequests[i][2] is null)
                {
                    summary += $"{chicken} and {egg} for Customer {i}\n";
                }
                else
                {
                    string drink = ((Drink)_tableRequests[i][2]).Serve();
                    summary += $"{chicken}, {egg}, and {drink} for Customer {i}\n";
                }
            }

            _customer = 0;
            return summary;
        }
    }
}