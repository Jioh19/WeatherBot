namespace WeatherBot.Model;

public class Bot
{
    public bool enabled { get; set; }
    public string message { get; set; }
    
    public int value;
    public Type type { get; set; }
    public enum Type
    {
        TEMPERATURE,
        HUMIDITY
    }
}