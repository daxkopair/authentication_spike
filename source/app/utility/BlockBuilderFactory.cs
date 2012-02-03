using System;

namespace app.utility
{
  public class BlockBuilderFactory:ICreateBlockBuilders
  {
    public IEnhanceValueReturningCodeBlocks<ReturnType> create_builder_for<ReturnType>(Func<ReturnType> block)
    {
      return new ValueReturningBlockBuilder<ReturnType>(block);
    }
  }
}