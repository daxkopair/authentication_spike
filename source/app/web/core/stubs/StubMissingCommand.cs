namespace app.web.core.stubs
{
  public class StubMissingCommand:IProcessOneRequest
  {
    public void process(IProvideDetailsToCommands request)
    {

    }

    public bool can_process(IProvideDetailsToCommands request)
    {
      return false;
    }
  }
}