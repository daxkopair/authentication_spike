namespace app.web.core
{
  public class make_sure_the_user_id_in_the_url_matches_the_user_id_in_the_principal<RequestToForwardToIfIdsAreDifferent> :
    IInterceptWithoutForwardingTheCall
  {
    GetTheCurrentUrl_Behaviour current_url;
    IsAuthorizedUrl_Behaviour url_is_authorized;
    IRedirect redirect;

    public make_sure_the_user_id_in_the_url_matches_the_user_id_in_the_principal(GetTheCurrentUrl_Behaviour current_url,
                                                                                 IsAuthorizedUrl_Behaviour
                                                                                   url_is_authorized, IRedirect redirect)
    {
      this.current_url = current_url;
      this.url_is_authorized = url_is_authorized;
      this.redirect = redirect;
    }

    public void process(IProvideDetailsToCommands request)
    {
      if (url_is_authorized(current_url())) return;

      redirect.to<RequestToForwardToIfIdsAreDifferent>();
    }
  }
}