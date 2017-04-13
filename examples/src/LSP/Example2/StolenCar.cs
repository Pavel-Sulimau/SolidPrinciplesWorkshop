namespace SolidPrinciples.LSP.Example2
{
    public class StolenCar : Car
    {
        private bool _ignitionWiresStripped;

        public StolenCar(string color, bool hasFuel)
            : base(color, hasFuel)
        {
        }

        public void StripIgnitionWires()
        {
            _ignitionWiresStripped = true;
        }

        public override void StartEngine()
        {
            if (!_ignitionWiresStripped)
                return;

            base.StartEngine();
        }
    }
}
