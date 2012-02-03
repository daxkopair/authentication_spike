using System;
using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ValueReturningBlockBuilder<>))]
  public class ValueReturningBlockBuilderSpecs
  {
    public abstract class concern : Observes<IEnhanceValueReturningCodeBlocks<bool>,
                                      ValueReturningBlockBuilder<bool>>
    {
    }

    public class when_running_a_builder_that_has_exception_handling_specified : concern
    {
      public class and_the_original_method_does_not_throw_an_exception
      {
        Establish c = () =>
        {
          depends.on<Func<bool>>(() => true);
          sut_setup.run(x => x.throw_error_on<Exception>(inner => new Exception()));
        };

        Because b = () =>
          result = sut.run();

        It should_return_the_value_from_the_original_block = () =>
          result.ShouldBeTrue();
      }
      public class and_the_original_method_throws_an_exception
      {
        Establish c = () =>
        {
          original_exception = new Exception();
          custom_exception = new Exception();
          depends.on<Func<bool>>(() =>
          {
            throw original_exception;
          });
        };

        Because b = () =>
        {
          sut = sut.throw_error_on<Exception>(inner =>
          {
            inner.ShouldEqual(original_exception);
            throw custom_exception;
          });

          spec.catch_exception(() => sut.run());
        };

        It should_throw_the_exception_created_by_the_provided_exception_factory = () =>
          spec.exception_thrown.ShouldEqual(custom_exception);

        static Exception original_exception;
        static Exception custom_exception;
      }

      static bool result;
    }

    public class when_exception_handling_has_been_specified_for_a_block : concern
    {
      Establish c = () =>
      {
        new_exception = new Exception();
        depends.on<Func<bool>>(() => true);
      };

      Because b = () =>
        result = sut.throw_error_on<Exception>((inner) => new_exception);

      It should_return_the_builder_to_continue_specifying_more_block_behaviour = () =>
        result.ShouldBeAn<ValueReturningBlockBuilder<bool>>().ShouldNotEqual(sut);

      static IEnhanceValueReturningCodeBlocks<bool> result;
      static Exception new_exception;
    }

    public class when_the_builder_is_run : concern
    {
      public class and_no_other_behaviour_has_been_specified
      {
        Establish c = () =>
        {
          depends.on<Func<bool>>(() => true);
        };

        Because b = () =>
          result = sut.run();

        It should_return_the_result_of_invoking_the_original_block = () =>
          result.ShouldBeTrue();

        static bool result;
      }
    }
  }
}