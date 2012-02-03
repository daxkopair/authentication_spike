using System.Data;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(DependencyFactory))]
  public class DependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateASingleItem,
                                      DependencyFactory>
    {
    }

    public class when_creating_the_item : concern
    {
      Establish c = () =>
      {
        the_created_item = new object();
        real_factory = depends.on<ICreateOneDependency>();
        real_factory.setup(x => x.create()).Return(the_created_item);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_created_by_the_actual_item_factory = () =>
        result.ShouldEqual(the_created_item);


      static object result;
      static object the_created_item;
      static ICreateOneDependency real_factory;
    }
    public class when_determining_if_it_can_create_an_item : concern
    {
      Establish c = () =>
      {
        depends.on<TypeMatchCriteria>(x => x == typeof(IDbConnection));
      };

      Because b = () =>
        result = sut.can_create(typeof(IDbConnection));

      It should_make_the_decision_using_its_type_specification = () =>
        result.ShouldBeTrue();

      static bool result;
    }
  }
}