// See https://aka.ms/new-console-template for more information

using WeatherBot;
using WeatherBot.Model;

Console.WriteLine("Hello, World!");

Weather weather = await Selector.ReadAsync("../../../input.xml");


Console.WriteLine($"{weather.Location} {weather.Temperature} {weather.Humidity} ");

