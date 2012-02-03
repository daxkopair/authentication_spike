using System;
using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(CallingTypeResolver))]
  public class CallingTypeResolverSpecs
  {
    public abstract class concern : Observes<IResolveTheCallingType,
                                      CallingTypeResolver>
    {
    }

    public class when_resolving_the_calling_type : concern
    {
      Because b = () =>
        result = sut.resolve();

      It should_return_the_type_that_invoked_it = () =>
        result.ShouldEqual(typeof(when_resolving_the_calling_type));

      static Type result;
    }
  }
}