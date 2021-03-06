using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Simple_Restaurant_Simulation
{
    public class Cook
    {

        public void Process(TableRequests requests)
        {
            List<object> chickenItems = requests[new ChickenOrder(1)];
            List<object> eggItems = requests[new EggOrder(1)];
            foreach (ChickenOrder item in chickenItems)
            {
                item.Obtain();
                for (int i = 0; i < item.Quantity; i++)
                {
                    item.CutUp();
                }
                item.Cook();
            }
            foreach (EggOrder item in eggItems)
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
