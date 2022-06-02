<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lights.aspx.cs" Inherits="GIP_Smart.Pages.Lights" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lights</title>
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
    <h1>Lights</h1>
    <p class="lead">Op deze pagina vindt u meer informatie over de lichten. En u kunt ze hier aan of uit doen</p>
</div>
<div class="row">
    <div class="col-md-3">
        <h2>Set the lights On or Off</h2>
        <asp:Button class="button button1" ID="btn_On" runat="server" Text="ON" OnClick="btn_On_Click" />
       <asp:Button class="button button2" ID="btn_Off" runat="server" Text="OFF" OnClick="btn_Off_Click" />
    </div>
  
     <div class="col-md-3">
            <h2>Verbruik</h2>
            <div id="circularProgressVerbruik" class="circularprogress backgroundVerbruik" runat="server">  
            <div id="ProgressTextVerbruik" class="overlay" runat="server">
            </div>  
        </div>
        <h2 class="text">verbruikt</h2>
    </div> 
    <div>
        <div class="col-md-3">
            <h2>Temperatuur</h2>
            <div id="circularProgess" class="circularprogress backgroundTemperature" runat="server">  
            <div id="ProgressTextTemperature" class="overlay" runat="server"></div>  
            </div>
        </div> 
        </div>
        <hr />
        </div>
        <footer>
            <p>Sm@rt Power  -   Yenthe Van den Eynden, Nicolas Hutsebaut</p>
        </footer>

    <script src="/Scripts/jquery-3.3.1.js"></script>

    <script src="/Scripts/bootstrap.js"></script>

    
    </form>

    
</body>
</html>
<style>  

    .backgroundTemperature {  
        background-image: linear-gradient(<%= Val1 %>, <%= ColorCode %> 50%, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0)), linear-gradient(<%= Val2 %>, #18bc9c 50%, #ffffff 50%, #ffffff);  
    }  
    .backgroundVerbruik {  
        background-image: linear-gradient(<%= Val1Verbruik %>, <%= ColorCodeVerbruik %> 50%, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0)), linear-gradient(<%= Val2Verbruik %>, #18bc9c 50%, #ffffff 50%, #ffffff);  
    }  
    /* ------------------------------------- 
     * Bar container 
     * ------------------------------------- */  
    .circularprogress {  
        float: left;  
        margin-left: 50px;  
        margin-top: 30px;  
        position: relative;  
        width: 180px;  
        height: 180px;  
        border-radius: 50%;  
        border: 1px solid #18bc9c;
    }  
  
        /* ------------------------------------- 
         * Optional centered circle w/text 
         * ------------------------------------- */  
        .circularprogress .overlay {  
            position: absolute;  
            width: 130px;  
            height: 130px;  
            color: black;  
            background-color: #CFFFDB;  
            border-radius: 50%;  
            margin-left: 25px;  
            margin-top: 23px;  
            text-align: center;  
            line-height: 90px;  
            font-size: 35px;  
            padding-top: 20px;  
        }  
</style>  