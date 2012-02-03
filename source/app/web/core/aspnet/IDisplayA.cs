using System.Web;
using System.Web.UI;

namespace app.web.core.aspnet
{
  public interface IDisplayA<Report> : IHttpHandler
  {
    Report report { get; set; }
  }

  public class SimpleReport<Report> : Page, IDisplayA<Report>
  {
    public Report report { get; set; }
  }
}