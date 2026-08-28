namespace LegacyTemperatureSensorAdapter
{
    public interface ITemperatureSensor
    {
        double ReadCelsius();
        SensorStatus GetStatus();
    }
}
