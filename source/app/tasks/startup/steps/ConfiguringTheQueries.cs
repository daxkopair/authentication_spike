using System.Linq;
using app.utility;
using app.web.core;

namespace app.tasks.startup.steps
{
  public class ConfiguringTheQueries : IRunAStartupStep
  {
    IProvideStartupServices startup_service;

    public ConfiguringTheQueries(IProvideStartupServices startup_service)
    {
      this.startup_service = startup_service;
    }

    public void run()
    {
      startup_service.all_registerable_types().Where(x => typeof(IFetchInformation).IsAssignableFrom(x))
        .each(x => startup_service.register(x));
    }
  }
}