using System;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_provided_the_first_command_to_run_in_a_startup_chain : concern
    {
      Establish c = () =>
      {
        the_chain_builder = fake.an<IBuildStartupChains>();
        Func<Type, IBuildStartupChains> builder_factory = type =>
        {
          type.ShouldEqual(typeof(TheFirstStep));
          return the_chain_builder; 
        };
        spec.change(() => Start.chain_builder_factory).to(builder_factory);
      };
      Because b = () =>
        result = Start.by<TheFirstStep>();

      It should_return_the_startup_chain_builder_created_from_the_first_step = () =>
        result.Equals(the_chain_builder).ShouldBeTrue();

      static IBuildStartupChains result;
      static IBuildStartupChains the_chain_builder;
    }

    public class TheFirstStep : IRunAStartupStep
    {
      public void run()
      {
        throw new System.NotImplementedException();
      }
    }
  }
}