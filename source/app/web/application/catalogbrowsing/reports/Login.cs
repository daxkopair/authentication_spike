using app.web.core;

namespace app.web.application.catalogbrowsing.reports
{
  public class Login : IChangeSystemState
  {
    Authentication_Behaviour authorization;
    CreateAuthenticationTicketBehaviour ticket_behaviour_factory;
    AssociateTicketWithCurrentUser_Behaviour authentication_completion;

    public Login(Authentication_Behaviour authorization, CreateAuthenticationTicketBehaviour ticket_behaviour_factory, AssociateTicketWithCurrentUser_Behaviour authentication_completion)
    {
      this.authorization = authorization;
      this.ticket_behaviour_factory = ticket_behaviour_factory;
      this.authentication_completion = authentication_completion;
    }

    public void process(IProvideDetailsToCommands request)
    {
      if (authorization("bla", "asdf"))
      {
        var ticket = ticket_behaviour_factory("blah");
        authentication_completion(ticket);
      }
    }
  }
}