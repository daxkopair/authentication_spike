using System.Collections.Generic;
using app.web.application.catalogbrowsing.queries;
using app.web.application.catalogbrowsing.reportmodels;
using app.web.core;

namespace app.web.application.catalogbrowsing.reports
{

  public class ViewTheMainDepartments : IDisplayAReport
  {
    public void process(IProvideDetailsToCommands request)
    {
      new ViewAReport<GetTheMainDepartments,IEnumerable<DepartmentItem>>().process(request);
    }
  }
}