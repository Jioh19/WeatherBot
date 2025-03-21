using System.Xml;
using WeatherBot.Model;

namespace WeatherBot.Reader;

public class XmlReader : IReader<Weather>
{
    public async Task<Weather> ReadAsync(string filePath)
    {
        XmlReaderSettings settings = new XmlReaderSettings
        {
            Async = true
        };
        
        var reader = System.Xml.XmlReader.Create(filePath, settings);
        var weather = new Weather(null, 0, 0);

        try
        {
            while (await reader.ReadAsync())
            {
                if (reader.NodeType is XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Location":
                            weather = weather with { Location = await reader.ReadElementContentAsStringAsync() };
                            break;
                        case "Temperature":
                            weather = weather with { Temperature = reader.ReadElementContentAsDouble() };
                            break;
                        case "Humidity":
                            weather = weather with { Humidity = reader.ReadElementContentAsDouble() };
                            break;
                    }
                }
            }
            return weather;
        }
        catch (XmlException e)
        {
            Console.WriteLine($"Error parsing XML: {e.Message}");
            throw;
        }
    }
    
}