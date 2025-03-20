using WeatherBot.Model;

namespace WeatherBot;

public interface Reader
{
    Weather Read(string url);
}