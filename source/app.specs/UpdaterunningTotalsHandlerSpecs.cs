using Machine.Specifications;
using app.cartdetails;
using app.utility.bus;
using app.web.application.messages;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(UpdateRunningTotalsHandler))]
  public class UpdaterunningTotalsHandlerSpecs
  {
    public abstract class concern : Observes<IHandleABusinessEventOf<IAddedItemsToTheCart>,
                                      UpdateRunningTotalsHandler>
    {
    }

    public class when_processing : concern
    {
        Establish c = () =>
                          {
                              added_items = fake.an<IAddedItemsToTheCart>();
                          };

        It should_locate_the_current_running_total = () =>
                                                     sut.handle( added_items );


        static RunningTotal current_total;
        static IAddedItemsToTheCart added_items;

    }
  }
}