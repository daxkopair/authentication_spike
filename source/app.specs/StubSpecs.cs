using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Stub))]
  public class StubSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_a_stub_is_requested  : concern
    {
      It should_return_the_stub_instance = () =>
        Stub.with<SomeStub>().ShouldBeAn<SomeStub>();
        
    }

    public class SomeStub
  {
  }
  }

}
