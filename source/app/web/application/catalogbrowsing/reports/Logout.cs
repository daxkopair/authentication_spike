using app.web.core;

namespace app.web.application.catalogbrowsing.reports
{
  public class Logout : IChangeSystemState
  {
      Logout_Behaviour logout_behavoir;

      public Logout(Logout_Behaviour logout_behavoir)
      {
          this.logout_behavoir = logout_behavoir;
      }

      public void process(IProvideDetailsToCommands request)
    {
        logout_behavoir();
    }
  }
}