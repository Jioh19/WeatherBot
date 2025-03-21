using WeatherBot.Model;

namespace WeatherBot.Event;

public class EventManager(Weather weather, Dictionary<string, Bot> bots)
{
    private readonly Weather _weather = weather;

    private Dictionary<string, Bot> _bots = bots;

    // public EventManager(Weather weather, Dictionary<string, Bot> bots)
    // {
    //     this._weather = weather;
    //     this._bots = bots;
    // }

    private void UpdateBots(Dictionary<string, Bot> bots)
    {
        this._bots = BotSelector.SelectEnabled(bots);
    }
    
    public void Report()
    {
        UpdateBots(_bots);
        
        foreach (var kpv in _bots)
        {
            Bot bot = kpv.Value;

            switch (bot.Type)
            {
                case Bot.BotType.Humidity:
                    if (_weather.Humidity > bot.Value)
                    {
                        Console.WriteLine($"{kpv.Key} activated!");
                        Console.WriteLine($"{kpv.Key}: {bot.Message}");
                    }

                    break;
                case Bot.BotType.Temperature:
                    if (bot.Value <= 0)
                    {
                        if (_weather.Temperature < bot.Value)
                        {
                            Console.WriteLine($"{kpv.Key} activated!");
                            Console.WriteLine($"{kpv.Key}: {bot.Message}");
                        }
                    }
                    else if (_weather.Temperature > bot.Value)
                    {
                        Console.WriteLine($"{kpv.Key} activated!");
                        Console.WriteLine($"{kpv.Key}: {bot.Message}");
                    }

                    break;
            }
        }
    }
}