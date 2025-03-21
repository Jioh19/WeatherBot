using Newtonsoft.Json;
using WeatherBot.Model;

namespace WeatherBot.Reader;

public class BotReader : IReader<Dictionary<string, Bot>>
{
    public async Task<Dictionary<string, Bot>> ReadAsync(string filePath)
    {
        string jsonString = await File.ReadAllTextAsync(filePath);

        try
        { 
            var unclassifiedBots = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString) ?? [];

            Dictionary<string, Bot> bots = new();

            foreach (var kpv in unclassifiedBots)
            {
                var data = kpv.Value;
                Bot bot;
                if (data.humidityThreshold is not null)
                {
                    bot = new HumidityBot();
                    if (!int.TryParse(data.humidityThreshold, out int result))
                    {
                        throw new Exception("Humidity threshold must be an integer");
                    }
                    bot.Value = result;
                    bot.Treshold = data.humidityThreshold;
                }
                else if (data.temperatureThreshold is not null)
                {
                    bot = new Temperature();
                    bot.Value = (int)data.temperatureThreshold;
                    bot.Treshold = data.temperatureThreshold;
                }
                else
                {
                    throw new Exception("Invalid bot type");
                }
                
                bot.Enabled = data.enabled;
                bot.Message = data.message;

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