using Newtonsoft.Json;
using WeatherBot.Model;

namespace WeatherBot.Reader;

public class JsonReader : IReader<Weather>
{
    // public Weather Read(string url)
    // {
    //     string jsonString = File.ReadAllText(url);
    //     
    //     Weather weather;
    //     try
    //     {
    //         weather = JsonConvert.DeserializeObject<Weather>(jsonString);
    //         
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine($"Error parsing Json: {e.Message}");
    //         throw;
    //     }
    //     return weather;
    // }
    
    public async Task<Weather> ReadAsync(string filePath)
    {
        string jsonString = await File.ReadAllTextAsync(filePath);
        
        try
        {
            Weather weather = JsonConvert.DeserializeObject<Weather>(jsonString);
            return weather;
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error parsing Json: {e.Message}");
            throw;
        }
    }
}