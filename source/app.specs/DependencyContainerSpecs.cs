using System;
using Machine.Specifications;
using app.utility.containers;
using app.utility.containers.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyContainer))]
  public class DependencyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      DependencyContainer>
    {
    }

    public class when_fetching_a_type : concern
    {
      public class in_a_runtime_context
      {
        Establish c = () =>
        {
          type_factories = depends.on<IFindFactoriesForTypes>();
          the_item_created = new SomeType();
          factory = fake.an<ICreateASingleItem>();

          factory.setup(x => x.create()).Return(the_item_created);
          type_factories.setup(x => x.get_the_factory_that_can_create(typeof(SomeType)))
            .Return(factory);
        };

        Because b = () =>
          result = sut.an(typeof(SomeType));

        It should_return_the_item_created_using_the_factory_for_the_type_requested = () =>
          result.ShouldEqual(the_item_created); 

        static object result;
        static SomeType the_item_created;
        static ICreateASingleItem factory;
        static IFindFactoriesForTypes type_factories;
      }

      public class in_a_generic_context
      {
        Establish c = () =>
        {
          type_factories = depends.on<IFindFactoriesForTypes>();
          the_item_created = new SomeType();
          factory = fake.an<ICreateASingleItem>();

          factory.setup(x => x.create()).Return(the_item_created);
          type_factories.setup(x => x.get_the_factory_that_can_create(typeof(SomeType)))
            .Return(factory);
        };

        Because b = () =>
          result = sut.an<SomeType>();

        It should_return_the_item_created_using_the_factory_for_the_type_requested = () =>
          result.ShouldEqual(the_item_created);

        static SomeType result;
        static SomeType the_item_created;
        static ICreateASingleItem factory;
        static IFindFactoriesForTypes type_factories;
      }

      public class and_the_factory_for_the_type_throws_an_exception_when_creating_the_item
      {
        Establish c = () =>
        {
          inner_exception = new Exception();
          custom_exception = new Exception();
          factory = fake.an<ICreateASingleItem>();

          type_factories = depends.on<IFindFactoriesForTypes>();

          depends.on<ItemCreationExceptionFactory>((type, inner) =>
          {
            type.ShouldEqual(typeof(SomeType));
            inner.ShouldEqual(inner_exception);
            return custom_exception;
          });


          factory.setup(x => x.create()).Throw(inner_exception);
          type_factories.setup(x => x.get_the_factory_that_can_create(typeof(SomeType)))
            .Return(factory);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<SomeType>());

        It should_throw_the_exception_created_by_the_item_created_exception_factory = () =>
          spec.exception_thrown.ShouldEqual(custom_exception);

        static ICreateASingleItem factory;
        static IFindFactoriesForTypes type_factories;
        static Exception custom_exception;
        static Exception inner_exception;
      }
    }
  }

  public class SomeType
  {
  }
}

