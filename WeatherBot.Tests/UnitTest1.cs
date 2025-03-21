using WeatherBot.Model;

namespace WeatherBot.Tests;

public class RainBotTests
{
    private readonly RainBot _rainBot = new RainBot();
    
    [Fact]
    public void Test1()
    {
        // Arrange
        _rainBot.Enabled = true;
        _rainBot.Message = "Rain";
        
        // Act
        _rainBot.Report();
        
        // Assert
        // codigo para verificar que en consola imprimio el mensaje
    }
}