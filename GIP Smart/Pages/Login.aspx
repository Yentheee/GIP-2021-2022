<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GIP_Smart.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" href="LoginStyle.css"/>
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
</head>
<body>
  <form id="form1" class="login-form" runat="server">
 <h1>Login</h1>
 <div class="txtb">
 <asp:TextBox ID="tbUsername" runat="server" placeholder="Gebruikersnaam" AutoCompleteType="Disabled"></asp:TextBox>         
 </div>
 <div class="txtb">
 <asp:TextBox ID="tbPassword" runat="server" placeholder="Wachtwoord" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>       
 </div>
      
     <asp:Button class="logbtn" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
      <asp:Label ID="lbFoutGegevens" runat="server"></asp:Label>
                
 </form>
 <script>
     $(".txtb input").on("focus", function(){
        $(this).addClass("focus");
     });
     $(".txtb input").on("blur", function(){
         if($(this).val()=="")
         $(this).removeClass("focus");
     });
 </script>
</body>
</html>
