using app.web.core;

namespace app.web.application.interceptors
{
  public class MakeSureTheUserIsAuthenticated<RequestToForwardToIfNotAuthenticated> : IInterceptWithoutForwardingTheCall
  {
    IRedirect redirect;
    GetTheCurrentPrincipal_Behaviour the_current_principal_behaviour;

    public MakeSureTheUserIsAuthenticated(IRedirect redirect, GetTheCurrentPrincipal_Behaviour the_current_principal_behaviour)
    {
      this.redirect = redirect;
      this.the_current_principal_behaviour = the_current_principal_behaviour;
    }

    public void process(IProvideDetailsToCommands request)
    {
      var principal = the_current_principal_behaviour();
      if (principal.Identity.IsAuthenticated)
        return;
      redirect.to<RequestToForwardToIfNotAuthenticated>();
    }
  }
}