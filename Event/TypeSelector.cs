using WeatherBot.Model;
using WeatherBot.Reader;

namespace WeatherBot.Event;

public static class TypeSelector
{
    public static async Task<Weather> ReadAsync(String url)
    {
        string type = url.Split('.').Last();

        IReader<Weather> reader;
        switch (type)
        {
            case "json":
                reader = new JsonReader();
                break;
            case "xml":
                reader = new XmlReader();
                break;
            default:
                throw new InvalidDataException("Invalid data type");
        }

        Weather weather = await reader.ReadAsync(url);
        return weather;
    }
}