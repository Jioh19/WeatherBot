using System.Xml;
using WeatherBot.Model;

namespace WeatherBot.Reader;

public class XmlReader : IReader<Weather>
{
    // public Weather Read(string filePath)
    // {
    //     System.Xml.XmlReader reader = System.Xml.XmlReader.Create(filePath);
    //     Weather weather = ParseWeatherFromXml(reader);
    //     return weather;
    // }
    //
    // private Weather ParseWeatherFromXml(System.Xml.XmlReader reader)
    // {
    //     Weather weather = new Weather();
    //
    //     try
    //     {
    //         while (reader.Read())
    //         {
    //             if (reader.NodeType == XmlNodeType.Element)
    //             {
    //                 switch (reader.Name)
    //                 {
    //                     case "Location":
    //                         weather.Location = reader.ReadElementContentAsString();
    //                         break;
    //                     case "Temperature":
    //                         weather.Temperature = reader.ReadElementContentAsDouble();
    //                         break;
    //                     case "Humidity":
    //                         weather.Humidity = reader.ReadElementContentAsDouble();
    //                         break;
    //                 }
    //             }
    //         }
    //     }
    //     catch (XmlException e)
    //     {
    //         Console.WriteLine($"Error parsing XML: {e.Message}");
    //         throw;
    //     }
    //
    //     return weather;
    // }
    
    public async Task<Weather> ReadAsync(string filePath)
    {
        
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Async = true;
        
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create(filePath, settings);
        Weather weather = new Weather();

        try
        {
            while (await reader.ReadAsync())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Location":
                            weather.Location = reader.ReadElementContentAsString();
                            break;
                        case "Temperature":
                            weather.Temperature = reader.ReadElementContentAsDouble();
                            break;
                        case "Humidity":
                            weather.Humidity = reader.ReadElementContentAsDouble();
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