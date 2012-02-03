using System.Web;
using app.web.core;
using app.web.core.aspnet;
using app.utility;
using app.web.core.stubs;

namespace app.web.application.interceptors
{
  public class DisplayAuthenticationDetails : IInterceptWithoutForwardingTheCall
  {
    public void process(IProvideDetailsToCommands request)
    {
      var current = HttpContext.Current;
      ResponseWriter.write_info("The Authentication Type is:{0}",current.User.Identity.AuthenticationType);
      ResponseWriter.write_info("The Authentication Class is:{0}",current.User.GetType().Name);
      ResponseWriter.write_info("The user is authenticated:{0}",current.User.Identity.IsAuthenticated);
      ResponseWriter.write_info("The user name is:{0}",current.User.Identity.Name);
      ResponseWriter.write_info("The user id is:{0}",current.User.cast_to<StubPrincipal>().user_id);
    }
  }
}