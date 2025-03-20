using WeatherBot.Model;

namespace WeatherBot.Event;

public static class BotSelector
{
    public static List<Bot> botsEnabled { get; set; }

    public static Dictionary<string, Bot> selectEnabled(Dictionary<string, Bot> bots)
    {
        return bots.Where(kvp => kvp.Value.Enabled).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
    
}