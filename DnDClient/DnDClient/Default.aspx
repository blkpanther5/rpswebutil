<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="RolePlayingSystem.Web._Default" %>
<%@ Register TagName="BasicInfo" TagPrefix="MCUC" Src="~/Controls/Character/BasicInfo.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DnDClient</title>
    
    <link href="Include/jQueryUI/css/smoothness/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="Include/Common.css" rel="stylesheet" type="text/css" />
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
        Login: <asp:TextBox ID="txtLogin" runat="server" /> &nbsp;
        Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /> &nbsp;
        <asp:Button ID="btnLogin" runat="server" Text="Login to Compendium" /> &nbsp;
        <!--<asp:Button runat="server" ID="btnGet" Text="Load Character" />-->

        <hr />
       
        <dnd:BasicInfo id="test" runat="server" />
        <dnd:BasicInfo id="BasicInfo1" runat="server" />

<script type="text/javascript">
//<![CDATA[

    $(function () {
        $("#tabs").tabs();
    });

//]]>
</script>

<div id="tabs" style="float:left;">
	<ul>
		<li><a href="#tabs-1">Nunc tincidunt</a></li>
		<li><a href="#tabs-2">Proin dolor</a></li>
		<li><a href="#tabs-3">Aenean lacinia</a></li>
	</ul>
	<div id="tabs-1">
		<p>Proin elit arcu, rutrum commodo, vehicula tempus, commodo a, risus. Curabitur nec arcu. Donec sollicitudin mi sit amet mauris. Nam elementum quam ullamcorper ante. Etiam aliquet massa et lorem. Mauris dapibus lacus auctor risus. Aenean tempor ullamcorper leo. Vivamus sed magna quis ligula eleifend adipiscing. Duis orci. Aliquam sodales tortor vitae ipsum. Aliquam nulla. Duis aliquam molestie erat. Ut et mauris vel pede varius sollicitudin. Sed ut dolor nec orci tincidunt interdum. Phasellus ipsum. Nunc tristique tempus lectus.</p>
	</div>
	<div id="tabs-2">
		<p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
	</div>
	<div id="tabs-3">
		<p>Mauris eleifend est et turpis. Duis id erat. Suspendisse potenti. Aliquam vulputate, pede vel vehicula accumsan, mi neque rutrum erat, eu congue orci lorem eget lorem. Vestibulum non ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce sodales. Quisque eu urna vel enim commodo pellentesque. Praesent eu risus hendrerit ligula tempus pretium. Curabitur lorem enim, pretium nec, feugiat nec, luctus a, lacus.</p>
		<p>Duis cursus. Maecenas ligula eros, blandit nec, pharetra at, semper at, magna. Nullam ac lacus. Nulla facilisi. Praesent viverra justo vitae neque. Praesent blandit adipiscing velit. Suspendisse potenti. Donec mattis, pede vel pharetra blandit, magna ligula faucibus eros, id euismod lacus dolor eget odio. Nam scelerisque. Donec non libero sed nulla mattis commodo. Ut sagittis. Donec nisi lectus, feugiat porttitor, tempor ac, tempor vitae, pede. Aenean vehicula velit eu tellus interdum rutrum. Maecenas commodo. Pellentesque nec elit. Fusce in lacus. Vivamus a libero vitae lectus hendrerit hendrerit.</p>
	</div>
</div>

        <!--<div id="detail">
		    <h1 class="atwillpower"><span class="level">Sorcerer Attack 1</span>Burning Spray</h1><p class="flavor"><i>You fling your arm in a wide arc, casting liquid fire at your foes.</i></p><p class="powerstat"><b>At-Will</b>&nbsp;&nbsp;&nbsp;&nbsp;&middot;&nbsp;&nbsp;&nbsp;&nbsp;<b>Arcane</b>, <b>Fire</b>, <b>Implement</b><br/><b>Standard Action</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Close</b> blast 3</p><p class="powerstat"><b>Target</b>: Each creature in blast</p><p class="powerstat"><b>Attack</b>: Charisma vs. Reflex</p><p class="flavor"><b>Hit</b>: 1d8 + Charisma modifier fire damage.<br/>Level 21: 2d8 + Charisma modifier fire damage.</p><p class="powerstat">&nbsp;&nbsp;<b>Dragon Magic</b>: The next enemy that hits you with a melee attack before the end of your next turn takes fire damage equal to your Strength modifier.</p><p>Published in <a target="_new" href="http://www.wizards.com/default.asp?x=products/dndacc/9780786950164">Player's Handbook 2</a>, page(s) 138.</p>
        </div>-->
    </div>
    </form>
</body>
</html>
