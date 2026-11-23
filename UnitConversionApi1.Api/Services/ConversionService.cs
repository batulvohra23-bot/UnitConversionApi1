using UnitConversionApi1.Api.Exceptions;
using UnitConversionApi1.Api.Models;

namespace UnitConversionApi1.Api.Services;

public class ConversionService : IConversionService
{
    private readonly Dictionary<string, double> _lengthUnits = new()
    {
        { "meter", 1 },
        { "kilometer", 1000 },
        { "foot", 0.3048 },
        { "inch", 0.0254 }
    };

    private readonly Dictionary<string, double> _weightUnits = new()
    {
        { "kg", 1 },
        { "gram", 0.001 },
        { "lb", 0.453592 }
    };

    public ConversionResponse Convert(ConversionRequest request)
    {
        double result = request.Category.ToLower() switch
        {
            "length" => ConvertUsingBaseUnit(
                request.Value,
                request.FromUnit.ToLower(),
                request.ToUnit.ToLower(),
                _lengthUnits),

            "weight" => ConvertUsingBaseUnit(
                request.Value,
                request.FromUnit.ToLower(),
                request.ToUnit.ToLower(),
                _weightUnits),

            "temperature" => ConvertTemperature(
                request.Value,
                request.FromUnit.ToLower(),
                request.ToUnit.ToLower()),

            _ => throw new ConversionException("Unsupported category")
        };

        return new ConversionResponse
        {
            OriginalValue = request.Value,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit,
            ConvertedValue = Math.Round(result, 4)
        };
    }

    private double ConvertUsingBaseUnit(
        double value,
        string from,
        string to,
        Dictionary<string, double> units)
    {
        if (!units.ContainsKey(from))
            throw new ConversionException($"Unsupported unit: {from}");

        if (!units.ContainsKey(to))
            throw new ConversionException($"Unsupported unit: {to}");

        double baseValue = value * units[from];

        return baseValue / units[to];
    }

    private double ConvertTemperature(
        double value,
        string from,
        string to)
    {
        if (from == "celsius" && to == "fahrenheit")
            return value * 9 / 5 + 32;

        if (from == "fahrenheit" && to == "celsius")
            return (value - 32) * 5 / 9;

        if (from == to)
            return value;

        throw new ConversionException(
            "Unsupported temperature conversion");
    }
}