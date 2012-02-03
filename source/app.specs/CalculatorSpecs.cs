using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<ICalculate, Calculator>
    {
    }

    public class when_created : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      It should_not_open_the_connection = () =>
        connection.never_received(x => x.Open());

      static IDbConnection connection;
    }

    public class when_shutting_off_the_calculator : concern
    {
      public class and_they_are_in_the_correct_security_group:when_shutting_off_the_calculator
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);
          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };


        Because b = () =>
          sut.shut_down();

        It should_not_throw_a_security_exception = () =>
        {

        };

        static IPrincipal principal;
      }
      public class and_the_are_not_in_the_correct_security_group:when_shutting_off_the_calculator
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.NotNull)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_down());

        It should_throw_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();


        static IPrincipal principal;
      }
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        Establish c = () =>
        {
          connection = depends.on<IDbConnection>();
          command = fake.an<IDbCommand>();

          connection.setup(x => x.CreateCommand()).Return(command);
        };

        Because b = () =>
          result = sut.add(2, 3);

        It should_return_the_sum = () =>
          result.ShouldEqual(5);

        It should_open_a_connection_to_the_database = () =>
          connection.received(x => x.Open());

        It should_run_a_command = () =>
          command.received(x => x.ExecuteNonQuery());

        It should_dispose_its_resources = () =>
        {
          connection.received(x => x.Dispose());
          command.received(x => x.Dispose());
        };

        static int result;
        static IDbConnection connection;
        static IDbCommand command;
      }

      public class a_negative_number_to_a_positive
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It should_throw_an_argument_exception = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();
      }
    }
  }
}