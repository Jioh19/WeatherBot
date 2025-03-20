using Newtonsoft.Json;
using WeatherBot.Model;

namespace WeatherBot;

public class BotReader :IReader<Dictionary<string, Bot>>
{
    public async Task<Dictionary<string, Bot>> ReadAsync(string file)
    {
        string jsonString = await File.ReadAllTextAsync(file);

        try
        {
        Dictionary<string, Bot> bots = JsonConvert.DeserializeObject<Dictionary<string, Bot>>(jsonString);

        return bots;
            
        } 
        catch (Exception e)
        {
            Console.WriteLine($"Error parsing Json: {e.Message}");
            throw;
        }
    }
}