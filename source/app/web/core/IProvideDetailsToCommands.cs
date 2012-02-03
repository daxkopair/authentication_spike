namespace app.web.core
{
  public interface IProvideDetailsToCommands
  {
    InputModel map<InputModel>();
    string command_name { get; }
  }
}