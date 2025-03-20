using WeatherBot.Model;

namespace WeatherBot.Event;

public class EventManager
{
    public Weather Weather;

    public Dictionary<string, Bot> Bots;

    public EventManager(Weather weather, Dictionary<string, Bot> bots)
    {
        this.Weather = weather;
        this.Bots = bots;
    }

    public void report()
    {
        foreach (var kpv in Bots)
        {
            Bot bot = kpv.Value;
            if (bot.Enabled)
            {
                switch (bot.Type)
                {
                    case Bot.BotType.HUMIDITY:
                        if (Weather.Humidity > bot.Value)
                        {
                            Console.WriteLine($"{kpv.Key} activated!");
                            Console.WriteLine($"{kpv.Key}: {bot.Message}");
                        }
                        break;
                    case Bot.BotType.TEMPERATURE:
                        if (Weather.Temperature < bot.Value)
                        {
                            Console.WriteLine($"{kpv.Key} activated!");
                            Console.WriteLine($"{kpv.Key}: {bot.Message}");
                        }
                        break;
                }
            }
        }
    }
}