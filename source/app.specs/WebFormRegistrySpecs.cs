using System.Web;
using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(WebFormRegistry))]
  public class WebFormRegistrySpecs
  {
    public abstract class concern : Observes<IFindViewsToDisplayReportModels,
                                      WebFormRegistry>
    {
    }

    public class when_finding_the_view_to_display_a_report_model : concern
    {
      Establish c = () =>
      {
        the_view = fake.an<IDisplayA<AnotherModel>>();
        the_model = new AnotherModel();
        the_path = "blah.aspx";

        aspx_path_registry = depends.on<IFindPathsToViews>();
        depends.on<PageFactory>((path,type) =>
        {
          type.ShouldEqual(typeof(IDisplayA<AnotherModel>));
          path.ShouldEqual(the_path);
          return the_view;
        });

        aspx_path_registry.setup(x => x.get_path_to_view_that_can_display<AnotherModel>())
          .Return(the_path);
      };

      Because b = () =>
        result = sut.get_view_that_can_display(the_model);

      It should_return_the_view_created_by_the_page_factory = () =>
        result.ShouldEqual(the_view);

      It should_have_populated_the_view_with_its_model = () =>
        the_view.report.ShouldEqual(the_model);
        

      static IHttpHandler result;
      static IDisplayA<AnotherModel> the_view;
      static AnotherModel the_model;
      static IFindPathsToViews aspx_path_registry;
      static string the_path;
    }

    public class AnotherModel
    {
    }
  }
}