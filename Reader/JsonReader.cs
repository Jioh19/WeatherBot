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
    
    public async Task<Weather> ReadAsync(string file)
    {
        string jsonString = await File.ReadAllTextAsync(file);
        
        Weather weather;
        try
        {
            weather = JsonConvert.DeserializeObject<Weather>(jsonString);
            return weather;
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error parsing Json: {e.Message}");
            throw;
        }
    }
}