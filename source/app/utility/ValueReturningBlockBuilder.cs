using System;

namespace app.utility
{
  public class ValueReturningBlockBuilder<ReturnType> : IEnhanceValueReturningCodeBlocks<ReturnType>
  {
    public Func<ReturnType> block;

    public ValueReturningBlockBuilder(Func<ReturnType> block)
    {
      this.block = block;
    }


    public ReturnType run()
    {
      return block();
    }

    public IEnhanceValueReturningCodeBlocks<ReturnType> throw_error_on<ExceptionType>(
      Func<Exception, Exception> custom_exception_factory) where ExceptionType : Exception
    {
      return new ValueReturningBlockBuilder<ReturnType>(decorate_block_with_exception_handling<ExceptionType>(custom_exception_factory));
    }

    Func<ReturnType> decorate_block_with_exception_handling<ExceptionType>(Func<Exception, Exception> custom_exception_factory)
      where ExceptionType : Exception
    {
      Func<ReturnType> new_block = () =>
      {
        try
        {
          return block();
        }
        catch (Exception e)
        {
          if (typeof(ExceptionType).IsAssignableFrom(e.GetType())) throw custom_exception_factory(e);
          throw;
        }
      };
      return new_block;
    }
  }
}