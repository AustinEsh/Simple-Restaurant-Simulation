using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials.UI;

namespace Simple_Restaurant_Simulation
{
    public class ChickenOrder
    {
        public int _quantity;
       
        public ChickenOrder(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
        public void CutUp()
        {

        }
        public void Cook()
        {

        }
    }
}
