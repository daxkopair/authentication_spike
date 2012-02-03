using Machine.Specifications;
using app.specs.utility;
using app.utility;
using app.utility.containers;
using app.utility.logging;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Log))]
  public class LogSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_access_to_a_logger : concern
    {
      Establish c = () =>
      {
        the_logger = fake.an<ILog>();

        using (var scaffold = ObjectFactory.container.scaffold(fake, spec))
        {
          logger_factory = scaffold.an<ICreateLoggers>();
          type_resolver = scaffold.an<IResolveTheCallingType>();
        }

        logger_factory.setup(x => x.create_logger_bound_to(typeof(LogSpecs))).Return(the_logger);
        type_resolver.setup(x => x.resolve()).Return(typeof(LogSpecs));
      };

      Because b = () =>
        result = Log.an;

      It should_return_a_logger_bound_to_the_calling_type = () =>
        result.ShouldEqual(the_logger);

      static ILog result;
      static ILog the_logger;
      static ICreateLoggers logger_factory;
      static IResolveTheCallingType type_resolver;
      static IFetchDependencies container;
    }
  }
}