using System;
using System.Data;
using System.Reflection;
using Machine.Specifications;
using app.specs.utility;
using app.utility.containers;
using app.utility.containers.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(AutomaticItemFactory))]
  public class AutomaticItemFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneDependency,
                                      AutomaticItemFactory>
    {
    }

    public class when_creating_an_item : concern
    {
      Establish c = () =>
      {
        depends.on<Type>(typeof(ItemWithDependencies));
        constructor_selection_strategy = depends.on<IPickTheCtorOnAType>();
        the_container = depends.on<IFetchDependencies>();

        the_constructor_to_use_to_create_the_item = ObjectFactory.expressions.to_target<ItemWithDependencies>()
          .get_the_ctor_pointed_at_by(() => new ItemWithDependencies(null, null, null));

        the_connection = fake.an<IDbConnection>();
        the_command = fake.an<IDbCommand>();
        the_reader = fake.an<IDataReader>();

        the_container.setup(x => x.an(typeof(IDbConnection))).Return(the_connection);
        the_container.setup(x => x.an(typeof(IDbCommand))).Return(the_command);
        the_container.setup(x => x.an(typeof(IDataReader))).Return(the_reader);

        constructor_selection_strategy.setup(x => x.get_applicable_constructor_on(typeof(ItemWithDependencies)))
          .Return(the_constructor_to_use_to_create_the_item);
      };

      Because b = () =>
        result = sut.create();

      It should_create_the_item_with_all_of_its_dependencies_filled = () =>
      {
        var item = result.ShouldBeAn<ItemWithDependencies>();
        item.connection.ShouldEqual(the_connection);
        item.command.ShouldEqual(the_command);
        item.reader.ShouldEqual(the_reader);
      };

      static object result;
      static IDbConnection the_connection;
      static IDbCommand the_command;
      static IDataReader the_reader;
      static IFetchDependencies the_container;
      static IPickTheCtorOnAType constructor_selection_strategy;
      static ConstructorInfo the_constructor_to_use_to_create_the_item;
    }

    public class ItemWithDependencies
    {
      public IDbConnection connection;
      public IDbCommand command;
      public IDataReader reader;

      public ItemWithDependencies(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command;
      }

      public ItemWithDependencies(IDbConnection connection, IDbCommand command, IDataReader reader)
      {
        this.connection = connection;
        this.command = command;
        this.reader = reader;
      }
    }
  }
}