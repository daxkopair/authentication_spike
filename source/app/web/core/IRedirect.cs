namespace app.web.core
{
  public interface IRedirect
  {
    void to<Request>(); 
  }
  public delegate void RawRedirect_Behaviour(string url);

  public class Redirect : IRedirect
  {
    RawRedirect_Behaviour raw;

    public Redirect(RawRedirect_Behaviour raw)
    {
      this.raw = raw;
    }

    public void to<Request>()
    {
      raw(UrlBuilder.url_to_run<Request>());
    }
  }
}