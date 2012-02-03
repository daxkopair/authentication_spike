using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ASPHandler))]
  public class ASPHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      ASPHandler>
    {
    }

    public class when_processing_an_incoming_http_context : concern
    {
      Establish c = () =>
      {
        current_request = ObjectFactory.web.create_http_context();
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateControllerRequests>();
        a_new_controller_request = fake.an<IProvideDetailsToCommands>();

        request_factory.setup(x => x.create_controller_request(current_request)).Return(a_new_controller_request);
      };

      Because b = () =>
        sut.ProcessRequest(current_request);

      It should_delegate_the_processing_of_a_controller_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(a_new_controller_request));

      static IProcessRequests front_controller;
      static IProvideDetailsToCommands a_new_controller_request;
      static HttpContext current_request;
      static ICreateControllerRequests request_factory;
    }
  }
}