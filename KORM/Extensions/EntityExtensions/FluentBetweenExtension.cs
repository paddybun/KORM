using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Identity.Client;

namespace KORM.Extensions.EntityExtensions;

public static class FluentBetweenExtension
{
    public static DateTimeBetween Between(this DateTime me)
    {
        return new DateTimeBetween();
    }
}

public class DateTimeBetween : IBetween<DateTime>
{
    public DateTime DataFrom { get; }
    public IBetweenFrom<DateTime> From(DateTime @from)
    {
        return this;
    }

    public DateTime DataTo { get; }
    public IBetweenFrom<DateTime> To(DateTime to)
    {
        return this;
    }
}


public interface IBetween<T> : IBetweenFrom<T>, IBetweenTo<T>
{
}

public sealed class BetweenResult<T>
{
    public T From { get; set; }
    public T To { get; set; }
}

public interface IBetweenFrom<T>
{
    T DataFrom{ get; }
    IBetweenFrom<T> From(T from);
}
public interface IBetweenTo<T>
{
    T DataTo{ get; }
    IBetweenFrom<T> To(T to);
}