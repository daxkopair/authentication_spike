using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.reportmodels;

namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry : IFindPathsToViews
  {
    public string get_path_to_view_that_can_display<ReportModel>()
    {
      var pages = new Dictionary<Type, string>();
      pages.Add(typeof(IEnumerable<DepartmentItem>), "Department");
      pages.Add(typeof(IEnumerable<ProductItem>), "Product");

      return build_path_for(pages[typeof(ReportModel)]);
    }

    string build_path_for(string path)
    {
      return string.Format("~/views/{0}Browser.aspx", path);
    }
  }
}