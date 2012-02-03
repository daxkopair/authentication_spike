using System.Collections.Generic;
using app.tasks.startup;
using app.utility;
using app.utility.containers;

namespace app.web.core
{
  public class RouteTable : List<IProcessOneRequest>, IRegisterRoutes
  {
    IProvideStartupServices service;
    IFetchDependencies container;
    IList<IConfigureARoute> pending_routes;

    public RouteTable(IProvideStartupServices service, IFetchDependencies container)
    {
      this.service = service;
      this.container = container;
      this.pending_routes = new List<IConfigureARoute>();
    }

    IConfigureARoute add_command_for<InputModel>(IImplementAFeature feature)
    {
      var route = new RouteConfiguration<InputModel>(feature,service);
      pending_routes.Add(route);
      return route;
    }

    public IConfigureARoute a_report<InputModel, Feature>() where Feature : IImplementAFeature
    {
      return add_command_for<InputModel>(Container.fetch.an<Feature>());
    }

    public void prepare_routes()
    {
      this.pending_routes.each(route => Add(
        new RequestCommand(request => request.command_name.ToLower().Contains(route.input_model.Name.ToLower()),
                           route.build())));
    }

    public IConfigureARoute a_command<InputModel, FirstStep, NextRequest>() where FirstStep : IImplementAFeature
    {
      service.register<RedirectFeature<NextRequest>>();
      return add_command_for<InputModel>(new ChainedAction<FirstStep,IImplementAFeature>(service.fetch<FirstStep>(),service.fetch<RedirectFeature<NextRequest>>()));
    }
  }
}