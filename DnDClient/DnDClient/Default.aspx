<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="DnDClient._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DnDClient</title>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js " type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Include/jQuery/jQuery.frameReady.js" type="text/javascript"></script>

    <% If False Then %>
    <script src="Include/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <% End If %>

    <style>
    
#detail {
	background: #fff;
    color: #3e141e;
    
	/*width: 560px;
    float: left;
	padding: 15px;*/
    
    font-family: Century Gothic;
}
#detail {
    font-size: 12px;
}
#detail p {
	padding-left: 15px;
	color: #3e141e;
}
#detail table {
	width: 100%;
}
#detail table td {
	vertical-align: top;
	padding: 0 10px 0;
	background: #d6d6c2;
	border-bottom: 1px solid #fff;
}
#detail p.flavor,
#detail span.flavor,
#detail ul.flavor {
	display: block;
	padding: 2px 15px;
	margin: 0;
	background: #d6d6c2;
}
#detail p.powerstat {
	padding: 0px 0px 0px 15px;
	margin: 0;
	background: #FFFFFF;
}
#detail span.ritualstats {
	float:right;
	padding: 0 30px 0 0;
}
#detail p.flavorIndent {
	display: block;
	padding: 2px 15px 2px 30px;
	margin: 0;
	background: #d6d6c2;
}
#detail p.alt,
#detail span.alt,
#detail td.alt {
	background: #c3c6ad;
}
#detail th {
    background: #1d3d5e;
    color: #fff;
    text-align: left;
    padding: 0 0 0 5px;
}
#detail i,
#detail em {
	font-style: italic;
}
#detail ul {
    list-style: disc;
    margin: 1em 0 1em 30px;
}
#detail table,
#detail ul.flavor {
	margin-bottom: 1em;
}
#detail ul li {
    color: #3e141e;
}
#detail ul.flavor li {
	list-style-image: url("../images/bullet.gif");
	margin-left: 15px;
}
#detail a {
    color: #3e141e;
}
#detail blockquote 
{
	padding: 0 0 0 22px;
	background: #d6d6c2;
}
#detail h1 {
    font-size: 1.09em;
    line-height: 2;
    padding-left: 15px;
    margin: 0;
    color: #fff;
    background: #000;
}

#detail h1.player {
    background: #1d3d5e;
    font-size: 1.35em;
}
#detail h1.monster {
    background: #4e5c2e;
    height:38px;
}
#detail h1.dm {
    background: #5c1f34;
}
#detail h1.trap {
    background: #5c1f34;
    height:38px;
}
#detail h1.atwillpower {
    background: #619869;
}
#detail h1.encounterpower {
    background: #961334;
}
#detail h1.dailypower {
    background: #4d4d4f;
}
#detail h1.magicitem {
    background: #d8941d;
}
#detail h1.utilitypower {
    background: #1c3d5f;
}
#detail h1 .level {
    padding-right: 15px;
	margin-top: 0;
	text-align: right;
	float: right;
}
#detail h1.monster .level, h1.trap .level {
	margin-top: 0;
	text-align: right;
	position:relative;
	top:-60px;
}
#detail h1.monster .type,
#detail h1.monster .xp {
	display: block;
	position: relative;
	z-index: 99;
	top: -0.75em;
	height: 1em;
	font-weight: normal;
	font-size: 0.917em;
}
#detail .rightalign {
	text-align: right;
}
/* Traps */
#detail h1.trap .level {
	margin-top: 0;
	text-align: right;
}
#detail h1.trap .type,
#detail h1.trap .xp {
	display: block;
	position: relative;
	z-index: 99;
	top: -0.75em;
	height: 1em;
	font-weight: normal;
	font-size: 0.917em;
}
#detail .traplead {
	display: block;
	padding: 1px 15px;
	margin: 0;
	background: #ffffff;
}
#detail .trapblocktitle {
	display: block;
	padding: 1px 15px;
	margin: 0;
	background: #d6d6c2;
	font-weight: bold;
}
#detail .trapblockbody {
	display: block;
	padding: 1px 15px 1px 30px;
	margin: 0;
	background: #ffffff;
}

/* Detail page related link section */
/* -------------------------------------------- */

#detail #RelatedArticles h5 {
	width: 100px;
	float: left;
	padding-top: 10px;
	padding-left: 20px;
	color: #3e141e;
	font-weight: bold;
}
#detail #RelatedArticles ul.RelatedArticles {
	padding: 10px 0 0 0;
	float: right;
	width: 430px;
	margin: 0;
	list-style: none;
}

#detail .bodytable {
	border: 0;
	margin: 0;
	width: 560px;
	background: #d6d6c2;
}
#detail .bodytable td {
	border-bottom: none;
	padding-left: 15px;
	padding-right: 15px;
}
#detail h2 {
    font-size: 1.25em;
    padding-left: 15px;
    margin: 0;
    color: #fff;
    background: #4e5c2e;
    height:20px;
    font-variant: small-caps;
    padding-top: 5px;
}

            
    
    </style>
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
