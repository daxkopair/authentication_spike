namespace app.utility.bus
{
  public interface ICreateBusinessEvents
  {
    EventType create_event_for<EventType>(object event_data) where EventType : IRepresentAMeaningfulBusinessEvent;
  }
}