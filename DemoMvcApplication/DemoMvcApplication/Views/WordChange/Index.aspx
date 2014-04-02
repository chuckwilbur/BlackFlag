<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WordChangeSolverMvc.Models.Puzzle>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script> 
<script src="/Scripts/jQuery-1.4.1.js" type="text/javascript"></script>
<script src="/Scripts/WordChange.js" type="text/javascript"></script>

<script type="text/javascript">

</script>

    <h2>Word Change Puzzle Solver</h2>
    <div id="solver">
        <%= Html.TextBox("StartWord") %>
        <div id="solveResult"></div>
        <%= Html.TextBox("EndWord") %>
        <p />
        <input id="solve" type="submit" value="Solve" onclick="Solve()"/>
    </div>
</asp:Content>
