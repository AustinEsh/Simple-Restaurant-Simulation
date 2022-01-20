using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public interface ItemInterface
    {
        void Request();
        void Obtain();
        string Serve();
    }
}
