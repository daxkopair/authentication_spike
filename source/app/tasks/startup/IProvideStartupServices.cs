using System;
using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public interface IProvideStartupServices : IEnumerable<ICreateASingleItem>
  {
    void register<Contract, Implementation>();
    void register<Contract>();
    void register(Type contract);
    void register_instance<Contract>(Contract instance);
    Dependency fetch<Dependency>();
    IEnumerable<Type> all_registerable_types();
  }
}