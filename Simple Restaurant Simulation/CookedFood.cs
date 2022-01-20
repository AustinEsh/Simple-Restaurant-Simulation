using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public abstract class CookedFood : MenuItem
    {
        readonly int _quantity;

        public CookedFood(int quantity)
        {
            _quantity = quantity;
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }
        public void Cook()
        {

        }
        public void SubtractQuantity()
        {

        }
    }
}