using app.web.core;

namespace app.web.application.interceptors
{
  public class MakeSureTheUserIsAuthenticated<RequestToForwardToIfNotAuthenticated> : IInterceptWithoutForwardingTheCall
  {
    IRedirect redirect;

    public MakeSureTheUserIsAuthenticated(IRedirect redirect)
    {
      this.redirect = redirect;
    }

    public void process(IProvideDetailsToCommands request)
    {
      
    }
  }
}