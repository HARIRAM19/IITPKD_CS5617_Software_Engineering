using Xunit;

namespace LegacyTemperatureSensorAdapter.Tests
{
    public sealed class TemperatureSensorAdapterTests
    {
        [Theory]
        [InlineData(32.0, 0.0)]
        [InlineData(212.0, 100.0)]
        [InlineData(77.0, 25.0)]
        public void ReadCelsius_ConvertsFahrenheit(double fahrenheit, double expectedCelsius)
        {
            var adapter = new TemperatureSensorAdapter(
                new LegacyFahrenheitSensor(fahrenheit));

            var actual = adapter.ReadCelsius();

            Assert.Equal(expectedCelsius, actual, 6);
        }

        [Fact]
        public void GetStatus_ReturnsAvailable_WhenLegacySensorIsAvailable()
        {
            var adapter = new TemperatureSensorAdapter(new LegacyFahrenheitSensor(68.0));

            Assert.Equal(SensorStatus.Available, adapter.GetStatus());
        }

        [Fact]
        public void GetStatus_ReturnsUnavailable_WhenLegacySensorIsUnavailable()
        {
            var adapter = new TemperatureSensorAdapter(
                new LegacyFahrenheitSensor(68.0, available: false));

            Assert.Equal(SensorStatus.Unavailable, adapter.GetStatus());
        }

        [Fact]
        public void Constructor_RejectsNullSensor()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new TemperatureSensorAdapter(null!));
        }
    }
}
