using System;

namespace app.utility.containers.basic
{
  public class BasicItemFactory : ICreateOneDependency
  {
    Func<object> factory;

    public BasicItemFactory(Func<object> factory)
    {
      this.factory = factory;
    }

    public object create()
    {
      return factory();
    }
  }
}