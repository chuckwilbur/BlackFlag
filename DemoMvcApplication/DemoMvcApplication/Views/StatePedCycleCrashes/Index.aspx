<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DemoMvcApplication.Helpers.PaginatedList<DemoMvcApplication.Models.StatePedCycleCrash>>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <%: Html.ActionLink("Statistics", "Stats")%>

    <table>
        <tr>
            <th></th>
            <th>
                CRASH_RPT_NO
            </th>
            <th>
                DATE/TIME
            </th>
            <th>
                COUNTY
            </th>
            <th>
                CITY
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Details", "Details", new { id=item.IMAGE_NO })%>
            </td>
            <td>
                <%: item.CRASH_RPT_NO %>
            </td>
            <td>
                <%: String.Format("{0:D}", item.DATE) %> <%: item.TIME.Value.ToString(@"hh\:mm")%>
            </td>
            <td>
                <%: item.COUNTY %>
            </td>
            <td>
                <%: item.CITY %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% if (Model.HasPreviousPage) { %>
 
        <%= Html.RouteLink("<<<", "StatePedCycleCrashesList", new { page = (Model.PageIndex - 1) })%>
 
    <% } %>
 
    <% if (Model.HasNextPage) {  %>
 
        <%= Html.RouteLink(">>>", "StatePedCycleCrashesList", new { page = (Model.PageIndex + 1) })%>
 
    <% } %>  

</asp:Content>

