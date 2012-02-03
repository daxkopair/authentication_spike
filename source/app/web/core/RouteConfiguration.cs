using System;
using app.tasks.startup;

namespace app.web.core
{
  public class RouteConfiguration<Request> : IConfigureARoute
  {
    IImplementAFeature final_feature;
    IProvideStartupServices startup;

    public RouteConfiguration(IImplementAFeature final_feature, IProvideStartupServices startup)
    {
      this.final_feature = final_feature;
      this.startup = startup;
    }

    public Type input_model
    {
      get { return typeof(Request); }
    }

    public IConfigureARoute intercept_with<Feature>() where Feature : IInterceptWithoutForwardingTheCall
    {
      startup.register<Feature>();
      return
        decorate_with_decorator(new ChainedAction<Feature, IImplementAFeature>(startup.fetch<Feature>(), final_feature));
    }

    public IConfigureARoute decorate_with_decorator(IImplementAFeature feature)
    {
      this.final_feature = feature;
      return this;
    }

    public IImplementAFeature build()
    {
      return final_feature;
    }
  }
}