using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by<ConfiguringTheContainer>()
        .followed_by<ConfiguringTheFrontController>()
        .followed_by<ConfiguringTheQueries>()
        .followed_by<ConfigureCommands>()
        .finish_by<ConfigureTheRoutes>();
    }
  }
}