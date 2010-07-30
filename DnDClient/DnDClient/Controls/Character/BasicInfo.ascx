<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BasicInfo.ascx.vb" Inherits="RolePlayingSystem.Web.Controls.BasicInfo" %>

<% If False Then %>
<script src="../../Include/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
<% End If %>

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