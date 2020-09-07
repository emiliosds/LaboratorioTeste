using System;

/// <summary>
/// https://github.com/akazemis/TestableDateTimeProvider
/// </summary>
namespace Infraestrutura.Transversal
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }
}