using System;

namespace app.utility.containers.basic
{
  public delegate Exception ItemCreationExceptionFactory(Type type_that_could_not_be_created,Exception inner);
}