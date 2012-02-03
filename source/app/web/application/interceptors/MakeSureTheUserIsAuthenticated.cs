using app.web.core;

namespace app.web.application.interceptors
{
  public class MakeSureTheUserIsAuthenticated<RequestToForwardToIfNotAuthenticated> : IInterceptWithoutForwardingTheCall
  {
    IRedirect redirect;
      GetTheCurrentPrincipal the_current_principal;

      public MakeSureTheUserIsAuthenticated(IRedirect redirect, GetTheCurrentPrincipal the_current_principal)
      {
          this.redirect = redirect;
          this.the_current_principal = the_current_principal;
      }

      public void process(IProvideDetailsToCommands request)
    {
        var principal = the_current_principal();
        if (principal.Identity.IsAuthenticated)
            return;
        redirect.to<RequestToForwardToIfNotAuthenticated>();
    }
  }
}