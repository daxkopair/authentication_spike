namespace app.web.core
{
  public class ChainedAction<FirstCommand, NextCommand> : IImplementAFeature
    where NextCommand : IImplementAFeature
    where FirstCommand : IImplementAFeature
  {
    NextCommand next;
    FirstCommand first;

    public ChainedAction(FirstCommand first, NextCommand next)
    {
      this.next = next;
      this.first = first;
    }

    public void process(IProvideDetailsToCommands request)
    {
      first.process(request);
      next.process(request);
    }
  }
}