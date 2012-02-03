using System;
using System.Reflection;

namespace app.utility.containers.basic
{
  public interface IPickTheCtorOnAType
  {
    ConstructorInfo get_applicable_constructor_on(Type type);
  }
}