﻿using System.Web.Security;

namespace app.web.core
{
    public delegate void AssociateTicketWithCurrentUser(FormsAuthenticationTicket ticket);
}