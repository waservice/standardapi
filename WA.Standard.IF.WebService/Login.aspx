<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WA.Standard.IF.WebService.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Workshop Automation Standard API - LOGIN</title>
<link href="./css/login.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="./js/jquery/jquery-1.5.1.js"></script>
<script type="text/javascript" src="./js/jquery/jquery-ui-1.8.10.custom.min.js"></script>
<script type="text/javascript">
// login center
jQuery.fn.center = function () {
	//this.css("position","absolute");
	this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) + $(window).scrollTop()) + "px");
	this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) + $(window).scrollLeft()) + "px");
	return this;
}
$(function() {
	$( "#draggable" ).draggable({ containment: "#containmentBox", scroll: false }).center();
});
</script>

</head>



<body>

<div class="body" id="containmentBox">

	<div class="loginBox" id="draggable">
		<div class="loginTop">
			<div class="loginTopImg"><img src="./img/title.png" /></div>
		</div>

		<div class="loginArea">
			<p>Workshop Automation Standard API is the public API for DMS to interact with the WA.</p>
			<div class="bottomLine">
			<form name="form_login" id="form_login" method="post" action="">
				<table>
					<colgroup>
						<col width="100px">
						<col width="230px">
						<col width="">
					</colgroup>
					<tr>
						<td>E-MAIL</td>
						<td><input type="text" name="USER_ID" id="USER_ID" tabindex="1" /></td>
						<td rowspan="2"><input type="image" tabindex="3" src="./img/btnLogin.png" /></td>
					</tr>
					<tr>
						<td>PASSWORD</td>
						<td><input type="password" name="PASSWD" id="PASSWD" tabindex="2" /></td>
					</tr>
				</table>
			</form>
			</div>
		</div>
		<div class="copyright">
			<img src="./img/git.png" />
		</div>
	</div>

</div>
</body>
</html>
