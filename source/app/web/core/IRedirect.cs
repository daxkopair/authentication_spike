namespace app.web.core
{
  public interface IRedirect
  {
    void to<Request>(); 
  }
  public delegate void RawRedirect(string url);

  public class Redirect : IRedirect
  {
    RawRedirect raw;

    public Redirect(RawRedirect raw)
    {
      this.raw = raw;
    }

    public void to<Request>()
    {
      raw(UrlBuilder.url_to_run<Request>());
    }
  }
}