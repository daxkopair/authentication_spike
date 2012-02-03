using System.Web;
using app.utility.containers;

namespace app.web.core.aspnet
{
  public class ASPHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateControllerRequests request_factory;

    public ASPHandler(IProcessRequests front_controller, ICreateControllerRequests request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public ASPHandler():this(Container.fetch.an<IProcessRequests>(),
      Container.fetch.an<ICreateControllerRequests>())
    {
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.process(request_factory.create_controller_request(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}