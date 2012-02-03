namespace app.web.core
{
  public interface IFetchA<out Report>
  {
    Report fetch_using(IProvideDetailsToCommands request);
  }
}