using System;
using System.Security.Principal;
using System.Web.Security;
using Machine.Specifications;
using app.web.application.interceptors;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(AttachCustomPrincipalSpecs))]
  public class AttachCustomPrincipalSpecs
  {
    public abstract class concern : Observes<IInterceptWithoutForwardingTheCall,
                                      AttachCustomPrincipal>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        fake_principal = fake.an<IPrincipal>();
        ticket = new FormsAuthenticationTicket(1, String.Empty, DateTime.Now, DateTime.Now, false, "1001");
        depends.on<GetTheCurrentTicket>(() => ticket);
        depends.on<PrincipalFactory>(x =>
        {
          x.ShouldEqual(1001);
          return fake_principal;
        });
        depends.on<GetTheCurrentUserIDFromTicket>(x =>
        {
          x.ShouldEqual(ticket);
          return 1001;
        });
        depends.on<PrincipalSwitch>(x =>
        {
          web_principal = x;
          thread_principal = x;
        });

        request = fake.an<IProvideDetailsToCommands>();
      };

      Because b = () =>
        sut.process(request);

      It should_run_the_principal_switch_behaviour_with_the_principal_created_from_the_current_ticket_information =
        () =>
        {
          thread_principal.ShouldEqual(fake_principal);
          web_principal.ShouldEqual(fake_principal);
        };

      static IPrincipal thread_principal;
      static IPrincipal the_principal_created_from_the_ticket;
      static IPrincipal web_principal;
      static IProvideDetailsToCommands request;
      static FormsAuthenticationTicket ticket;
      static IPrincipal fake_principal;
    }
  }
}