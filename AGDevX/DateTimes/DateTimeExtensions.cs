using System;

namespace AGDevX.DateTimes;

public static class DateTimeExtensions
{
    public static DateTime SpecifyKind(this DateTime value, DateTimeKind kind) => DateTime.SpecifyKind(value, kind);
}