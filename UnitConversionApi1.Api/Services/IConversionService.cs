using UnitConversionApi1.Api.Models;

namespace UnitConversionApi1.Api.Services;

public interface IConversionService
{
    ConversionResponse Convert(ConversionRequest request);
}