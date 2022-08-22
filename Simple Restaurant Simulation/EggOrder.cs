using System;

namespace Simple_Restaurant_Simulation
{
    public sealed class EggOrder : CookedFood, IDisposable
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
            return $"{this.Quantity} egg";
        }

        void IDisposable.Dispose()
        {
            DiscardShell();
        }
    }
}
