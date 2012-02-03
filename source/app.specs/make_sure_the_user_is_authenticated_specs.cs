using Machine.Specifications;
using app.web.application.interceptors;
using app.web.core;
using app.web.core.stubs;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(MakeSureTheUserIsAuthenticated<SomeRequest>))]
  public class make_sure_the_user_is_authenticated_specs
  {
    public abstract class concern : Observes<IInterceptWithoutForwardingTheCall ,
                                      MakeSureTheUserIsAuthenticated<SomeRequest>>
    {
    }

    public class when_run : concern
    {
      public class and_the_user_is_authenticated
      {
        Establish c = () =>
        {
          redirect = depends.on<IRedirect>();
          request = fake.an<IProvideDetailsToCommands>();
          depends.on<GetTheCurrentPrincipal<StubPrincipal>>(() => new StubPrincipal(1));
        };

        Because b = () =>
          sut.process(request);


        It should_not_redirect_to_the_alternative_request = () =>
          redirect.never_received(x => x.to<SomeRequest>());

        static IRedirect redirect;
        static IProvideDetailsToCommands request;
      }
    }

    public class SomeRequest
    {
    }
  }
}