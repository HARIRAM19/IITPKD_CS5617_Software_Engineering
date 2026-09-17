namespace LegacyTemperatureSensorAdapter
{
    public sealed class TemperatureSensorAdapter : ITemperatureSensor
    {
        private readonly LegacyFahrenheitSensor _sensor;

        public TemperatureSensorAdapter(LegacyFahrenheitSensor sensor)
        {
            _sensor = sensor ?? throw new ArgumentNullException(nameof(sensor));
        }

        public double ReadCelsius()
        {
            return (_sensor.ReadFahrenheit() - 32.0) * 5.0 / 9.0;
        }

        public SensorStatus GetStatus()
        {
            try
            {
                _sensor.ReadFahrenheit();
                return SensorStatus.Available;
            }
            catch (InvalidOperationException)
            {
                return SensorStatus.Unavailable;
            }
        }
    }
}
