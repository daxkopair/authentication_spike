using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
 
namespace app.specs
{   
    public class make_sure_the_user_id_in_the_url_matches_the_user_id_on_the_principal
    {
        public abstract class concern : Observes<IInterceptWithoutForwardingTheCall, make_sure_the_user_id_in_the_url_matches_the_user_id_in_the_principal<SomeRequest>>
        {
        
        }

        public class when_run : concern
        {
            public class and_the_user_ids_are_the_same
            {

                Establish context = () =>
                    {
                        request = fake.an<IProvideDetailsToCommands>();
                        depends.on<IsAuthorizedUrl_Behaviour>(url => true);
                        redirect = depends.on<IRedirect>();
                    };

                Because b = () => sut.process(request);

                It should_not_redirect_to_the_redirect_request = () =>
                    {
                        redirect.never_received(x => x.to<SomeRequest>());
                    };

                static IRedirect redirect;
                static IProvideDetailsToCommands request;
            }
        }

        public class SomeRequest
        {
        }
    }

    
}
