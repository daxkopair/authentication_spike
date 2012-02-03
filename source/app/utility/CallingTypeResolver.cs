using System;
using System.Diagnostics;

namespace app.utility
{
  public class CallingTypeResolver:IResolveTheCallingType
  {
    public Type resolve()
    {
      return new StackFrame(1).GetMethod().DeclaringType;
    }
  }
}