using System.Security.Principal;

namespace app.web.core.stubs
{
  public class StubPrincipal : IPrincipal
  {
    public long user_id { get; set; }

    public StubPrincipal(long id)
    {
      this.user_id = id;
    }

    public bool IsInRole(string role)
    {
      return true;
    }

    public IIdentity Identity
    {
      get { return new StubIdentity(user_id);}
    }

  }

  public class StubIdentity : IIdentity
  {
    long id;

    public StubIdentity(long id)
    {
      this.id = id;
    }

    public string Name
    {
      get { return "JP";}
    }

    public string AuthenticationType
    {
      get { return "Custom Authentication";}
    }

    public bool IsAuthenticated
    {
      get { return id > 0;}
    }
  }
}