using System;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class StartupItems
  {
    public static class exceptions
    {
      public static MissingFactoryExceptionProvider missing_dependency_factory = type_that_has_no_factory =>
        new Exception(string.Format("There is no factory that can create a {0}", type_that_has_no_factory.Name));

      public static ItemCreationExceptionFactory item_creation_error = (type, inner) =>
        new Exception(
          string.Format("There was an error creating the type {0}", type.Name),
          inner);
    }
  }
}