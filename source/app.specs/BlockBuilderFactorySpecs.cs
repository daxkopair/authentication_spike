 using System;
 using Machine.Specifications;
 using app.utility;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(BlockBuilderFactory))]  
  public class BlockBuilderFactorySpecs
  {
    public abstract class concern : Observes<ICreateBlockBuilders,
                                      BlockBuilderFactory>
    {
        
    }

   
    public class when_creating_a_block_builder : concern
    {
      Establish c = () =>
      {
        the_block = depends.on<Func<bool>>(() => true);
      };

      Because b = () =>
        result = sut.create_builder_for(the_block);


      It should_create_a_builder_with_the_correct_information = () =>
      {
        var builder = result.ShouldBeAn<ValueReturningBlockBuilder<bool>>();
        builder.block.ShouldEqual(the_block);
      };

      static IEnhanceValueReturningCodeBlocks<bool> result;
      static Func<bool> the_block;

    }
  }
}
