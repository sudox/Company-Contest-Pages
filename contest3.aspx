<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="contest3.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dorn Color Contest</title>
    <link href="/contest/contest3.css" rel="stylesheet"/>
</head>

<body>
    <form runat="server">
        <div id="content" style="float:right; color: white; font-family: 'Lato', sans-serif;" runat="server">
            <!--<asp:HyperLink class="fancybox" ID="outer" Height="300" width="600" Title="Where is it?" runat="server">-->
                <asp:Image ID="ww" height="400" width="600" alt="" runat="server"/>
            <!--</asp:HyperLink>-->
            <br />
            <label>Answer: </label>
            <asp:TextBox ID="answer" runat="server" /><asp:RequiredFieldValidator runat="server" ID="answerVal" ControlToValidate="answer" ErrorMessage="*" ForeColor="Red" />
            <label>Email:</label>
            <asp:TextBox ID="email" runat="server" /><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></>
            <asp:Button ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" />
        </div>
    </form>
    <script src="/Contest/js/jquery-1.11.3.min.js"></script>
    <script src="/Contest/js/jquery.fancybox.pack.js"></script>
</body>
</html>
