using System;

namespace app.utility
{
  public interface ICreateBlockBuilders
  {
    IEnhanceValueReturningCodeBlocks<ReturnType> create_builder_for<ReturnType>(Func<ReturnType> block);
  }
}