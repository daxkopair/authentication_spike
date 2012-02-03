namespace app.utility
{
  public class Stub
  {
    public static TheStub with<TheStub>() where TheStub : new()
    {
      return new TheStub();
    }
  }
}