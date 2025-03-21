// See https://aka.ms/new-console-template for more information

using WeatherBot;
using WeatherBot.Event;
using WeatherBot.Model;
using WeatherBot.Reader;

try
{
    Weather weather = await TypeSelector.ReadAsync("../../../input.xml");
    BotReader botReader = new BotReader();
    Dictionary<string, Bot> bots = await botReader.ReadAsync("../../../bots.json");

    EventManager eventManager = new EventManager(weather, bots);
    eventManager.Report(bots);

}
catch (Exception e)
{
    Console.WriteLine(e);
}


