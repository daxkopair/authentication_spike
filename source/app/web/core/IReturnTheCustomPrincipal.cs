using System.Security.Principal;

namespace app.web.core
{
    public delegate PrincipalType GetTheCurrentPrincipal<PrincipalType>(IPrincipal principal);
}