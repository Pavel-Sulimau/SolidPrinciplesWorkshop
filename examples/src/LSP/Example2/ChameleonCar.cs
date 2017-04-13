namespace SolidPrinciples.LSP.Example2
{
    // http://www.dailymail.co.uk/sciencetech/article-2451931/Car-colour-heat-sensitive-paint-changes-depending-weather.html
    public class ChameleonCar : Car
    {
        private readonly string _color;

        public ChameleonCar(string color, bool hasFuel)
            : base(color, hasFuel)
        {
            _color = color;
        }

        public ChameleonCar SetTemperature(int temperature)
        {
            Color = (temperature > 20) ? _color : "Black";

            return this;
        }
    }
}
