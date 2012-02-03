using app.web.core;

namespace app.web.application.interceptors
{
  public class AttachCustomPrincipal
    : IInterceptWithoutForwardingTheCall

  {
    GetTheCurrentTicket ticket_factory;
    PrincipalFactory principal_factory;
    GetTheCurrentUserIDFromTicket id_mapper;
    PrincipalSwitch principal_switch;

    public AttachCustomPrincipal(GetTheCurrentTicket ticket_factory, PrincipalFactory principal_factory,
                                 GetTheCurrentUserIDFromTicket id_mapper, PrincipalSwitch principal_switch)
    {
      this.ticket_factory = ticket_factory;
      this.principal_factory = principal_factory;
      this.id_mapper = id_mapper;
      this.principal_switch = principal_switch;
    }

    public void process(IProvideDetailsToCommands request)
    {
      var ticket = ticket_factory();
      var id = id_mapper(ticket);
      var principal = principal_factory(id);
      principal_switch(principal);
    }
  }
}