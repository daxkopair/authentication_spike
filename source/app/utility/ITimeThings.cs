using System;

namespace app.utility
{
  public interface ITimeThings
  {
    void start();
    TimeSpan stop();
  }
}