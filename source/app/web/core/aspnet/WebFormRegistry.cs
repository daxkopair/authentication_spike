using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormRegistry : IFindViewsToDisplayReportModels
  {
    IFindPathsToViews path_registry;
    PageFactory page_factory;

    public WebFormRegistry(IFindPathsToViews path_registry, PageFactory page_factory)
    {
      this.path_registry = path_registry;
      this.page_factory = page_factory;
    }

    public IHttpHandler get_view_that_can_display<ReportModel>(ReportModel model)
    {
      var path = path_registry.get_path_to_view_that_can_display<ReportModel>();
      var view = (IDisplayA<ReportModel>) page_factory(path, typeof(IDisplayA<ReportModel>));
      view.report = model;
      return view;
    }
  }
}