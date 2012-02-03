using app.utility.containers;

namespace app.utility.logging
{
  public class Log
  {
    public static ILog an
    {
      get
      {
        return Container.fetch.an<ICreateLoggers>().create_logger_bound_to(
          Container.fetch.an<IResolveTheCallingType>().resolve());
      }
    }
  }
}