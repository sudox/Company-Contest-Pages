<%@ Page Language="C#" AutoEventWireup="true" Debug="false" CodeFile="contest6.aspx.cs" Inherits="_Default" %>

<html>

<head>
    <script src="./js/jscolor.min.js"></script>
</head>

<body>
    <form runat="server">
        <img id="statueImg" style="display: none;" src="statue.png" />
        <div id="content" style="color: white; font-family: 'Lato', sans-serif;" runat="server">

            <div style="float: left;">
                <canvas width="470" height="500" id="statue"></canvas>
            </div>
            <div style="float: left;">
                <br />
                <h2>Enter your email and click the box to pick a color to color the statue</h2>
                <br />
                <script>
                    function statueColor() {
                        var c = document.getElementById("statue");
                        var ctx = c.getContext("2d");
                        var img = document.getElementById("statueImg");
                        ctx.beginPath();
                        ctx.rect(0, 0, 400, 500);
                        ctx.fillStyle = "#" + document.getElementById("color").value;
                        ctx.fill();
                        ctx.drawImage(img, 0, 0);
                    }
                    window.onload = statueColor;
                </script>
                <table>
                    <tr>
                        <td>
                            <label style="color: white; font-family: 'Lato', sans-serif;">Email: </label>
                        </td>
                        <td>
                            <asp:TextBox ID="email" runat="server" /><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></td>
                    </tr>
                    <td>
                        <label style="color: white; font-family: 'Lato', sans-serif;">Click this box to pick a color --> </label>
                    </td>
                    <td>
                        <asp:TextBox class="jscolor" ID="color" value="FFFFFF" runat="server" /><asp:RequiredFieldValidator runat="server" ID="answerVal" ControlToValidate="color" ErrorMessage="*" ForeColor="Red" /></td>
                    </tr>
      <tr>
          <td></td>
          <td>
              <asp:Button Style="float: right;" ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" /></td>
      </tr>
                    <script>
                        document.getElementById("color").addEventListener("change", function () {
                            statueColor();
                        });
                    </script>
            </div>
            <div style="position:absolute; left:75%; bottom:30%;">
                <h1>Win me!</h1>
                <img src="puzzle.png" width="300" height="300" />
            </div>
        </div>
    </form>
</body>

</html>
