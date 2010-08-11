<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="RolePlayingSystem.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Include/Common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table border="0" align="center">
            <tr>
            <td class="tdName">
                Login: 
            </td>
            <td class="tdData">
                <asp:TextBox ID="txtLogin" runat="server" />
                <asp:RequiredFieldValidator ID="valLogin" runat="server"
                    ControlToValidate="txtLogin"
                    Text="*" />
            </td>
            </tr>

            <tr>
            <td class="tdName">
                Password: 
            </td>
            <td class="tdData">
                <asp:TextBox ID="txtPassword" runat="server" />
                <asp:RequiredFieldValidator ID="valPassword" runat="server"
                    ControlToValidate="txtPassword"
                    Text="*" />
            </td>
            </tr>
            <tr>
            <td colspan="2" class="tdName">
                <asp:CustomValidator ID="valGeneral" runat="server"
                    Display="Dynamic"
                    ControlToValidate="txtLogin"
                    Text="Login/Password does match records." />
                
                <br />

                <asp:Button ID="btnSubmit" runat="server" Text="Login" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
