using Newtonsoft.Json;
using WeatherBot.Model;

namespace WeatherBot.Reader;

public class JsonReader : IReader<Weather>
{
    public async Task<Weather> ReadAsync(string filePath)
    {
        string jsonString = await File.ReadAllTextAsync(filePath);
        
        try
        {
            var weather = JsonConvert.DeserializeObject<Weather>(jsonString);
            return weather;
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error parsing Json: {e.Message}");
            throw;
        }
    }
}