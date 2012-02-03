using app.web.application.catalogbrowsing.reportmodels;

namespace app.web.application.catalogbrowsing.inputmodels
{
  public class ViewTheProductsInADepartmentRequest
  {
    public DepartmentItem department
    {
      get { return new DepartmentItem(); }
    }
  }
}