using System;
using System.Collections;
using System.Collections.Generic;
using app.utility;

namespace app.tasks.startup
{
  public class StartupChainBuilder : IBuildStartupChains
  {
    public IList<IRunAStartupStep> steps;
    ICreateStartupSteps step_factory;

    public StartupChainBuilder(Type initial_step, IList<IRunAStartupStep> steps, ICreateStartupSteps step_factory)
    {
      this.steps = steps;
      this.step_factory = step_factory;
      steps.Add(step_factory.create_step_for(initial_step));
    }

    public IBuildStartupChains followed_by<NextStep>() where NextStep : IRunAStartupStep
    {
      return new StartupChainBuilder(typeof(NextStep), new List<IRunAStartupStep>(steps), step_factory);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IRunAStartupStep> GetEnumerator()
    {
      return steps.GetEnumerator();
    }

    public void finish_by<LastStep>() where LastStep : IRunAStartupStep
    {
      followed_by<LastStep>().each(x => x.run());
    }
  }
}