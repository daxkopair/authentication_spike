using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_processing_all_items_in_an_iterator : concern
    {
      public class with_a_delegate_based_visitor
      {
        Establish c = () =>
        {
          all_items = Enumerable.Range(1,100).ToList();
        };
        Because b = () =>
          EnumerableExtensions.each(all_items, number =>
          {
            number_of_items_visited ++;
          });

        It should_run_the_visitor_against_each_item = () =>
          number_of_items_visited.ShouldEqual(100);

        static int number_of_items_visited;
        static IEnumerable<int> all_items;
      }
        
    }
  }
}
