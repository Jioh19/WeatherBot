using WeatherBot.Model;
using WeatherBot.Reader;

namespace WeatherBot.Event;

public interface ITypeSelector
{
    public Task<Weather> ReadAsync(string url);
}

public class TypeSelector : ITypeSelector
{
    public async Task<Weather> ReadAsync(string url)
    {
        var type = url.Split('.').Last();

        IReader<Weather> reader = type switch
        {
            "json" => new JsonReader(),
            "xml" => new XmlReader(),
            _ => throw new InvalidDataException("Invalid data type")
        };

        Weather weather = await reader.ReadAsync(url);
        return weather;
    }
}