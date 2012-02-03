using Machine.Specifications;
using app.web.application.catalogbrowsing.reports;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Logout))]
  public class LogoutSpecs
  {
    public abstract class concern : Observes<IChangeSystemState,Logout>
    {

    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
        depends.on<Logout_Behaviour>(() => { logout_ran = true;});
      };
      
      Because b = () =>
        sut.process(request);
      
      
      It should_run_the_logout_behaviour = () =>
        logout_ran.ShouldBeTrue();


      static bool logout_ran;
      static IProvideDetailsToCommands request;
        
    }
  }
}
