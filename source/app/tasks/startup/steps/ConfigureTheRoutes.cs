using app.web.application.catalogbrowsing.inputmodels;
using app.web.application.catalogbrowsing.reports;
using app.web.application.interceptors;
using app.web.application.login;
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
      Routes.to.a_report<ViewTheMainDepartmentsRequest, ViewTheMainDepartments>()
        .intercept_with<DisplayAuthenticationDetails>()
        .intercept_with<AttachCustomPrincipal>();

      Routes.to.a_report<ViewTheDepartmentsInDepartmentRequest, ViewTheDepartmentsInADepartment>()
        .intercept_with<DisplayAuthenticationDetails>()
        .intercept_with<MakeSureTheUserIsAuthenticated<ViewTheMainDepartmentsRequest>>()
        .intercept_with<AttachCustomPrincipal>();

      Routes.to.a_report<ViewTheProductsInADepartmentRequest, ViewTheProductsInADepartment>()
        .intercept_with<DisplayAuthenticationDetails>()
        .intercept_with<AttachCustomPrincipal>();

      Routes.to.a_command<LoginRequest, Login, ViewTheMainDepartmentsRequest>()
        .intercept_with<DisplayAuthenticationDetails>()
        .intercept_with<AttachCustomPrincipal>();

      Routes.to.prepare_routes();
    }
  }
}