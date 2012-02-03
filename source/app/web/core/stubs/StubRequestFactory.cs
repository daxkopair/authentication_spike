using System;
using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IProvideDetailsToCommands create_controller_request(HttpContext current_request)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsToCommands
    {
      public InputModel map<InputModel>()
      {
        return Activator.CreateInstance<InputModel>();
      }

      public string command_name
      {
        get { return HttpContext.Current.Request.Url.PathAndQuery; }
      }
    }
  }
}