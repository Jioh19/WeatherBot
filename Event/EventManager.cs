using WeatherBot.Model;

namespace WeatherBot.Event;

public interface IBotManager
{
    public void Report(IEnumerable<IBot> bots);
}

public class EventManager(Weather weather, Dictionary<string, Bot> bots)
{
    private Dictionary<string, Bot> _bots = bots;

    private void UpdateBots(Dictionary<string, Bot> bots)
    {
        _bots = BotSelector.SelectEnabled(bots);
    }
    
    public void Report(IEnumerable<IBot> bots)
    {
        UpdateBots(_bots);
        bots.Where(b => b.Enabled).ToList().ForEach(bot => bot.Report());
    }
}