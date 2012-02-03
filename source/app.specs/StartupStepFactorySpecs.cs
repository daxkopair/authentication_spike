using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupStepFactory))]
  public class StartupStepFactorySpecs
  {
    public abstract class concern : Observes<ICreateStartupSteps,
                                      StartupStepFactory>
    {
    }

    public class when_creating_a_step : concern
    {
      public class that_follows_all_the_conventions_for_a_startup_step
      {
        Establish c = () =>
        {
          the_startup_service = depends.on<IProvideStartupServices>();
        };

        Because b = () =>
          result = sut.create_step_for(typeof(AGoodStep));

        It should_return_the_step_created_with_the_right_details = () =>
          result.ShouldBeAn<AGoodStep>().startup_service.Equals(the_startup_service).ShouldBeTrue();

        static IRunAStartupStep result;
        static IProvideStartupServices the_startup_service;
      }
    }

    public class ABadStep : IRunAStartupStep
    {
      public void run()
      {
      }
    }

    public class AGoodStep : IRunAStartupStep
    {
      public IProvideStartupServices startup_service;

      public AGoodStep(IProvideStartupServices startup_service)
      {
        this.startup_service = startup_service;
      }

      public void run()
      {
      }
    }
  }
}