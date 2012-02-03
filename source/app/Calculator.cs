using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Threading;

namespace app
{
  public interface ICalculate
  {
    int add(int first, int second);
    void shut_down();
  }

  public class Calculator : ICalculate
  {
    IDbConnection connection;

    public Calculator(int number2, IDbConnection connection, int number1)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      ensure_all_are_positive(first, second);

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return first + second;
    }

    public void shut_down()
    {
      if (Thread.CurrentPrincipal.IsInRole("sdfsdf")) return;
      throw new SecurityException();
    }

    void ensure_all_are_positive(params int[] numbers)
    {
      if (numbers.All(x => x > 0)) return;

      throw new ArgumentException("I can't deal with negatives");
    }
  }
}