<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnamaeMail.Login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>kim hojun</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"
        rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">

            LOGIN<br />
            <br />
            ID　　   
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            @triton-sys.co.jp<br />
            <br />
            PWD　
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbWarning" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="ログイン" Width="274px" OnClick="btnLogin_Click" />
            <br />

        </div>
    </div>
    </form>
</body>
</html>