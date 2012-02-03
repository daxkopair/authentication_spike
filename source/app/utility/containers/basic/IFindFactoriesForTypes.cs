using System;

namespace app.utility.containers.basic
{
  public interface IFindFactoriesForTypes
  {
    ICreateASingleItem get_the_factory_that_can_create(Type type);
  }
}