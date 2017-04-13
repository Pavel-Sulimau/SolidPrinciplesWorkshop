namespace SolidPrinciples.LSP.Example2
{
    public class CrimeBossCar : Car
    {
        private readonly bool _hasBomb;

        public CrimeBossCar(string color, bool hasFuel, bool hasBomb)
            : base(color, hasFuel)
        {
            _hasBomb = hasBomb;
        }

        public override void StartEngine()
        {
            if (_hasBomb)
                throw new YouAreDeadException("Boom! You are dead!");

            base.StartEngine();
        }
    }
}
