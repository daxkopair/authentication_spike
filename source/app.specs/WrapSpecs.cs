using System;
using Machine.Specifications;
using app.utility;
using app.utility.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Wrap))]
  public class WrapSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_access_to_block_enhancement : concern
    {
      Establish c = () =>
      {
        builder_factory = fake.an<ICreateBlockBuilders>();
        block_builder = fake.an<IEnhanceValueReturningCodeBlocks<bool>>();
        the_block_to_wrap = () => true;

        spec.change(() => Wrap.builder_factory).to(builder_factory);

        builder_factory.setup(x => x.create_builder_for(the_block_to_wrap))
          .Return(block_builder);
      };

      Because b = () =>
        result = Wrap.the_block(the_block_to_wrap);

      It should_return_a_block_builder_created_using_the_initial_block = () =>
        result.ShouldEqual(block_builder);

      static IEnhanceValueReturningCodeBlocks<bool> result;
      static IEnhanceValueReturningCodeBlocks<bool> block_builder;
      static IFetchDependencies the_container_facade;
      static ICreateBlockBuilders builder_factory;
      static Func<bool> the_block_to_wrap = () => true;
    }
  }
}