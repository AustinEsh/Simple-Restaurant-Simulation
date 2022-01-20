using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials.UI;

namespace Simple_Restaurant_Simulation
{
    public sealed class EggOrder : CookedFood
    {
        readonly int _quality;

        public EggOrder(int quantity)
            : base(quantity)
        {
            Random rand = new Random();
            _quality = rand.Next(101);
        }

        public int Quality
        {
            get
            {
                return _quality;
            }
        }
        public void Crack()
        {

        }
        public void DiscardShell()
        {

        }
        public override string Serve()
        {
            return "egg";
        }
    }
}
