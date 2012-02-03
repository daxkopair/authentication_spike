using System;

namespace app.utility.containers.basic
{
  public class DependencyFactory :ICreateASingleItem
  {
    TypeMatchCriteria criteria;
    ICreateOneDependency real_factory;

    public DependencyFactory(TypeMatchCriteria criteria, ICreateOneDependency real_factory)
    {
      this.criteria = criteria;
      this.real_factory = real_factory;
    }

    public bool can_create(Type type)
    {
      return criteria(type);  
    }

    public object create()
    {
      return real_factory.create();
    }
  }
}