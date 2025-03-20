using WeatherBot.Model;

namespace WeatherBot.Reader;

public interface IReader<T>
{
    Task<T> ReadAsync(string filePath);
}