using System.Collections.Generic;
using app.utility;
using app.web.application.catalogbrowsing.reportmodels;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;

namespace app.web.application.catalogbrowsing.queries
{
  public class GetTheMainDepartments : IFetchA<IEnumerable<DepartmentItem>>,IFetchInformation
  {
    public IEnumerable<DepartmentItem> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreDirectory>().get_the_main_departments();
    }
  }
}