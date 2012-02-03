using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(RequestCommand))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
        depends.on<RequestCriteria>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_process(request);

      It should_make_the_determination_by_leveraging_its_request_specification = () =>
        result.ShouldBeTrue();

      static IProvideDetailsToCommands request;
      static bool result;
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
        application_behaviour = depends.on<IImplementAFeature>();
      };

      Because b = () =>
        sut.process(request);

      It should_delegate_processing_to_the_app_feature_for_the_request = () =>
        application_behaviour.received(x => x.process(request));

      static IProvideDetailsToCommands request;
      static IImplementAFeature application_behaviour;
    }
  }
}