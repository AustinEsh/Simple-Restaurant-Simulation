﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Restaurant_Simulation
{
    public sealed class Tea : Drink
    {
        public override string Serve()
        {
            return "tea";
        }
    }
}
