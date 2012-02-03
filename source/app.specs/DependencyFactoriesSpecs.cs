 using System;
 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.utility.containers.basic;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyFactories))]  
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IFindFactoriesForTypes,
                                      DependencyFactories>
    {
        
    }

   
    public class when_getting_the_factory_to_create_a_type : concern
    {
      public class and_it_has_the_factory
      {

        Establish c = () =>
        {
          all_factories = Enumerable.Range(1, 100).Select(x => fake.an<ICreateASingleItem>()).ToList();
          the_factory_that_can_create_the_item = fake.an<ICreateASingleItem>();
          all_factories.Add(the_factory_that_can_create_the_item);

          the_factory_that_can_create_the_item.setup(x => x.can_create(typeof(int))).Return(true);

          depends.on<IEnumerable<ICreateASingleItem>>(all_factories);
        };

        Because b = () =>
          result = sut.get_the_factory_that_can_create(typeof(int));


        It should_return_the_factory_to_the_caller = () =>
          result.ShouldEqual(the_factory_that_can_create_the_item);


        static ICreateASingleItem result;
        static ICreateASingleItem the_factory_that_can_create_the_item;
        static List<ICreateASingleItem> all_factories;
      }
        
      public class and_it_does_not_have_the_factory
      {

        Establish c = () =>
        {
          all_factories = Enumerable.Range(1, 100).Select(x => fake.an<ICreateASingleItem>()).ToList();
          the_exception = new Exception();
          depends.on<MissingFactoryExceptionProvider>(x =>
          {
            x.ShouldEqual(typeof(int));
            return the_exception;
          });

          depends.on<IEnumerable<ICreateASingleItem>>(all_factories);

        };

        Because b = () =>
          spec.catch_exception(() => sut.get_the_factory_that_can_create(typeof(int)));

        It should_throw_the_exception_created_by_the_missing_factory_exception_provider = () =>
          spec.exception_thrown.ShouldEqual(the_exception);


        static ICreateASingleItem result;
        static List<ICreateASingleItem> all_factories;
        static Exception the_exception;
      }
    }
  }
}
