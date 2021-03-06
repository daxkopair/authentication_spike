using System.Web.Security;
using Machine.Specifications;
using app.specs.utility;
using app.web.application.catalogbrowsing.reports;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Login))]
  public class LoginSpecs
  {
    public abstract class concern : Observes<IImplementAFeature, Login>
    {
    }

    public class when_run : concern
    {
      public class and_they_are_an_authorized_user
      {
        Establish c = () =>
        {
          the_created_ticket = ObjectFactory.web.create_fake_authentication_ticket();
          depends.on<Authentication_Behaviour>((user, pass) => true);
          request = fake.an<IProvideDetailsToCommands>();
          depends.on<CreateAuthenticationTicketBehaviour>(username => the_created_ticket);
          depends.on<AssociateTicketWithCurrentUser_Behaviour>(x =>
          {
            updated_ticket = x;
            x.ShouldEqual(the_created_ticket);
          });
        };

        Because b = () =>
          sut.process(request);

        It should_apply_authentication_using_the_create_authentication_ticket = () =>
          updated_ticket.ShouldEqual(the_created_ticket);

        static IProvideDetailsToCommands request;
        static FormsAuthenticationTicket updated_ticket;
        static FormsAuthenticationTicket the_created_ticket;
      }
    }
  }
}