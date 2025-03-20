using WeatherBot.Model;

namespace WeatherBot;

public interface IReader<T>
{
    Task<T> ReadAsync(string url);
}