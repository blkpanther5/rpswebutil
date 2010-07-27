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
    
        #detail 
        {
            font-family: Century Gothic;
            font-size: 12px;
        }
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        User Name: <asp:TextBox ID="txtLogin" runat="server" /> <br />
        Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" />

        <br /><br />
        <asp:Button runat="server" ID="btnGet" Text="Get it!" /><br />
        <iframe id="iframeOutput" runat="server" frameborder="0" src="about:blank" style="height:480px; width:590px; display:none;" />
    </div>
    </form>
</body>
</html>
