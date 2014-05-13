<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DemoMvcApplication.Models.CrashRepository>" %>
<%@ Import Namespace="DemoMvcApplication.Controllers" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Statistics
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

<script src="<%= Url.Content ("~/Scripts/MicrosoftAjax.js") %>" type="text/javascript"></script>
<script src="<%= Url.Content ("~/Scripts/MicrosoftMvcAjax.js") %>" type="text/javascript"></script> 
<script src="<%= Url.Content ("~/Scripts/jQuery-1.4.1.js") %>" type="text/javascript"></script>

<script src="<%= Url.Content ("~/Scripts/Graphics/lodash.js") %>" type="text/javascript"></script>
<script src="<%= Url.Content ("~/Scripts/Graphics/d3/d3.js") %>" type="text/javascript"></script>
<script src="<%= Url.Content ("~/Scripts/Graphics/contour/contour.js") %>" type="text/javascript"></script>

<script src="<%= Url.Content ("~/Scripts/Stats.js") %>" type="text/javascript"></script>

    <h2>Statistics</h2>

    County List<br />
    <% IList<string> counties = Model.GetCountyList(); %>
    <% counties.Insert(0, "Select county..."); %>
    <%: Html.DropDownList("CountyList", new SelectList(counties), new { @onchange = "GetCityList('" + Url.Content("~/StatePedCycleCrashes/CityList") + "')" }) %>
    <table id="resultTable">
        <tr>
            <td>
                <%: Html.DropDownList("CityList", new List<SelectListItem>(), new { @onchange = "AddCityStats('" + Url.Content("~/StatePedCycleCrashes/StatsByCity") + "')" })%>
            </td>
            <% foreach (int year in Model.GetFullYearList()) { %>
                <td><%: year %></td>
            <% } %>
        </tr>
    </table>
    <p />
    <div class="row charts section">
        <div class="col-sm-6">
            <div class="crashChart"></div>
        </div>
    </div>

</asp:Content>
