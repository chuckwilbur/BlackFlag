<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DemoMvcApplication.Models.StatePedCycleCrash>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">MAP</div>
        <div class="display-field"><%: Model.MAP %></div>
        
        <div class="display-label">IMAGE_NO</div>
        <div class="display-field"><%: Model.IMAGE_NO %></div>
        
        <div class="display-label">CRASH_RPT_NO</div>
        <div class="display-field"><%: Model.CRASH_RPT_NO %></div>
        
        <div class="display-label">DAY_OF_WEEK</div>
        <div class="display-field"><%: Model.DAY_OF_WEEK %></div>
        
        <div class="display-label">DATE</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.DATE) %></div>
        
        <div class="display-label">TIME</div>
        <div class="display-field"><%: Model.TIME %></div>
        
        <div class="display-label">VEHICLES_COUNT</div>
        <div class="display-field"><%: Model.VEHICLES_COUNT %></div>
        
        <div class="display-label">VEHICLE_NO</div>
        <div class="display-field"><%: Model.VEHICLE_NO %></div>
        
        <div class="display-label">PERSON_INVOLVEMENT</div>
        <div class="display-field"><%: Model.PERSON_INVOLVEMENT %></div>
        
        <div class="display-label">AGENCY</div>
        <div class="display-field"><%: Model.AGENCY %></div>
        
        <div class="display-label">TROOP</div>
        <div class="display-field"><%: Model.TROOP %></div>
        
        <div class="display-label">COUNTY</div>
        <div class="display-field"><%: Model.COUNTY %></div>
        
        <div class="display-label">CITY</div>
        <div class="display-field"><%: Model.CITY %></div>
        
        <div class="display-label">CRASH_TYPE</div>
        <div class="display-field"><%: Model.CRASH_TYPE %></div>
        
        <div class="display-label">SEVERITY</div>
        <div class="display-field"><%: Model.SEVERITY %></div>
        
        <div class="display-label">AT_STREET</div>
        <div class="display-field"><%: Model.AT_STREET %></div>
        
        <div class="display-label">ON_STREET</div>
        <div class="display-field"><%: Model.ON_STREET %></div>
        
        <div class="display-label">LIGHT_CONDITIONS</div>
        <div class="display-field"><%: Model.LIGHT_CONDITIONS %></div>
        
        <div class="display-label">INJURED</div>
        <div class="display-field"><%: Model.INJURED %></div>
        
        <div class="display-label">KILLED</div>
        <div class="display-field"><%: Model.KILLED %></div>
        
        <div class="display-label">VEHICLE_TYPE</div>
        <div class="display-field"><%: Model.VEHICLE_TYPE %></div>
        
        <div class="display-label">CIRCUMSTANCES</div>
        <div class="display-field"><%: Model.CIRCUMSTANCES %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

