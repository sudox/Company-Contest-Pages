<%@ Page Language="C#" AutoEventWireup="true" Debug="false" CodeFile="contest7.aspx.cs" Inherits="_Default" %>

<html>

<head>
    <title>Dorn Color Contest</title>
    <script src="./js/crs.min.js"></script>
</head>

<body>
    <form runat="server">
        <div id="content" style="color: white; font-family: 'Lato', sans-serif;" runat="server">
            <h2>If Las Vegas is Neon Yellow what color is your hometown? Here in Cleveland we think our hometown is orange.</h2>
            <h2>Select your Country, State/Region, then type your hometown city and what color you think it is for a chance to win this gift basket loaded with some of Ohio's finest goodies!</h2>

            <script>
                function countryStore()
                {
                    country = document.getElementById("country");
                    document.getElementById("hiddenCountry").value = country.options[country.selectedIndex].value;
                }
                function stateStore()
                {
                    state = document.getElementById("state");
                    document.getElementById("hiddenState").value = state.options[state.selectedIndex].value;
                }
            </script>
            <div style="float:left; padding-right:10px;">
                <img width="300px" height="200px" src="cle.jpg" />
            </div>
            <div style="float:left; padding-right:10px">
                <h1 style="color:orangered; position:absolute; padding-top:150px; padding-left:170px">Win me!</h1>
                <img width="300px" height="200px" src="basket.jpg?1" />
            </div>
            <div style="float: left;">
                <table style="color: white; font-family: 'Lato', sans-serif;">
                    <tr><td><label for="country">Country: </label></td><td><select id="country" data-region-id="state" class="crs-country"></select></td></tr>
                    <tr><td><p></p></td></tr>
                    <tr><td><label for="state">State/Region: </label></td><td><select id="state" onChange="stateStore(this); countryStore(this)"></select></td></tr>
                    <tr><td><p></p></td></tr>
                    <tr><td><label for="town">Hometown: </label></td><td><asp:TextBox id="town" runat="server"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="hometownVal" ControlToValidate="town" ErrorMessage="*" ForeColor="Red" /></td><td><label for="color">Hometown Color: </label></td><td><asp:TextBox ID="color" runat="server"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="colorVal" ControlToValidate="color" ErrorMessage="*" ForeColor="Red" /></td></tr>
                    <tr><td><p></p></td></tr>
                    <tr><td><label for="email">Email: </label></td><td><asp:TextBox ID="email" runat="server"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></td></tr>
                    <tr><td><p></p></td></tr>
                    <tr><td></td><td><asp:Button ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" /></td></tr>
                </table>
                <br />
            </div>
            <asp:HiddenField runat="server" ID="hiddenCountry" />
            <asp:HiddenField runat="server" ID="hiddenState" />
        </div>
    </form>
</body>

</html>
