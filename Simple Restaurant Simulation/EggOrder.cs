using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials.UI;

namespace Simple_Restaurant_Simulation
{
    public class EggOrder
    {
        public int _quantity;
        public int _quality;
        static bool checkQuality;

        public EggOrder(int quantity)
        {
            _quantity = quantity;
            Random rand = new Random();
            _quality = rand.Next(101);
            checkQuality = !checkQuality;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public int? GetQuality()
        {
            if (checkQuality)
            {
                return _quality;
            }

            return null;
        }

        public void Crack()
        {
            if (_quality < 25)
            {
                throw new InvalidOperationException("The eggs are rotten.");
            }
        }

        public void DiscardShell()
        {

        }

        public void Cook()
        {

        }
    }
}
