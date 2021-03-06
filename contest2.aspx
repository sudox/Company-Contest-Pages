<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="contest2.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dorn Color Contest</title>
</head>

<body>
    <form runat="server">
        <div id="content" style="color: white; font-family: 'Lato', sans-serif;" runat="server">
            <table border="0">
                <tr>
                    <td><p style="padding-left: 10px;">Answer: </td>
                    <td><asp:TextBox ID="answer" runat="server" /><asp:RequiredFieldValidator runat="server" ID="answerVal" ControlToValidate="answer" ErrorMessage="*" ForeColor="Red" /></td>
                </tr>
                <tr>
                    <td><p style="padding-left: 10px;">Email:</td>
                    <td><asp:TextBox ID="email" runat="server" /><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: right; padding-right:10px;"><asp:Button ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" /></td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
