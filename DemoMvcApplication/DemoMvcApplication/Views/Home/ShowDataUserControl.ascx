<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<ul style="margin-top:0px; padding-left:30px">
<% foreach (KeyValuePair<string, object> data in ViewData) %>
<% { %>
    <li><%: data.Key %>: <%: data.Value %></li>
<% } %>
</ul>
