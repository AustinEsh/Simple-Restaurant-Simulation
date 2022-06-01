using System;

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
            using (EggShell shell = new EggShell())
            {
                ((IDisposable)shell).Dispose();
            }
        }
        public override string Serve()
        {
            return $"{this.Quantity} egg";
        }
    }
}
