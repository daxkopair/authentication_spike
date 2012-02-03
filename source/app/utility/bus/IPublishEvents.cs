
namespace app.utility.bus
{
  public interface IPublishEvents
  {
    void publish<Event>(Event the_business_event) where Event : IRepresentAMeaningfulBusinessEvent;
  }
}