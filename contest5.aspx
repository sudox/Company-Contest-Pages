<%@ Page Language="C#" AutoEventWireup="true" Debug="false" CodeFile="contest5.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Dorn Color Contest</title>
	<link href="/contest/contest4.css" rel="stylesheet"/>
	<style type="text/css" media="screen">
	  #picture { background:url(./img/where.jpg); background-size: 900px 600px;};
	</style>
</head>

<body>
	<form runat="server">
		<div id="content" style="float:right; color: white; font-family: 'Lato', sans-serif; width: 1300px;" runat="server">

			<div style="position: relative;">
				<h1 style="color: black; position:absolute; top:0; left:30px; z-index:3;">Win me!</h1>
				<img style="position:relative;" height="400" width="400px" src="/Contest/img/ptpp.jpg" />
		    <canvas id="picture" width="900" height="600" style="position:absolute; left:410px; top:0; z-index:0;"></canvas>
		    <canvas id="draw" width="900" height="600px" style="position:absolute; left:410px; top:0; z-index:1;"></canvas>

		  </div>
			<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
			<div style="float:right">
			<asp:TextBox style="visibility:hidden;" ID="answer" runat="server" />
			<br /><asp:RequiredFieldValidator runat="server" ID="answerVal" ControlToValidate="answer" ErrorMessage="Please click the image above" ForeColor="Red" />
			<br />

			<label>Email:</label>
			<asp:TextBox ID="email" runat="server" /><asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="email" ErrorMessage="*" ForeColor="Red" /></>
			<asp:Button ID="submit" Text="Submit" OnClick="Submit_Click" runat="server" />
		</div>
		</div>
	</form>
	<script>
	  var canvas = document.getElementById('draw');
	  canvas.addEventListener('mousedown', function(e) {
	    var x = e.clientX - canvas.getBoundingClientRect().left;
	    var y = e.clientY - canvas.getBoundingClientRect().top
	    var ctx = canvas.getContext("2d");
	    ctx.clearRect(0, 0, canvas.width, canvas.height);
	    ctx.beginPath();
	    ctx.arc(x, y, 15, 0, 2*Math.PI);
	    ctx.strokeStyle = '#ff0000';
	    ctx.stroke();
			document.getElementById("answer").value = x + ", " + y;
	  });
	</script>
</body>
</html>
