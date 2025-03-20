using WeatherBot.Model;

namespace WeatherBot;

public interface Reader
{
    Task<Weather> ReadAsync(string url);
}