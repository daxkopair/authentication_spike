 using System.Data;
 using System.Reflection;
 using Machine.Specifications;
 using app.specs.utility;
 using app.utility.containers.basic;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(GreedyConstructorSelection))]  
  public class GreedyConstructorSelectionSpecs
  {
    public abstract class concern : Observes<IPickTheCtorOnAType,
                                      GreedyConstructorSelection>
    {
        
    }

   
    public class when_picking_the_ctor : concern
    {
      Establish c = () =>
      {
        the_one_with_the_most_params = ObjectFactory.expressions.to_target<SomeItem>()
          .get_the_ctor_pointed_at_by(() => new SomeItem(null, null));
      };

      Because b = () =>
        result = sut.get_applicable_constructor_on(typeof(SomeItem));

      It should_pick_the_one_with_the_most_params = () =>
        result.ShouldEqual(the_one_with_the_most_params);

      static ConstructorInfo result;
      static ConstructorInfo the_one_with_the_most_params;
    }

    public class SomeItem
  {
      public SomeItem(IDbCommand command)
      {
        
      }
      public SomeItem(IDbConnection connection, IDbCommand command)
      {
        
      }
  }
  }

}
