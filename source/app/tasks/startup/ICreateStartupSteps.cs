using System;

namespace app.tasks.startup
{
  public interface ICreateStartupSteps
  {
    IRunAStartupStep create_step_for(Type step_type);
  }
}