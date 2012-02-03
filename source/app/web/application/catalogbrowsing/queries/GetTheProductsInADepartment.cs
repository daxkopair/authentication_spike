using System.Collections.Generic;
using app.utility;
using app.web.application.catalogbrowsing.inputmodels;
using app.web.application.catalogbrowsing.reportmodels;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;

namespace app.web.application.catalogbrowsing.queries
{
  public class GetTheProductsInADepartment : IFetchA<IEnumerable<ProductItem>>, IFetchInformation
  {
    public IEnumerable<ProductItem> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreDirectory>().get_the_products_in_a_department(
        request.map<ViewTheProductsInADepartmentRequest>().department);
    }
  }
}