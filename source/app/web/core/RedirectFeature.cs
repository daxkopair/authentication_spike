namespace app.web.core
{
  public class RedirectFeature<Request> : IInterceptWithoutForwardingTheCall
  {
    IRedirect redirect;

    public RedirectFeature(IRedirect redirect)
    {
      this.redirect = redirect;
    }

    public void process(IProvideDetailsToCommands request)
    {
      redirect.to<Request>();
    }
  }
}