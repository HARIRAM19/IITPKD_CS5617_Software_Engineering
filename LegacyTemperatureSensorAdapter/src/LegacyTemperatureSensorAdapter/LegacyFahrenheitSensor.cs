namespace LegacyTemperatureSensorAdapter
{
    public sealed class LegacyFahrenheitSensor
    {
        private readonly double _fahrenheit;
        private readonly bool _available;

        public LegacyFahrenheitSensor(double fahrenheit, bool available = true)
        {
            _fahrenheit = fahrenheit;
            _available = available;
        }

        public double ReadFahrenheit()
        {
            if (!_available)
            {
                throw new InvalidOperationException("Legacy sensor is unavailable.");
            }

            return _fahrenheit;
        }
    }
}
