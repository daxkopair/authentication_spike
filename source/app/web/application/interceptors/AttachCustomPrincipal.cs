using System;
using app.web.core;

namespace app.web.application.interceptors
{
  public class AttachCustomPrincipal
    : IInterceptWithoutForwardingTheCall

  {
    public void process(IProvideDetailsToCommands request)
    {
      throw new NotImplementedException();
    }
  }
}