using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Security;
using app.utility.containers;
using developwithpassion.specifications.core;
using developwithpassion.specifications.extensions;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public class expressions
    {
      public static ExpressionBuilder<ItemToTarget> to_target<ItemToTarget>()
      {
        return new ExpressionBuilder<ItemToTarget>();
      }

      public class ExpressionBuilder<ItemToTarget>
      {
        public ConstructorInfo get_the_ctor_pointed_at_by(Expression<Func<ItemToTarget>> constructor)
        {
          return constructor.Body.downcast_to<NewExpression>().Constructor;
        }
      }
    }

    public class container
    {
      public class FakeRuntimeDependencyResolution : IDisposable
      {
        IConfigureSpecifications spec;
        ICreateFakes fake;
        IFetchDependencies the_container_facade;

        public FakeRuntimeDependencyResolution(ICreateFakes fake, IConfigureSpecifications spec)
        {
          this.spec = spec;
          this.fake = fake;
          the_container_facade = this.fake.an<IFetchDependencies>();
        }

        public void Dispose()
        {
          ContainerFacadeResolution resolution = () => the_container_facade;
          spec.change(() => Container.facade_resolution).to(resolution);
        }

        public Dependency an<Dependency>() where Dependency : class
        {
          var item = fake.an<Dependency>();
          the_container_facade.setup(x => x.an<Dependency>()).Return(item);
          return item;
        }
      }

      public static FakeRuntimeDependencyResolution scaffold(ICreateFakes fake, IConfigureSpecifications spec)
      {
        return new FakeRuntimeDependencyResolution(fake, spec);
      }
    }

    public class web
    {
      public static FormsAuthenticationTicket create_fake_authentication_ticket()
      {
        return new FormsAuthenticationTicket(1, "some_name", DateTime.Now, DateTime.Now,
                                             true, "1001");
      }
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }
  }
}
