<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WordChangeSolverMvc.Models.Puzzle>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

<script src="<%= Url.Content ("~/Scripts/MicrosoftAjax.js") %>" type="text/javascript"></script>
<script src="<%= Url.Content ("~/Scripts/MicrosoftMvcAjax.js") %>" type="text/javascript"></script> 
<script src="<%= Url.Content ("~/Scripts/jQuery-1.4.1.js") %>" type="text/javascript"></script>
<script src="<%= Url.Content ("~/Scripts/WordChange.js") %>" type="text/javascript"></script>

<script type="text/javascript">

</script>

    <h2>Word Change Puzzle Solver</h2>
    Word Change Puzzles are elementary in concept: the solver morphs a word
    into a related word in steps by changing a single letter each time to
    form a new word.<p />
    See examples at <a href="http://crpuzzles.com/mw/" target="_blank">CR Puzzles</a><p />

    <div id="solver">
        <table border="0" cellpadding="0" cellspacing="2">
            <tr>
                <td>Start word:</td><td><%= Html.TextBox("StartWord") %></td>
            </tr>
            <tr>
                <td></td><td><div id="solveResult"></div></td>
            </tr>
            <tr>
                <td>End word:</td><td><%= Html.TextBox("EndWord")%></td>
            </tr>
        </table>
        <p />
        <input id="solve" type="submit" value="Solve" onclick="Solve('<%= Url.Content ("~/WordChange/Solve") %>')"/>
    </div>
</asp:Content>
