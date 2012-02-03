using System.Web;
using app.utility;

namespace app.web.core.aspnet
{
  public class ResponseWriter
  {
    public static void write_info(string format, params object[] args)
    {
      HttpContext.Current.Response.Write("<br><p>{0}</p>".format_using(format.format_using(args)));
    }
  }
}