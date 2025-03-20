using Newtonsoft.Json;
using WeatherBot.Model;

namespace WeatherBot;

public class JsonReader : Reader
{
    // public  Weather Read(string url)
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
    
    public async Task<Weather> ReadAsync(string url)
    {
        string jsonString = await File.ReadAllTextAsync(url);
        
        Weather weather;
        try
        {
            weather = JsonConvert.DeserializeObject<Weather>(jsonString);
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error parsing Json: {e.Message}");
            throw;
        }
        return weather;
    }
}