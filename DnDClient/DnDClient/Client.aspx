<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Client.aspx.vb" Inherits="RolePlayingSystem.Web._Client" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DnDClient</title>

    <meta name="viewport" content="width=device-width" />
    
    <link href="Include/jQueryUI/css/smoothness/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="Include/Compendium.css" rel="stylesheet" type="text/css" />
    <link href="Include/Common.css" rel="stylesheet" type="text/css" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js " type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Include/jQuery/jQuery.frameReady.js" type="text/javascript"></script>

    <% If False Then %>
    <script src="Include/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <% End If %>

    <script type="text/javascript">
    //<![CDATA[

        //One time run.
        $(function () {
            //Assign events for numpad.
            $("#HPDialog > .styledbutton").each(function () {
                $(this).click(null);
                $(this).click(function () {
                    doNumpad($(this).val(), $('#txtHPMod'));
                });
            });
        });

        //Initialization stuff.
        function pageLoad(sender, args) {
            $(function () {
                $("#InfoTabs").tabs();
                $("#testlink").button();
                $(".PowerButton").button();
                $(".styledbutton").button();
            });
        }

        function loadHPDialog(iVal) {
            $(function () {
                //Reset HP text box.
                $("#txtHPMod").val("");

                //Set dialog title based on passed value.
                if (iVal < 0) {
                    var sTitle = "Subtract Hit Points";
                    $("#txtHPMod").val("-");
                } else {
                    var sTitle = "Add Hit Points";
                }

                $("#HPDialog").dialog({
                    height: 275,
                    modal: true,
                    resizable: false,
                    title: sTitle
                });
            });
        }

        //Increments the surge counter.
        function saveSurges(iVal) {
            $(function () {
                if (parseInt($("#<%=lblSurges.ClientId%>").text()) + iVal == "NaN") {
                    return false;
                }

                $("#<%=lblSurges.ClientId%>").text(parseInt($("#<%=lblSurges.ClientId%>").text()) + iVal);
            });
        }

        //Takes tallied HP modifier and applies it to main character sheet.
        function saveHitPoints() {
            $(function () {
                //Save current HP.
                var iCurrentHP = parseInt($("#<%=lblHP.ClientId%>").text());

                //Attempt to update.
                $("#<%=lblHP.ClientId%>").text(iCurrentHP + parseInt($("#txtHPMod").val()));

                //If the HP box is NaN then reset to last value.
                if ($("#<%=lblHP.ClientId%>").text() == "NaN") {
                    $("#<%=lblHP.ClientId%>").text(iCurrentHP);
                }

                //Close the dialog.
                $("#HPDialog").dialog('close');
            });
        }

        //Manages the numpad like function for HP add/subtract.
        function doNumpad(sVal, oTarget) {
            $(function () {
                $(oTarget).val($(oTarget).val() + sVal.toString());
            });
        }


    //]]>
    </script>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="true">
    <asp:ScriptManager ID="smDefault" runat="server" />
    <div id="container">
        <asp:UpdatePanel ID="upDefault" runat="server">
            <ContentTemplate>
                <!-- Basic Information Summary -->
                <div id="divBasicInfo" runat="server" class="BasicInformation">
                    <table border="0" cellspacing="0" cellpadding="2">
                    <tr>
                    <td colspan="3" class="tdNameTop">
                        Character Name
                    </td>
                    </tr>
                    <tr>
                    <td colspan="3" class="tdData">
                        <asp:Label ID="lblCharacterName" runat="server"
                            Text="Character_Name" />
                    </td>
                    </tr>

                    <tr>
                    <td colspan="3" class="tdNameTop">
                        Player Name
                    </td>
                    </tr>
                    <tr>
                    <td colspan="3" class="tdData">
                        <asp:Label ID="lblPlayerName" runat="server"
                            Text="Player_Name" />
                    </td>
                    </tr>

                    <tr>
                    <td class="tdNameTop">
                        Race
                    </td>
                    <td class="tdNameTop">
                        Class
                    </td>
                    <td class="tdNameTop">
                        Level
                    </td>
                    </tr>
                    <tr>
                    <td class="tdData smaller">
                        <asp:Label ID="lblRace" runat="server"
                            Text="Race_Here" />
                    </td>
                    <td class="tdData smaller">
                        <asp:Label ID="lblClass" runat="server"
                            Text="Class_Here" />
                    </td>
                    <td class="tdData smaller">
                        <asp:Label ID="lblLevel" runat="server"
                            Text="1" />
                    </td>
                    </tr>

                    <tr>
                    <td id="StatContainer" colspan="3">
                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblStrScore" runat="server" 
                                    Text="00" />
                            </div>

                            <div class="AbilityMod">
                                <asp:Label ID="lblStrMod" runat="server" 
                                    Text="+00" />
                            </div>

                            Strength (STR)
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblConScore" runat="server" 
                                    Text="00" />
                            </div>

                            <div class="AbilityMod">
                                <asp:Label ID="lblConMod" runat="server" 
                                    Text="+00" />
                            </div>

                            Constitution (CON)
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblDexScore" runat="server" 
                                    Text="00" />
                            </div>

                            <div class="AbilityMod">
                                <asp:Label ID="lblDexMod" runat="server" 
                                    Text="+00" />
                            </div>

                            Dexterity (DEX)
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblIntScore" runat="server" 
                                    Text="00" />
                            </div>

                            <div class="AbilityMod">
                                <asp:Label ID="lblIntMod" runat="server" 
                                    Text="+00" />
                            </div>

                            Intelligence (INT)
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblWisScore" runat="server" 
                                    Text="00" />
                            </div>

                            <div class="AbilityMod">
                                <asp:Label ID="lblWisMod" runat="server" 
                                    Text="+00" />
                            </div>

                            Wisdom (WIS)
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblChaScore" runat="server" 
                                    Text="00" />
                            </div>

                            <div class="AbilityMod">
                                <asp:Label ID="lblChaMod" runat="server" 
                                    Text="+00" />
                            </div>

                            Charisma (CHA)
                        </div>
                    </td>
                    </tr>
                    </table>
                </div>

                <!-- Other Information Summary -->
                <div id="divOtherInfo" class="OtherInformation">
                    <table border="0" cellspacing="0" cellpadding="2">
                    <tr>
                    <td class="tdNameTop">
                        Health
                    </td>
                    </tr>

                    <tr>
                    <td id="HealthContainer">
                        <div id="HPLine">
                            <span style="position:relative; text-align:center;">Hit Points</span><br />

                            <table border="0" >
                            <tr>
                            <td>
                                <a href="javascript:void(0);"
                                    onclick="loadHPDialog(-1);"
                                    class="styledbutton" 
                                    style="font-size:small;"> - </a>
                            </td>
                            <td>
                            <div id="HPIndicator">
                                <asp:Label ID="lblHP" runat="server"
                                    Text="000" />
                            </div>
                            </td>
                            <td>
                                <a href="javascript:void(0);"
                                    onclick="loadHPDialog(1);"
                                    class="styledbutton" 
                                    style="font-size:small;"> + </a>
                            </td>
                            </tr>
                            </table>
                        </div>
                    </td>
                    </tr>

                    <tr>
                    <td id="SurgeContainer">
                        <div id="SurgeLine">
                            <span style="position:relative; text-align:center;">Healing Surges</span><br />

                            <table border="0" >
                            <tr>
                            <td>
                                <a href="javascript:void(0);"
                                    onclick="saveSurges(-1);"
                                    class="styledbutton" 
                                    style="font-size:small;"> - </a>
                            </td>
                            <td>
                            <div id="SurgeIndicator">
                                <asp:Label ID="lblSurges" runat="server"
                                    Text="0" />
                            </div>
                            </td>
                            <td>
                                <a href="javascript:void(0);"
                                    onclick="saveSurges(1);"
                                    class="styledbutton" 
                                    style="font-size:small;"> + </a>
                            </td>
                            </tr>
                            </table>
                        </div>
                    </td>
                    </tr>

                    <tr>
                    <td class="tdNameTop">
                        Defenses
                    </td>
                    </tr>

                    <tr>
                    <td id="DefenseContainer">
                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblACScore" runat="server" 
                                    Text="00" />
                            </div>

                            Armor Class
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblFortScore" runat="server" 
                                    Text="00" />
                            </div>

                            Fortitude Defense
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblRefScore" runat="server" 
                                    Text="00" />
                            </div>

                            Reflex Defense
                        </div>

                        <div class="AbilityLine">
                            <div class="AbilityScore">
                                <asp:Label ID="lblWillScore" runat="server" 
                                    Text="00" />
                            </div>

                            Will Defense
                        </div>
                    </td>
                    </tr>
                    </table>
                </div>

                <div id="InfoTabs">
	                <ul>
		                <li><a href="#tabs-1">Powers</a></li>
		                <li><a href="#tabs-2">Features</a></li>
		                <li><a href="#tabs-3">Skills</a></li>
                        <li><a href="#tabs-4">Combat</a></li>
                        <li><a href="#tabs-5">Browser</a></li>
	                </ul>
	                <div id="tabs-1">
                        <div id="PowerList">
                            <asp:Repeater ID="PowerRepeater" runat="server">
                                <ItemTemplate>
                                    <input type="button" class="PowerButton" style="color:<%# getColorByPowerType(DataBinder.Eval(Container.DataItem, "Type")) %>;" value="[<%# DataBinder.Eval(Container.DataItem, "Level")%>] <%# DataBinder.Eval(Container.DataItem, "Name").Trim%>" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div id="PowerSummary" runat="server">
                        </div>
	                </div>
	                <div id="tabs-2">
		                <p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
	                </div>
	                <div id="tabs-3">
		                <p>Mauris eleifend est et turpis. Duis id erat. Suspendisse potenti. Aliquam vulputate, pede vel vehicula accumsan, mi neque rutrum erat, eu congue orci lorem eget lorem. Vestibulum non ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce sodales. Quisque eu urna vel enim commodo pellentesque. Praesent eu risus hendrerit ligula tempus pretium. Curabitur lorem enim, pretium nec, feugiat nec, luctus a, lacus.</p>
		                <p>Duis cursus. Maecenas ligula eros, blandit nec, pharetra at, semper at, magna. Nullam ac lacus. Nulla facilisi. Praesent viverra justo vitae neque. Praesent blandit adipiscing velit. Suspendisse potenti. Donec mattis, pede vel pharetra blandit, magna ligula faucibus eros, id euismod lacus dolor eget odio. Nam scelerisque. Donec non libero sed nulla mattis commodo. Ut sagittis. Donec nisi lectus, feugiat porttitor, tempor ac, tempor vitae, pede. Aenean vehicula velit eu tellus interdum rutrum. Maecenas commodo. Pellentesque nec elit. Fusce in lacus. Vivamus a libero vitae lectus hendrerit hendrerit.</p>
	                </div>
	                <div id="tabs-4">
                        <p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
	                </div>
	                <div id="tabs-5">
		                <p>Proin elit arcu, rutrum commodo, vehicula tempus, commodo a, risus. Curabitur nec arcu. Donec sollicitudin mi sit amet mauris. Nam elementum quam ullamcorper ante. Etiam aliquet massa et lorem. Mauris dapibus lacus auctor risus. Aenean tempor ullamcorper leo. Vivamus sed magna quis ligula eleifend adipiscing. Duis orci. Aliquam sodales tortor vitae ipsum. Aliquam nulla. Duis aliquam molestie erat. Ut et mauris vel pede varius sollicitudin. Sed ut dolor nec orci tincidunt interdum. Phasellus ipsum. Nunc tristique tempus lectus.</p>
	                </div>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Refresh" /> &nbsp;
                <asp:Button runat="server" ID="btnGet" Text="Import" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Dialog content -->
    <div id="HPDialog" style="display:none; text-align:center;">
        <div style="padding-bottom:12px;"><a href="javascript:void(0)" onclick="saveHitPoints();">Ok</a> &nbsp; <input type="text" id="txtHPMod" style="width:75px; font-size:20px; text-align:center;" value="" /> &nbsp; <a href="javascript:void(0);" onclick="$('#txtHPMod').val('');">CE</a></div>
        <input type="button" value="1" onclick="" class="styledbutton" /><input type="button" value="2" onclick="" class="styledbutton" /><input type="button" value="3" onclick="" class="styledbutton" /><br />
        <input type="button" value="4" onclick="" class="styledbutton" /><input type="button" value="5" onclick="" class="styledbutton" /><input type="button" value="6" onclick="" class="styledbutton" /><br />
        <input type="button" value="7" onclick="" class="styledbutton" /><input type="button" value="8" onclick="" class="styledbutton" /><input type="button" value="9" onclick="" class="styledbutton" /><br />
        <input type="button" value="0" onclick="" class="styledbutton" />
    </div>
    </form>
</body>
</html>
