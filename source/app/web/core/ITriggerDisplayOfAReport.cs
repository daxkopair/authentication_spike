using app.tasks.startup;

namespace app.web.core
{
  public interface ICreateOneReport
  {
    IImplementAFeature create_report_for<Query, ReportModel>() where Query : IFetchA<ReportModel>; 
  }

  public class CreateOneReport : ICreateOneReport
  {
    IProvideStartupServices startup;

    public CreateOneReport(IProvideStartupServices startup)
    {
      this.startup = startup;
    }

    public IImplementAFeature create_report_for<Query, ReportModel>() where Query : IFetchA<ReportModel>
    {
      startup.register<ViewAReport<Query,ReportModel>>();
      return startup.fetch<ViewAReport<Query,ReportModel>>();
    }
  }
}