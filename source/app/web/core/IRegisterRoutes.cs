using System.Collections.Generic;

namespace app.web.core
{
  public interface IRegisterRoutes : IEnumerable<IProcessOneRequest>
  {
    IConfigureARoute a_report<InputModel, Feature>() where Feature : IImplementAFeature;
    IConfigureARoute a_command<InputModel, FirstStep, NextRequest>() where FirstStep : IImplementAFeature;
    void prepare_routes();
  }
}