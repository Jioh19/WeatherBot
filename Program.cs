// See https://aka.ms/new-console-template for more information

using WeatherBot;
using WeatherBot.Model;


Weather weather = await Selector.ReadAsync("../../../input.xml");


Console.WriteLine($"{weather.Location} {weather.Temperature} {weather.Humidity} ");

Dictionary<string, Bot> bots = await BotReader.ReadAsync("../../../bots.json");

foreach (var kvp in bots.ToList())
{
    Bot bot = kvp.Value;
    string name = kvp.Key;
    string botString = string.Format("name:{4, -10} enabled:{0,-10} type:{1,-15} value:{2, -6} message:{3,-20}", bot.enabled,
        bot.type, bot.value, bot.message, name);
    Console.WriteLine(botString);
}
