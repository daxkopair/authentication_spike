using System.Collections.Generic;

namespace app.tasks.startup
{
  public interface IBuildStartupChains : IEnumerable<IRunAStartupStep>
  {
    IBuildStartupChains followed_by<NextStep>() where NextStep : IRunAStartupStep;
    void finish_by<LastStep>() where LastStep : IRunAStartupStep;
  }
}