namespace SolidPrinciples.LSP.Example2
{
    public class BrokenCar : Car
    {
        public BrokenCar(string color, bool hasFuel)
            : base(color, hasFuel)
        {
        }

        public override void StartEngine()
        {
        }
    }
}
