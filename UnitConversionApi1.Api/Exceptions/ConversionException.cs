namespace UnitConversionApi1.Api.Exceptions;

public class ConversionException : Exception
{
    public ConversionException(string message)
        : base(message)
    {
    }
}