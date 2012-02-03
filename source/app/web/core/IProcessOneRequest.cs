namespace app.web.core
{
  public interface IProcessOneRequest : IImplementAFeature
  {
    bool can_process(IProvideDetailsToCommands request);
  }
}