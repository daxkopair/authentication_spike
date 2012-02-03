using System.Web;

namespace app.web.core
{
  public interface ICreateControllerRequests
  {
    IProvideDetailsToCommands create_controller_request(HttpContext current_request);
  }
}