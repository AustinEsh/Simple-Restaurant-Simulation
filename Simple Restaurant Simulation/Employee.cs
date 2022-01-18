using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace Simple_Restaurant_Simulation
{
    public class Cook
    {
        object _order;

        public object NewRequest(bool? isChicken, int quantity)
        {
            if (isChicken == true)
            {
                _order = new ChickenOrder(quantity);
                return _order;
            }
            else
            {
                _order = new EggOrder(quantity);
                return _order;
            }
        }
<<<<<<< HEAD
        public object CopyRequest()
        {
            if (_order is ChickenOrder chickenOrder)
            {
                return chickenOrder;
            }
            else
            {
                EggOrder order = (EggOrder)_order;
                EggOrder newOrder = new EggOrder(order._quantity);
                newOrder._quality = order._quality;
                return newOrder;
            }
        }
=======
>>>>>>> srs2
        public string PrepareFood(object order)
        {
            if (order is ChickenOrder)
            {
                ChickenOrder chickenOrder = (ChickenOrder)order;
                int quantity = chickenOrder.GetQuantity();
                for (int i = 0; i < quantity; i++)
                {
                    chickenOrder.CutUp();
                }

                chickenOrder.Cook();

                return quantity.ToString() + " chicken";
            }
            else
            {
                EggOrder eggOrder = (EggOrder)order;
                int quantity = eggOrder.GetQuantity();
                for (int i = 0; i < quantity; i++)
                {
                    eggOrder.Crack();
                    eggOrder.DiscardShell();
                }

                eggOrder.Cook();

                return quantity.ToString() + " egg";
            }
        }
        public string Inspect(object eggOrder)
        {
            return ((EggOrder)eggOrder).GetQuality().ToString();
        }
    }
}
