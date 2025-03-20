// See https://aka.ms/new-console-template for more information

using WeatherBot;
using WeatherBot.Model;


Weather weather = await Selector.ReadAsync("../../../input.xml");


Console.WriteLine($"{weather.Location} {weather.Temperature} {weather.Humidity} ");

BotReader botReader = new BotReader();

Dictionary<string, Bot> bots = await botReader.ReadAsync("../../../bots.json");

foreach (var kvp in bots.ToList())
{
    Bot bot = kvp.Value;
    string name = kvp.Key;
    string botString = string.Format("name:{4, -10} enabled:{0,-10} type:{1,-15} value:{2, -6} message:{3,-20}", bot.Enabled,
        bot.Type, bot.Value, bot.Message, name);
    Console.WriteLine(botString);
}
