using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(StartupChainBuilder))]
  public class StartupChainBuilderSpecs
  {
    public abstract class concern : Observes<IBuildStartupChains,
                                      StartupChainBuilder>
    {
    }

    public class when_created : concern
    {
      Establish c = () =>
      {
        first_step = fake.an<IRunAStartupStep>();
        list_of_steps = new List<IRunAStartupStep>();
        step_factory = depends.on<ICreateStartupSteps>();
        depends.on(typeof(OneStep));
        depends.on(list_of_steps);

        step_factory.setup(x => x.create_step_for(typeof(OneStep))).Return(first_step);
      };

      It should_add_its_first_step_to_the_list_of_all_steps_to_run = () =>
        list_of_steps.ShouldContain(first_step);

      static IList<IRunAStartupStep> list_of_steps;
      static IRunAStartupStep first_step;
      static ICreateStartupSteps step_factory;
    }

    public class concern_for_a_created_chain_builder : concern
    {
      Establish c = () =>
      {
        first_step = fake.an<IRunAStartupStep>();
        list_of_steps = new List<IRunAStartupStep>();
        step_factory = depends.on<ICreateStartupSteps>();
        depends.on(typeof(OneStep));
        depends.on(list_of_steps);

        step_factory.setup(x => x.create_step_for(typeof(OneStep))).Return(first_step);
      };

      protected static IList<IRunAStartupStep> list_of_steps;
      protected static IRunAStartupStep first_step;
      protected static ICreateStartupSteps step_factory;
    }

    public class when_followed_by_another_step : concern_for_a_created_chain_builder
    {
      Establish c = () =>
      {
        second_step = fake.an<IRunAStartupStep>();
        step_factory.setup(x => x.create_step_for(typeof(SecondStep)))
          .Return(second_step);
      };

      Because b = () =>
        result = sut.followed_by<SecondStep>();

      It should_add_the_next_step_to_the_set_of_all_steps = () =>
        result.downcast_to<StartupChainBuilder>().steps.ShouldContain(first_step, second_step);

      It should_return_a_new_builder_to_continue_specifying_steps = () =>
      {
        var item = result.ShouldBeAn<StartupChainBuilder>();
        item.ShouldNotEqual(sut);
        item.steps.ShouldNotEqual(list_of_steps);
      };
        

      static IRunAStartupStep second_step;
      static IBuildStartupChains result;
    }

    public class when_the_final_step_is_specified : concern_for_a_created_chain_builder
    {
      Establish c = () =>
      {
        second_step = fake.an<IRunAStartupStep>();
        step_factory.setup(x => x.create_step_for(typeof(SecondStep)))
          .Return(second_step);
      };

      Because b = () =>
        sut.finish_by<SecondStep>();

      It should_run_all_of_the_steps_in_the_chain_including_the_last_one_added = () =>
      {
        first_step.received(x => x.run());
        second_step.received(x => x.run());
      };
        

      static IRunAStartupStep second_step;
      static IBuildStartupChains result;
    }

    public class OneStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }

    public class SecondStep:IRunAStartupStep
  {
      public void run()
      {
        throw new NotImplementedException();
      }
  }
  }

}