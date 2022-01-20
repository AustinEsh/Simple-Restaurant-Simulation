using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace Simple_Restaurant_Simulation
{
    public class Cook
    {
        object _order;

        public void Process(TableRequests requests)
        {
            foreach (ChickenOrder item in requests[typeof(ChickenOrder)])
            {
                item.Obtain();
                for (int i = 0; i < item.Quantity; i++)
                {
                    item.CutUp();
                }
                item.Cook();
            }
            foreach (EggOrder item in requests[typeof(EggOrder)])
            {
                item.Obtain();
                item.Crack();
                item.Cook();
            }
        }
        public string Inspect(object eggOrder)
        {
            return ((EggOrder)eggOrder).Quality.ToString();
        }
    }
}
