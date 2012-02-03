using System.Web;

namespace app.web.core.aspnet
{
  public interface IFindViewsToDisplayReportModels
  {
    IHttpHandler get_view_that_can_display<ReportModel>(ReportModel model);
  }
}