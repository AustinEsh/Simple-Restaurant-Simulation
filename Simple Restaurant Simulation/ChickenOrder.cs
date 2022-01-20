using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials.UI;

namespace Simple_Restaurant_Simulation
{
    public sealed class ChickenOrder : CookedFood
    {
        public ChickenOrder(int quantity)
            : base(quantity)
        {

        }

        public void CutUp()
        {

        }
        public override string Serve()
        {
            return "chicken";
        }
    }
}
