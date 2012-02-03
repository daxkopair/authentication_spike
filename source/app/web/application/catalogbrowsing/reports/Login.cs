using app.web.core;

namespace app.web.application.catalogbrowsing.reports
{
  public class Login : IChangeSystemState
  {
    IsAuthorizedUser authorization;
    CreateAuthenticationTicket ticket_factory;
    AssociateTicketWithCurrentUser authentication_completion;

    public Login(IsAuthorizedUser authorization, CreateAuthenticationTicket ticket_factory, AssociateTicketWithCurrentUser authentication_completion)
    {
      this.authorization = authorization;
      this.ticket_factory = ticket_factory;
      this.authentication_completion = authentication_completion;
    }

    public void process(IProvideDetailsToCommands request)
    {
      if (authorization("bla", "asdf"))
      {
        var ticket = ticket_factory("blah");
        authentication_completion(ticket);
      }
    }
  }
}