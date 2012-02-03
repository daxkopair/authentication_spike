using System;

namespace app.utility.containers.basic
{
  public delegate Exception MissingFactoryExceptionProvider(Type type_that_has_no_factory_to_create_it);
}