namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    IFindViewsToDisplayReportModels view_registry;
    GetTheCurrentlyExecutingRequest current_request_resolution;

    public WebFormDisplayEngine(IFindViewsToDisplayReportModels view_registry,
                                GetTheCurrentlyExecutingRequest current_request_resolution)
    {
      this.view_registry = view_registry;
      this.current_request_resolution = current_request_resolution;
    }

    public void display<ReportModel>(ReportModel model)
    {
      view_registry.get_view_that_can_display(model).ProcessRequest(current_request_resolution());
    }
  }
}