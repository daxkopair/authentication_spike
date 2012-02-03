using System;
using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupItems))]
  public class StartupItemsSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class the_exception_created : concern
    {
      public class when_there_is_an_error_creating_an_item
      {
        Because b = () =>
          result = StartupItems.exceptions.item_creation_error;

        It should_create_the_exception_correctly = () =>
        {
          var the_inner = new Exception();
          var item = result(typeof(int),the_inner);
          item.Message.ShouldContain(typeof(int).Name);
          item.InnerException.ShouldEqual(the_inner);
        };

        static ItemCreationExceptionFactory result;
      }
      public class when_there_is_no_dependency_factory_for_a_dependency
      {
        Because b = () =>
          result = StartupItems.exceptions.missing_dependency_factory;

        It should_contain_the_name_of_the_type_that_has_no_factory = () =>
        {
          var item = result(typeof(int));
          item.Message.ShouldContain(typeof(int).Name);
        };

        static MissingFactoryExceptionProvider result;
      }
    }
  }
}