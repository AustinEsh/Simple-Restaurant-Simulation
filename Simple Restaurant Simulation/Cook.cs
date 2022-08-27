﻿using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Simple_Restaurant_Simulation
{
    public class Cook
    {
        public delegate string OrdersPreparedEventHandler();
        public event OrdersPreparedEventHandler OrdersPrepared;
        public string OnOrdersTaken(TableRequests requests)
        {
            List<object> chickenItems = requests[typeof(ChickenOrder)];
            List<object> eggItems = requests[typeof(EggOrder)];
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

            return OrdersPrepared();
        }
    }
}
