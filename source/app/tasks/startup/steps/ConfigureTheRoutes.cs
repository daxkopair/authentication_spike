using app.web.application.catalogbrowsing.inputmodels;
using app.web.application.catalogbrowsing.reports;
using app.web.core;

namespace app.tasks.startup.steps
{
  public class ConfigureTheRoutes : IRunAStartupStep
  {
    IProvideStartupServices startup;

    public ConfigureTheRoutes(IProvideStartupServices startup)
    {
      this.startup = startup;
    }

    public void run()
    {
      Routes.to.a_report<ViewTheMainDepartmentsRequest, ViewTheMainDepartments>();
      Routes.to.a_report<ViewTheDepartmentsInDepartmentRequest, ViewTheDepartmentsInADepartment>();
      Routes.to.a_report<ViewTheProductsInADepartmentRequest, ViewTheProductsInADepartment>();
      Routes.to.prepare_routes();
    }
  }
}