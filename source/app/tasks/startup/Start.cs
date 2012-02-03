using System;
using System.Collections.Generic;
using app.utility.containers;
using app.utility.containers.basic;
using System.Linq;

namespace app.tasks.startup
{
  public class TheType
  {
    public static TypeMatchCriteria matches(Type contract)
    {
      return the_type => the_type == contract;
    }
    public static TypeMatchCriteria matches<Contract>()
    {
      return the_type => the_type == typeof(Contract);
    }
  }

  public class LazyContainer : IFetchDependencies
  {
    public static IFetchDependencies instance = new LazyContainer();

    public Dependency an<Dependency>()
    {
      return Container.fetch.an<Dependency>();
    }

    public object an(Type dependency)
    {
      return Container.fetch.an(dependency); 
    }
  }

  public class StartupServices : List<ICreateASingleItem>,IProvideStartupServices
  {
    IPickTheCtorOnAType greedy_constructor = new GreedyConstructorSelection();

    public void register<Contract, Implementation>()
    {
      register_factory(typeof(Contract),new AutomaticItemFactory(typeof(Implementation),
        greedy_constructor, LazyContainer.instance));
    }

    public Dependency fetch<Dependency>()
    {
      return LazyContainer.instance.an<Dependency>();
    }

    void register_factory(Type contract,ICreateOneDependency real_factory)
    {
      if (this.Any(x => x.can_create(contract))) return;
      Add(new DependencyFactory(TheType.matches(contract),
        real_factory)); 
    }
    void register_factory<Contract>(ICreateOneDependency real_factory)
    {
      if (this.Any(x => x.can_create(typeof(Contract)))) return;
      Add(new DependencyFactory(TheType.matches<Contract>(),
        real_factory)); 
    }

    public void register<Contract>()
    {
      register<Contract,Contract>();
    }

    public void register(Type contract)
    {
      register(contract,contract);
    }

    public IEnumerable<Type> all_registerable_types()
    {
      return this.GetType().Assembly.GetTypes().Where(x => x.IsClass)
        .Where(x => ! x.IsAbstract);
    }

    public void register(Type contract,Type implementation)
    {
      register_factory(contract,new AutomaticItemFactory(implementation,
        greedy_constructor, LazyContainer.instance));
    }

    public void register_instance<Contract>(Contract instance)
    {
      register_factory<Contract>(new BasicItemFactory(() => instance));
    }
  }

  public static class Start
  {
    public static Func<Type,IBuildStartupChains> chain_builder_factory = type =>
      new StartupChainBuilder(type, new List<IRunAStartupStep>(),new StartupStepFactory(
        new StartupServices()));

    public static IBuildStartupChains by<Step>() where Step : IRunAStartupStep
    {
      return chain_builder_factory(typeof(Step));
    }
  }
}