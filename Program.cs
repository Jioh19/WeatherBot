// See https://aka.ms/new-console-template for more information

using WeatherBot;
using WeatherBot.Event;
using WeatherBot.Model;


Weather weather = await TypeSelector.ReadAsync("../../../input.xml");


// Console.WriteLine($"{weather.Location} {weather.Temperature} {weather.Humidity} ");

BotReader botReader = new BotReader();

Dictionary<string, Bot> bots = await botReader.ReadAsync("../../../bots.json");

// foreach (var kvp in bots.ToList())
// {
//     Bot bot = kvp.Value;
//     string name = kvp.Key;
//     Console.WriteLine($"name:{name, -10} enabled:{bot.Enabled,-10} type:{bot.Type,-15} value:{bot.Value, -6} message:{bot.Message,-20} ");
// }
EventManager eventManager = new EventManager(weather, BotSelector.selectEnabled(bots));
eventManager.report();


