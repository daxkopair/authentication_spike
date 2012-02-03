using System.Security.Principal;

namespace app.web.core
{
  public delegate IPrincipal PrincipalFactory(long id);
}