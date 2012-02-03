using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Startup))]
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_completed : concern
    {
      Because b = () =>
        Startup.run();

      It should_be_able_to_access_key_application_services = () =>
      {
        Container.fetch.an<IProcessRequests>().ShouldBeAn<FrontController>();
        Container.fetch.an<PageFactory>().ShouldNotBeNull();
        Container.fetch.an<GetTheCurrentlyExecutingRequest>().ShouldNotBeNull();
      };
        
    }
  }
}
