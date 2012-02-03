using System;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class make_sure_the_user_id_in_the_url_matches_the_user_id_on_the_principal_specs
  {
    public abstract class concern :
      Observes
        <IInterceptWithoutForwardingTheCall,
        make_sure_the_user_id_in_the_url_matches_the_user_id_in_the_principal<SomeRequest>>
    {
    }

    public class when_run : concern
    {
      public class and_the_user_ids_are_the_same
      {
        Establish context = () =>
        {
          request = fake.an<IProvideDetailsToCommands>();
          the_uri = new Uri("http://localhost/blah.aspx");
          depends.on<GetTheCurrentUrl_Behaviour>(() => the_uri);
          depends.on<IsAuthorizedUrl_Behaviour>(url =>
          {
            url.Equals(the_uri).ShouldBeTrue();
            return true;
          });
          redirect = depends.on<IRedirect>();
        };

        Because b = () => sut.process(request);

        It should_not_redirect_to_the_redirect_request = () =>
          redirect.never_received(x => x.to<SomeRequest>());

        static IRedirect redirect;
        static IProvideDetailsToCommands request;
        static Uri the_uri;
      }

      public class and_the_user_ids_are_not_the_same
      {
        Establish context = () =>
        {
          request = fake.an<IProvideDetailsToCommands>();
          the_uri = new Uri("http://localhsot/sdfsdf/as.aspx");
          depends.on<GetTheCurrentUrl_Behaviour>(() => the_uri);
          depends.on<IsAuthorizedUrl_Behaviour>(url =>
          {
            url.Equals(the_uri).ShouldBeTrue();
            return false;
          });
          redirect = depends.on<IRedirect>();
        };

        Because b = () =>
        {
          sut.process(request);
        };

        It should_redirect_to_the_redirect_request = () =>
        {
          redirect.received(x => x.to<SomeRequest>());
        };

        static IRedirect redirect;
        static IProvideDetailsToCommands request;
        static Uri the_uri;
      }
    }

    public class SomeRequest
    {
    }
  }
}