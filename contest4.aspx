<%@ Page Language="C#" AutoEventWireup="true" Debug="false" CodeFile="contest4.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Dorn Color Contest</title>
	<link href="/contest/contest4.css" rel="stylesheet"/>
    <script src="/Contest/js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="/Contest/js/jquery-ui-1.8.9.custom.min.js" type="text/javascript"></script>
    <script src="/Contest/js/jquery.ImageColorPicker.js"></script>
	<script type="text/javascript">
			$(document).ready(function(){

			$("#ww").ImageColorPicker({
				afterColorSelected: function(event, color){ $("#answer").val(color); }
			});		
			});
		</script>
</head>

<body>
	<form runat="server">
		<div id="content" style="float:right; color: white; font-family: 'Lato', sans-serif;" runat="server">
				<asp:Image ID="ww" height="400" width="632" alt="" runat="server"/>
            <h3>Click on the most soothing color on the image below then enter your email!</h3>
			<label>Most Soothing Color? </label>
			<asp:TextBox ID="answer" runat="server" /><asp:RequiredFieldValidator runat="server" ID="answerVal" ControlToValidate="answer" ErrorMessage="*" ForeColor="Red" />
			<label>Email:</label>
			<asp:TextBox ID="email" runat="server" /><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></>
			<asp:Button ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" />
		</div>
	</form>
</body>
</html>
