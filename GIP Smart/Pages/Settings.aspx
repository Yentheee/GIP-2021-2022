<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="GIP_Smart.Pages.Settings" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Settings</title>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
<link href="/Content/site.css" rel="stylesheet"/>

    <script src="/Scripts/modernizr-2.8.3.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Home.aspx">Sm@rt Power</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                   <li><a href="Home.aspx">Home</a></li>
                    <li><a href="Lights.aspx">Lights</a></li>
                    <li><a href="Stopcontact.aspx">Wall Outlet</a></li>
                    <li><a href="Camera.aspx">Camera</a></li>
                    <li><a href="Settings.aspx">Settings</a></li>
                    <li><a href="Login.aspx">Log Out</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        <div class="jumbotron">
    <h1>Ligths</h1>
    <p class="lead">Op deze pagina kunt u de instellingen doen voor verbinding te maken met de microcontroller</p>
</div>

        <div class="row">
    <div class="col-md-3">
        kies een topic:<asp:DropDownList ID="ddl_topic" runat="server">
            <asp:ListItem>arduino/simple</asp:ListItem>
            <asp:ListItem>topic1</asp:ListItem>
            <asp:ListItem>topic_test</asp:ListItem>
        </asp:DropDownList>
        <br />
       kies een broker::<asp:DropDownList ID="ddl_broker" runat="server">
            <asp:ListItem>test.mosquitto.org</asp:ListItem>
            <asp:ListItem>broker1</asp:ListItem>
            <asp:ListItem>broker_test</asp:ListItem>
        </asp:DropDownList>
    </div>
        <hr />
            
        <footer>
            <p>Sm@rt Power  -   Yenthe Van den Eynden, Nicolas Hutsebaut</p>
        </footer>
    </div> 

    <script src="/Scripts/jquery-3.3.1.js"></script>

    <script src="/Scripts/bootstrap.js"></script>

    
    </form>

    
</body>
</html>