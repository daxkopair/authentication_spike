 using Machine.Specifications;
 using app.utility.bus;
 using app.web.application.messages;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(AddItemsToTheCart))]  
  public class AddItemsToTheCartSpecs
  {
    public abstract class concern : Observes<IImplementAFeature,
                                      AddItemsToTheCart>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        bus = depends.on<IPublishEvents>();
        add_message = new AddItemsToTheCartMessage();
        request = fake.an<IProvideDetailsToCommands>();
        event_factory = depends.on<ICreateBusinessEvents>();
        items_added_to_cart_event = fake.an<IAddedItemsToTheCart>();

        request.setup(x => x.map<AddItemsToTheCartMessage>()).Return(add_message);

        event_factory.setup(x => x.create_event_for<IAddedItemsToTheCart>(add_message))
          .Return(items_added_to_cart_event);
      };
      Because b = () =>
        sut.process(request);

      It should_publish_an_items_added_to_cart_message_onto_the_bus = () =>
        bus.received(x => x.publish(items_added_to_cart_event));

      static IPublishEvents bus;
      static IAddedItemsToTheCart items_added_to_cart_event;
      static IProvideDetailsToCommands request;
      static AddItemsToTheCartMessage add_message;
      static ICreateBusinessEvents event_factory;
    }
  }
}
