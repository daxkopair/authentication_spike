using System;

namespace app.utility.containers
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
    object an(Type dependency);
  }
}