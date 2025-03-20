using WeatherBot.Model;

namespace WeatherBot;

public static class Selector
{
    public static Weather Read(String url)
    {
        string type = url.Split('.').Last();

        Reader reader;
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

        Weather weather = reader.Read(url);
        return weather;
    }
}