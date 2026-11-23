using UnitConversionApi1.Api.Models;
using UnitConversionApi1.Api.Services;

namespace UnitConversionApi1.Tests;

public class ConversionServiceTests
{
    [Fact]
    public void ConvertKgToLb()
    {
        var service = new ConversionService();

        var request = new ConversionRequest
        {
            Category = "weight",
            FromUnit = "kg",
            ToUnit = "lb",
            Value = 1
        };

        var result = service.Convert(request);

        Assert.Equal(2.2046,
            result.ConvertedValue,
            4);
    }
}