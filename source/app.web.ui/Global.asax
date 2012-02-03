<%@ Application Language="C#" %>
<%@ Import Namespace="app.tasks.startup" %>
<script runat="server">

  void Application_Start(object sender, EventArgs e)
  {
    Startup.run();
  }

    </script>
