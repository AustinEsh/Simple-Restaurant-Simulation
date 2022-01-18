using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public class Order
    {
        int _quantity;

        public Order(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
        public void Cook()
        {

        }
        public void SubtractQuantity()
        {

        }
    }
}
