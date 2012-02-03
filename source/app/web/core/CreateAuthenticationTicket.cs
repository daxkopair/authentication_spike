using System.Web.Security;

namespace app.web.core
{
    public delegate FormsAuthenticationTicket CreateAuthenticationTicket(string username);
}