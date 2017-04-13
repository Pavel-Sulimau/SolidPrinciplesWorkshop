namespace SolidPrinciples.LSP.Example2
{
    public class Car
    {
        private bool _hasFuel;

        public Car(string color = "Black", bool hasFuel = true)
        {
            _hasFuel = hasFuel;
            Color = color;
        }

        public bool IsEngineRunning { get; private set; }

        public string Color { get; protected set; }

        /// <exception cref="OutOfFuelException">A car has no fuel.</exception>
        public virtual void StartEngine()
        {
            if (!_hasFuel)
                throw new OutOfFuelException("Can't start a car without gas in tank...");

            IsEngineRunning = true;
        }

        public virtual void StopEngine()
        {
            IsEngineRunning = false;
        }
    }
}
