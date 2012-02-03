using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.Compilation;
using System.Web.Security;
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
      startup_service.register_instance<GetTheCurrentPrincipal<StubPrincipal>>(x => (StubPrincipal)x);
      startup_service.register<IFindCommands, CommandRegistry>();
      startup_service.register<IProcessRequests, FrontController>();

      startup_service.register_instance<GetTheCurrentTicket>(create_the_current_ticket);
      startup_service.register_instance<GetTheCurrentUserIDFromTicket>(ticket =>
        ticket == null ? 0 : long.Parse(ticket.UserData));
      startup_service.register_instance<PrincipalFactory>((id) => new StubPrincipal(id));
      startup_service.register_instance<PrincipalSwitch>(new_principal =>
      {
        Thread.CurrentPrincipal = new_principal;
        HttpContext.Current.User = new_principal;
      });

    }

    FormsAuthenticationTicket create_the_current_ticket()
    {
      var http_cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
      if (http_cookie == null) return null;
      return FormsAuthentication.Decrypt(http_cookie.Value);
    }
  }
}