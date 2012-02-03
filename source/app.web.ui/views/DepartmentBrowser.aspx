<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.utility" %>
<%@ Import Namespace="app.web.application.catalogbrowsing.inputmodels" %>
<%@ Import Namespace="app.web.application.login" %>
<%@ Import Namespace="app.web.core" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <tr><td><a href="<%= UrlBuilder.url_to_run<LoginRequest>() %>">Login</a></td></tr>
            <tr><td><a href="<%= UrlBuilder.url_to_run<LogoutRequest>() %>">Logout</a></td></tr>
            <%
              var number = 0;
              this.report.each(department =>
              {%>
              <tr class="ListItem">
               <td><a href="<%=number %2 == 0
                  ? UrlBuilder.url_to_run<ViewTheDepartmentsInDepartmentRequest>()
                  : "{0}".format_using(UrlBuilder.url_to_run<ViewTheProductsInADepartmentRequest>())%>"><%=department.name%></a></td>
           	  </tr>        
              <%
                number++;
              });%>
              

      	    </table>            
</asp:Content>
