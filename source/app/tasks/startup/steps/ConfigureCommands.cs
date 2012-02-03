using app.web.application.catalogbrowsing.reports;

namespace app.tasks.startup.steps
{
  public class ConfigureCommands : IRunAStartupStep
  {
    IProvideStartupServices startup_service;

    public ConfigureCommands(IProvideStartupServices startup_service)
    {
      this.startup_service = startup_service;
    }

    public void run()
    {
      startup_service.register<ViewTheMainDepartments>();
      startup_service.register<ViewTheDepartmentsInADepartment>();
      startup_service.register<ViewTheProductsInADepartment>();
    }
  }
}