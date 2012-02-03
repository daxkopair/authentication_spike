namespace app.web.core
{
  public class RequestCommand : IProcessOneRequest
  {
    RequestCriteria request_criteria;
    IImplementAFeature application_behavior;

    public RequestCommand(RequestCriteria request_criteria, IImplementAFeature application_behavior)
    {
      this.request_criteria = request_criteria;
      this.application_behavior = application_behavior;
    }

    public void process(IProvideDetailsToCommands request)
    {
      application_behavior.process(request);
    }

    public bool can_process(IProvideDetailsToCommands request)
    {
      return request_criteria(request);
    }
  }
}