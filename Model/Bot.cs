namespace WeatherBot.Model;

public class Bot
{
    public bool Enabled { get; set; }
    public string? Message { get; set; }
    
    public int Value;
    public BotType Type { get; set; }
    public enum BotType
    {
        Temperature,
        Humidity
    }
}