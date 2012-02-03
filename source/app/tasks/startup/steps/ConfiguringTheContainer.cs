using app.utility.containers;
using app.utility.containers.basic;

namespace app.tasks.startup.steps
{
  public class ConfiguringTheContainer : IRunAStartupStep
  {
    IProvideStartupServices startup_service;

    public ConfiguringTheContainer(IProvideStartupServices startup_service)
    {
      this.startup_service = startup_service;
    }

    public void run()
    {
      var the_container =
        new DependencyContainer(
          new DependencyFactories(startup_service, StartupItems.exceptions.missing_dependency_factory),
          StartupItems.exceptions.item_creation_error);

      ContainerFacadeResolution container_resolution = () => the_container;
      Container.facade_resolution = container_resolution;
      startup_service.register_instance(startup_service);
      startup_service.register_instance<IFetchDependencies>(the_container);
    }
  }
}