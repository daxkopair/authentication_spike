using System;

namespace app.utility.containers.basic
{
  public class DependencyContainer : IFetchDependencies
  {
    IFindFactoriesForTypes factories;
    ItemCreationExceptionFactory item_creation_exception_factory;

    public DependencyContainer(IFindFactoriesForTypes factories,
                               ItemCreationExceptionFactory item_creation_exception_factory)
    {
      this.factories = factories;
      this.item_creation_exception_factory = item_creation_exception_factory;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency) an(typeof(Dependency));
    }

    public object an(Type dependency)
    {
      var factory = factories.get_the_factory_that_can_create(dependency);

      return Wrap.the_block(() => factory.create())
        .throw_error_on<Exception>(inner => item_creation_exception_factory(dependency, inner)).run();
      
    }
  }
}