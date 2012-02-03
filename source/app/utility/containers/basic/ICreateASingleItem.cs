using System;

namespace app.utility.containers.basic
{
  public interface ICreateASingleItem : ICreateOneDependency
  {
    bool can_create(Type type);
  }
}