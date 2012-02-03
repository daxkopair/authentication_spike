using System;
using System.Linq;
using System.Reflection;

namespace app.utility.containers.basic
{
  public class GreedyConstructorSelection : IPickTheCtorOnAType
  {
    public ConstructorInfo get_applicable_constructor_on(Type type)
    {
      return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
    }
  }
}