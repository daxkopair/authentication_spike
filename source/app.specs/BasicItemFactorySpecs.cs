using System;
using System.Data;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(BasicItemFactory))]
  public class BasicItemFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneDependency,
                                      BasicItemFactory>
    {
    }

    public class when_creating_an_item : concern
    {
      Establish c = () =>
      {
        the_connection = fake.an<IDbConnection>();
        depends.on<Func<object>>(() => the_connection);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_created_by_its_provided_delegate = () =>
        result.ShouldEqual(the_connection);

      static object result;
      static IDbConnection the_connection;
    }
  }
}