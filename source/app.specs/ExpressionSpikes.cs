using System;
using System.Linq.Expressions;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class ExpressionSpikes
  {
    public abstract class concern : Observes
    {

    }

    public class when_playing_around_with_expressions : concern
    {
      It should_be_able_to_build_a_delegate_dynamically = () =>
      {
        Func<int, bool> is_even = x => x%2 == 0;
        is_even(2).ShouldBeTrue();
        is_even(3).ShouldBeFalse();

        var the_number = Expression.Parameter(typeof(int),"x");
        var modulus = Expression.Modulo(the_number, Expression.Constant(2));
        var equals =  Expression.Equal(modulus,Expression.Constant(0));
        var dynamic_modulus = Expression.Lambda<Func<int, bool>>(equals, the_number);
        var executable = dynamic_modulus.Compile();


        executable(2).ShouldBeTrue();
        executable(3).ShouldBeFalse();
      };

    }
  }
}
