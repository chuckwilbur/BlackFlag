<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WordChangeSolverMvc.Models.WordNode>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Html.Encode(Model.ToString())%></h2>
<ul>
<% foreach (var dinner in Model.NeighborWords) { %>
 
<li><%=Html.Encode(dinner.ToString())%></li>
 
<% } %>
</ul>
</asp:Content>
