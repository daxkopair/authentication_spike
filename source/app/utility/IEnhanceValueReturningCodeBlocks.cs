using System;

namespace app.utility
{
  public interface IEnhanceValueReturningCodeBlocks<ReturnType>
  {
    ReturnType run();

    IEnhanceValueReturningCodeBlocks<ReturnType> throw_error_on<ExceptionType>(
      Func<Exception, Exception> custom_exception_factory) where ExceptionType : Exception;
  }
}