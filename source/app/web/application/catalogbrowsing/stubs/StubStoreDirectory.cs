using System.Collections.Generic;
using System.Linq;
using app.web.application.catalogbrowsing.reportmodels;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubStoreDirectory : IProvideInformationAboutTheStore
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_the_departments_in(DepartmentItem parent)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Sub Department 0")});
    }

    public IEnumerable<ProductItem> get_the_products_in_a_department(DepartmentItem parent)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem {name = x.ToString("Product 0")});
    }
  }
}