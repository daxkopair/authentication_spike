using System.Collections.Generic;
using app.web.application.catalogbrowsing.reportmodels;

namespace app.web.application.catalogbrowsing
{
  public interface IProvideInformationAboutTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
    IEnumerable<DepartmentItem> get_the_departments_in(DepartmentItem department);
    IEnumerable<ProductItem> get_the_products_in_a_department(DepartmentItem parentDepartment);
  }
}