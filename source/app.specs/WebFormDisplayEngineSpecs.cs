using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.application;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_a_report : concern
    {
      Establish c = () =>
      {
        report_model = new SomeReport();
        current_request = ObjectFactory.web.create_http_context();
        depends.on<GetTheCurrentlyExecutingRequest>(() => current_request);
        view_that_can_display_the_report = fake.an<IHttpHandler>();
        view_registry = depends.on<IFindViewsToDisplayReportModels>();
        view_registry.setup(x => x.get_view_that_can_display(report_model)).Return(view_that_can_display_the_report);
      };

      Because b = () =>
        sut.display(report_model);

      It should_tell_the_view_to_render_using_the_current_http_context = () =>
        view_that_can_display_the_report.received(x => x.ProcessRequest(current_request));
        

      static IFindViewsToDisplayReportModels view_registry;
      static SomeReport report_model;
      static IHttpHandler view_that_can_display_the_report;
      static HttpContext current_request;
    }

    class SomeReport
    {
    }
  }
}