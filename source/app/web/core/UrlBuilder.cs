using System.Web;

namespace app.web.core
{
  public class UrlBuilder
  {
    public static string url_to_run<RequestModel>()
    {
      return HttpUtility.UrlEncode(string.Format("{0}.orlando", typeof(RequestModel).Name));
    } 
  }
}