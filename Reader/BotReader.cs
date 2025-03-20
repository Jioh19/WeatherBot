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
        Dictionary<string, dynamic> unclassifiedBots = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);
        
        Console.WriteLine(jsonString);

        Dictionary<string, Bot> bots = new Dictionary<string, Bot>();

        foreach (var kpv in unclassifiedBots)
        {
            var data = kpv.Value;
            Bot bot = new Bot();
            bot.Enabled = data.enabled;
            bot.Message = data.message;
            
            if (data.humidityThreshold != null)
            {
                bot.Type = Bot.BotType.HUMIDITY;
                bot.Value = (int)data.humidityThreshold;
            }
            else if (data.temperatureThreshold != null)
            {
                bot.Type = Bot.BotType.TEMPERATURE;
                bot.Value = (int)data.temperatureThreshold;
            }

            bots.Add(kpv.Key, bot);
        }
        
        return bots;
            
        } 
        catch (Exception e)
        {
            Console.WriteLine($"Error parsing Json: {e.Message}");
            throw;
        }
    }
}