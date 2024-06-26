﻿using MediatR;

namespace CacheInvalidation;

public class GetWeatherForecastQueryHandler
    : IRequestHandler<GetWeatherForecastQuery, WeatherForecast>
{
    public GetWeatherForecastQueryHandler() { }

    public async Task<WeatherForecast> Handle(
        GetWeatherForecastQuery request,
        CancellationToken cancellationToken
    )
    {
        // Imitating long running request
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

        var city = WeatherForecast.Cities.FirstOrDefault(c => c.Id == request.Id);

        if (city == null)
        {
            throw new Exception("not found");
        }

        return new WeatherForecast(
                DateOnly.FromDateTime(DateTime.UtcNow),
                Random.Shared.Next(-20, 55),
                city.Name
        );

    }
}
