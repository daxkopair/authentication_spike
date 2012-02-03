using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.containers.basic
{
  public class DependencyFactories : IFindFactoriesForTypes
  {
    IEnumerable<ICreateASingleItem> all_factories;
    MissingFactoryExceptionProvider missing_exception_provider;

    public DependencyFactories(IEnumerable<ICreateASingleItem> all_factories,
                               MissingFactoryExceptionProvider missing_exception_provider)
    {
      this.all_factories = all_factories;
      this.missing_exception_provider = missing_exception_provider;
    }

    public ICreateASingleItem get_the_factory_that_can_create(Type type)
    {
      return Wrap.the_block(() => all_factories.First(factory => factory.can_create(type)))
        .throw_error_on<Exception>(inner => missing_exception_provider(type))
        .run();
    }
  }
}