using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public abstract class MenuItem : ItemInterface
    {
        public void Request()
        {

        }
        public void Obtain()
        {

        }
        public abstract string Serve();
    }
}