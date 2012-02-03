using System;
using System.Collections.Generic;

namespace app.utility
{
  public static class EnumerableExtensions
  {
    public static string format_using(this string format, params object[] args)
    {
      return string.Format(format, args);
    }
    public static void each<T>(this IEnumerable<T> items, Action<T> visitor)
    {
      foreach (var item in items) visitor(item);
    }
  }
}