using app.cartdetails;

namespace app.utility.bus
{
  public interface IHandleABusinessEventOf<EventType> where EventType : IRepresentAMeaningfulBusinessEvent
  {
    void handle(EventType the_event);
  }
}