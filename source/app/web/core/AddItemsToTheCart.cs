using app.utility.bus;
using app.web.application.messages;

namespace app.web.core
{
  public class AddItemsToTheCart : IImplementAFeature
  {
    IPublishEvents bus;
    ICreateBusinessEvents event_factory;

    public AddItemsToTheCart(IPublishEvents bus, ICreateBusinessEvents event_factory)
    {
      this.bus = bus;
      this.event_factory = event_factory;
    }

    public void process(IProvideDetailsToCommands request)
    {
      bus.publish(event_factory.create_event_for<IAddedItemsToTheCart>(request.map<AddItemsToTheCartMessage>()));
    }
  }
}