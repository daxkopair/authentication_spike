using app.utility.containers;

namespace app.web.core
{
  public class ViewAReport<Query, ReportModel> : IImplementAFeature
    where Query : IFetchA<ReportModel>
  {
    Query query;
    IDisplayInformation display_engine;

    public ViewAReport(Query query, IDisplayInformation display_engine)
    {
      this.query = query;
      this.display_engine = display_engine;
    }

    public ViewAReport():this(Container.fetch.an<Query>(),Container.fetch.an<IDisplayInformation>() )
    {
    }

    public void process(IProvideDetailsToCommands request)
    {
      display_engine.display(query.fetch_using(request));
    }
  }
}