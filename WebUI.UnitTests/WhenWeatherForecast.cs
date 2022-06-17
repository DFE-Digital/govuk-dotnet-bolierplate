﻿using AutoFixture;
using CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using CleanArchitecture.WebUI.Services.Api;
using CleanArchitecture.WebUI.Features.WeatherForecast;
using Moq;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace WebUI.UnitTests;
public class WhenWeatherForecast
{
    private readonly Fixture _fixture;
    private readonly Mock<IApiService> _mockApiService;
    private readonly List<WeatherForecast> _weatherForecasts;
    private readonly WeatherForecastController _sut;

    public WhenWeatherForecast()
    {
        _mockApiService = new Mock<IApiService>();

        _fixture = new Fixture();
        _weatherForecasts = _fixture.Create<List<WeatherForecast>>();
        _mockApiService.Setup(x => x.GetWeatherForecasts()).Returns(Task.FromResult(_weatherForecasts));

        _sut = new WeatherForecastController(_mockApiService.Object);

    }

#pragma warning disable CS8602 // Dereference of a possibly null reference.

    [Fact]
    public async Task WhenTheIndexMethodIsCalled_ToDoListsAreReturned()
    {
        //Arrange
        var weatherForecasts = new WeatherForecastViewModel()
        {
            WeatherForecasts = _weatherForecasts
        };

        //Act
        var viewResult = await _sut.Index() as ViewResult;

        //Assert
        viewResult.Should().NotBeNull();
        var model = viewResult.Model as WeatherForecastViewModel;
        model.Should().NotBeNull();
        model.WeatherForecasts.Should().NotBeNull();
        model.WeatherForecasts.Should().BeEquivalentTo(weatherForecasts.WeatherForecasts);
        
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
