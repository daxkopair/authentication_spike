using app.utility.containers;

namespace app.web.core
{
  public class Routes
  {
    public static IRegisterRoutes to
    {
      get { return Container.fetch.an<IRegisterRoutes>(); }
    }
  }
}