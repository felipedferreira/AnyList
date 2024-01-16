namespace AnyList.WebApplication;

public record WeatherForecast(DateOnly Date, int TemperatureC)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string Summary
    {
        get {
            if (TemperatureC <= 0)
            {
                return "Freezing";
            }
            
            if (TemperatureC <= 5)
            {
                return "Bracing";
            }
            
            if (TemperatureC <= 12)
            {
                return "Chilly";
            }
            
            if (TemperatureC <= 18)
            {
                return "Cool";
            }
            
            if (TemperatureC <= 24)
            {
                return "Mild";
            }
            
            if (TemperatureC <= 35)
            {
                return "Warm";
            }
            
            if (TemperatureC <= 40)
            {
                return "Hot";
            }
            
            if (TemperatureC <= 45)
            {
                return "Sweltering";
            }

            return "Scorching";
        }
    }
}