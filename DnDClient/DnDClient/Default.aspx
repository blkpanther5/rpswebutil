<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="RolePlayingSystem.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DnDClient</title>

    <link href="Include/Compendium.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js " type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Include/jQuery/jQuery.frameReady.js" type="text/javascript"></script>

    <% If False Then %>
    <script src="Include/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <% End If %>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        User Name: <asp:TextBox ID="txtLogin" runat="server" /> <br />
        Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" />
        <hr />

    <div id="detail">
		<h1 class="atwillpower"><span class="level">Sorcerer Attack 1</span>Burning Spray</h1><p class="flavor"><i>You fling your arm in a wide arc, casting liquid fire at your foes.</i></p><p class="powerstat"><b>At-Will</b>&nbsp;&nbsp;&nbsp;&nbsp;&middot;&nbsp;&nbsp;&nbsp;&nbsp;<b>Arcane</b>, <b>Fire</b>, <b>Implement</b><br/><b>Standard Action</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Close</b> blast 3</p><p class="powerstat"><b>Target</b>: Each creature in blast</p><p class="powerstat"><b>Attack</b>: Charisma vs. Reflex</p><p class="flavor"><b>Hit</b>: 1d8 + Charisma modifier fire damage.<br/>Level 21: 2d8 + Charisma modifier fire damage.</p><p class="powerstat">&nbsp;&nbsp;<b>Dragon Magic</b>: The next enemy that hits you with a melee attack before the end of your next turn takes fire damage equal to your Strength modifier.</p><p>Published in <a target="_new" href="http://www.wizards.com/default.asp?x=products/dndacc/9780786950164">Player's Handbook 2</a>, page(s) 138.</p>
    </div>

        <hr />

        <br /><br />
        <asp:Button runat="server" ID="btnGet" Text="Get it!" /><br />
        <iframe id="iframeOutput" runat="server" frameborder="0" src="about:blank" style="height:480px; width:590px; display:none;" />
    </div>
    </form>
</body>
</html>
