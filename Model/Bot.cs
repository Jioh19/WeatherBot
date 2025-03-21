namespace WeatherBot.Model;

public interface IBot
{
    public void Report();
}

public abstract class Bot
{
    public bool Enabled { get; set; }
    public string? Message { get; set; }
    
    public int Value;

    public int Treshold { get; set;  }
}

public class SunBot : Bot, IBot
{
    /// <inheritdoc />
    public void Report() => throw new NotImplementedException();
}

public class RainBot : Bot, IBot
{
    /// <inheritdoc />
    public void Report() => throw new NotImplementedException();
} 

public class SnowBot : Bot, IBot
{
    /// <inheritdoc />
    public void Report() => throw new NotImplementedException();
} 
