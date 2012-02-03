using System;

namespace app.web.core
{
  public interface IConfigureARoute
  {
    IConfigureARoute intercept_with<Feature>() where Feature : IInterceptWithoutForwardingTheCall;
    IImplementAFeature build();
    Type input_model { get; }
  }
}