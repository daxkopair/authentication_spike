using System;

namespace app.utility.logging
{
  public interface ICreateLoggers
  {
    ILog create_logger_bound_to(Type type_that_requested_logging);
  }
}