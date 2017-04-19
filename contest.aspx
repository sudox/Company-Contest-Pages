<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="contest.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title>Dorn Color Contest</title>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.4.2.js"></script>
  <style type="text/css">
    .input_hidden {
    position: absolute;
    left: -9999px;
}

.selected label{
    background-color: #FFF;
    display: inline-block;
    cursor: pointer;
}

.thumb label {
    display: inline-block;
    cursor: pointer;
}

.selected label:hover {
    background-color: #efefef;
}


.thumb label:hover {
    background-color: #efefef;
}

.selected {
    position: relative;
    width: 150px;
    height: 150px;
    margin: 10px;
    float: left
}

.thumb {
    position: relative;
    width: 150px;
    height: 150px;
    margin: 10px;
    float: left
}

.text {
    display: none;
    position: absolute;
    left: 0;
    bottom: 0;
    width: 100%;
    background: #999;
    background: rgba(0,0,0,0.3);
    text-align: center
}

.selected .text {
    display: block;
}

.selected:hover .text {
    display: block;
}

.thumb:hover .text {
    display: block
}

</style>

<script type="text/javascript">
    function clientVal(source,args)
{   
    if(document.getElementById("<%= blue.ClientID %>").checked || document.getElementById("<%= red.ClientID %>").checked || document.getElementById("<%= gray.ClientID %>").checked || document.getElementById("<%= green.ClientID %>").checked || document.getElementById("<%= brown.ClientID %>").checked || document.getElementById("<%= terracotta.ClientID %>").checked || document.getElementById("<%= silver.ClientID %>").checked || document.getElementById("<%= white.ClientID %>").checked || document.getElementById("<%= purple.ClientID %>").checked || document.getElementById("<%= yellow.ClientID %>").checked)
    {
        args.IsValid = true;
    }
    else
    {
        args.IsValid = false;
    }
    
}
</script>

<script type='text/javascript'>
$(window).load(function(){
$('.thumb input:radio').addClass('input_hidden');
$('.thumb label').click(function() {
    var list = this.parentElement.parentElement.children;
    for (var i = 0; i < list.length; i++) {
        if(list[i].className == "selected")
        {
            list[i].className = 'thumb';
        }
    }
    this.parentElement.className = 'selected';
});
});
</script>
</head>

<body>
    <form runat="server">
        <div id="content" style="color:white; font-family:'Lato', sans-serif;" runat="server">
            <div class="thumb"><asp:RadioButton ID="purple" GroupName="colors" runat="server" /><label for="purple"><img src="./img/purple.png" alt="Purple Colors" /><span class="text">Purple</span></label></div>
            <div class="thumb"><asp:RadioButton ID="blue" GroupName="colors" runat="server" /><label for="blue"><img src="./img/blue.png" alt="Blue Colors" /><span class="text">Blue</span></label></div>
            <div class="thumb"><asp:RadioButton ID="red" GroupName="colors" runat="server" /><label for="red"><img src="./img/red.png" alt="Red Colors" /><span class="text">Red</span></label></div>
            <div class="thumb"><asp:RadioButton ID="terracotta" GroupName="colors" runat="server" /><label for="terracotta"><img src="./img/terracotta.png" alt="Terracotta Colors" /><span class="text">Terracotta</span></label></div>
            <div class="thumb"><asp:RadioButton ID="green" GroupName="colors" runat="server" /><label for="green"><img src="./img/green.png" alt="Green Colors" /><span class="text">Green</span></label></div>
            <div class="thumb"><asp:RadioButton ID="yellow" GroupName="colors" runat="server" /><label for="yellow"><img src="./img/yellow.png" alt="Yellow Colors" /><span class="text">Yellow</span></label></div>
            <div class="thumb"><asp:RadioButton ID="brown" GroupName="colors" runat="server" /><label for="brown"><img src="./img/brown.png" alt="Brown Colors" /><span class="text">Brown</span></label></div>
            <div class="thumb"><asp:RadioButton ID="gray" GroupName="colors" runat="server" /><label for="gray"><img src="./img/gray.png" alt="Gray Colors" /><span class="text">Gray</span></label></div>
            <div class="thumb"><asp:RadioButton ID="silver" GroupName="colors" runat="server" /><label for="silver"><img src="./img/silver.png" alt="Silver Colors" /><span class="text">Silver</span></label></div>
            <div class="thumb"><asp:RadioButton ID="white" GroupName="colors" runat="server" /><label for="white"><img src="./img/white.png" alt="White Colors" /><span class="text">White</span></label></div>

            <asp:CustomValidator id="validate" runat="server" Display="Dynamic" ErrorMessage="Choose a color" ClientValidationFunction="clientVal" OnServerValidate="serverVal"></asp:CustomValidator>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <p style="padding-left:10px;">Email: <asp:TextBox id="email" runat="server" /> <asp:Button ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" /><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></p>
        </div>
    </form>
</body>
</html>
