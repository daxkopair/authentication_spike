using System;
using System.Linq;

namespace app.utility.containers.basic
{
  public class AutomaticItemFactory : ICreateOneDependency
  {
     Type type;
     IPickTheCtorOnAType ctor_picker;
     IFetchDependencies container;

    public AutomaticItemFactory(Type type, IPickTheCtorOnAType ctor_picker, IFetchDependencies container)
    {
      this.type = type;
      this.ctor_picker = ctor_picker;
      this.container = container;
    }

    public object create()
    {
      var ctor = ctor_picker.get_applicable_constructor_on(type);
      var ctor_params = ctor.GetParameters().Select(x => container.an(x.ParameterType));
      return ctor.Invoke(ctor_params.ToArray());
    }
  }
}