<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DemoMvcApplication.Helpers.PaginatedList<DemoMvcApplication.Models.StatePedCycleCrash>>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                CRASH_RPT_NO
            </th>
            <th>
                DAY_OF_WEEK
            </th>
            <th>
                DATE
            </th>
            <th>
                TIME
            </th>
            <th>
                VEHICLES_COUNT
            </th>
            <th>
                VEHICLE_NO
            </th>
            <th>
                PERSON_INVOLVEMENT
            </th>
            <th>
                AGENCY
            </th>
            <th>
                TROOP
            </th>
            <th>
                COUNTY
            </th>
            <th>
                CITY
            </th>
            <th>
                CRASH_TYPE
            </th>
            <th>
                SEVERITY
            </th>
            <th>
                AT_STREET
            </th>
            <th>
                ON_STREET
            </th>
            <th>
                LIGHT_CONDITIONS
            </th>
            <th>
                INJURED
            </th>
            <th>
                KILLED
            </th>
            <th>
                VEHICLE_TYPE
            </th>
            <th>
                CIRCUMSTANCES
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
                <%: item.DAY_OF_WEEK %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DATE) %>
            </td>
            <td>
                <%: item.TIME %>
            </td>
            <td>
                <%: item.VEHICLES_COUNT %>
            </td>
            <td>
                <%: item.VEHICLE_NO %>
            </td>
            <td>
                <%: item.PERSON_INVOLVEMENT %>
            </td>
            <td>
                <%: item.AGENCY %>
            </td>
            <td>
                <%: item.TROOP %>
            </td>
            <td>
                <%: item.COUNTY %>
            </td>
            <td>
                <%: item.CITY %>
            </td>
            <td>
                <%: item.CRASH_TYPE %>
            </td>
            <td>
                <%: item.SEVERITY %>
            </td>
            <td>
                <%: item.AT_STREET %>
            </td>
            <td>
                <%: item.ON_STREET %>
            </td>
            <td>
                <%: item.LIGHT_CONDITIONS %>
            </td>
            <td>
                <%: item.INJURED %>
            </td>
            <td>
                <%: item.KILLED %>
            </td>
            <td>
                <%: item.VEHICLE_TYPE %>
            </td>
            <td>
                <%: item.CIRCUMSTANCES %>
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

