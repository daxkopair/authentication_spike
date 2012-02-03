using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes

    {
    }
    public class when_accessing_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IFetchDependencies>();
        ContainerFacadeResolution resolution = () => the_container_facade;

        spec.change(() => Container.facade_resolution).to(resolution);
      };

      Because b = () =>
        result = Container.fetch;

      It should_return_the_container_facade_accessed_through_the_resolution_mechanism = () =>
        result.ShouldEqual(the_container_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_container_facade;
    }
  }
}