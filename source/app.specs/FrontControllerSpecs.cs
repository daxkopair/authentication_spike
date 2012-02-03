 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests,
                                      FrontController>
    {
        
    }

   
    public class when_processing_a_request : concern
    {

      Establish c = () =>
      {
        command_registry = depends.on<IFindCommands>();
        command_that_can_process = fake.an<IProcessOneRequest>();
        request = fake.an<IProvideDetailsToCommands>();

        command_registry.setup(x => x.get_the_command_that_can_process(request)).Return(command_that_can_process);
      };

      Because b = () =>
        sut.process(request);

      It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
        command_that_can_process.received(x => x.process(request));

      static IProcessOneRequest command_that_can_process;
      static IProvideDetailsToCommands request;
      static IFindCommands command_registry;
    }
  }
}
