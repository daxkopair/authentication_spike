using app.utility.bus;
using app.web.application.messages;

namespace app.cartdetails
{
  public class UpdateRunningTotalsHandler : IHandleABusinessEventOf<IAddedItemsToTheCart>
  {
    public void handle(IAddedItemsToTheCart the_event)
    {
      throw new System.NotImplementedException();
    }
  }

  public class UpdateCartDetailsHandler : IHandleABusinessEventOf<IAddedItemsToTheCart>
  {
    public void handle(IAddedItemsToTheCart the_event)
    {
      throw new System.NotImplementedException();
    }
  }
}