<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DemoMvcApplication.Models.StatePedCycleCrash>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details for Crash <%: Model.IMAGE_NO %></h2>

    <div>MAP: <%: Model.MAP %></div>
      
    <div>IMAGE_NO: <%: Model.IMAGE_NO %></div>
        
    <div>CRASH_RPT_NO: <%: Model.CRASH_RPT_NO %></div>
        
    <div>DATE/TIME: <%: String.Format("{0:D}", Model.DATE)%> <%: Model.TIME.Value.ToString(@"hh\:mm")%></div>
        
    <div>VEHICLES_COUNT: <%: Model.VEHICLES_COUNT %></div>
        
    <div>VEHICLE_NO: <%: Model.VEHICLE_NO %></div>
        
    <div>PERSON_INVOLVEMENT: <%: Model.PERSON_INVOLVEMENT %></div>
        
    <div>AGENCY: <%: Model.AGENCY %></div>
        
    <div>TROOP: <%: Model.TROOP %></div>
        
    <div>COUNTY: <%: Model.COUNTY %></div>
        
    <div>CITY: <%: Model.CITY %></div>
        
    <div>CRASH_TYPE: <%: Model.CRASH_TYPE %></div>
        
    <div>SEVERITY: <%: Model.SEVERITY %></div>
        
    <div>STREET: <%: Model.AT_STREET %> <%: Model.ON_STREET %></div>
        
    <div>LIGHT_CONDITIONS: <%: Model.LIGHT_CONDITIONS %></div>
        
    <div>INJURED/KILLED: <%: Model.INJURED %>/<%: Model.KILLED %></div>
        
    <div>VEHICLE_TYPE: <%: Model.VEHICLE_TYPE %></div>
        
    <div>CIRCUMSTANCES: <%: Model.CIRCUMSTANCES %></div>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

