using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility.containers;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup.steps
{
  public class ConfiguringTheFrontController : IRunAStartupStep
  {
    IProvideStartupServices startup_service;

    public ConfiguringTheFrontController(IProvideStartupServices startup_service)
    {
      this.startup_service = startup_service;
    }

    public void run()
    {
      var route_table = new RouteTable(startup_service.fetch<IProvideStartupServices>(),
        startup_service.fetch<IFetchDependencies>());

      startup_service.register_instance<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
      startup_service.register_instance<GetTheCurrentlyExecutingRequest>(() => HttpContext.Current);
      startup_service.register<ICreateControllerRequests, StubRequestFactory>();
      startup_service.register_instance<RawRedirect>(path => HttpContext.Current.Response.Redirect(path,true));
      startup_service.register<IRedirect, Redirect>();
      startup_service.register<ICreateOneReport, CreateOneReport>();
      startup_service.register<IFindPathsToViews, StubPathRegistry>();
      startup_service.register<IProcessOneRequest, StubMissingCommand>();
      startup_service.register<IFindViewsToDisplayReportModels, WebFormRegistry>();
      startup_service.register<IDisplayInformation, WebFormDisplayEngine>();
      startup_service.register_instance<IEnumerable<IProcessOneRequest>>(route_table);
      startup_service.register_instance<IRegisterRoutes>(route_table);
      startup_service.register<IFindCommands, CommandRegistry>();
      startup_service.register<IProcessRequests, FrontController>();
    }
  }
}