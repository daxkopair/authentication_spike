using System;

namespace app.tasks.startup
{
  public class StartupStepFactory : ICreateStartupSteps
  {
    IProvideStartupServices startup_service;

    public StartupStepFactory(IProvideStartupServices startup_service)
    {
      this.startup_service = startup_service;
    }

    public IRunAStartupStep create_step_for(Type step_type)
    {
      return (IRunAStartupStep) Activator.CreateInstance(step_type, startup_service);
    }
  }
}