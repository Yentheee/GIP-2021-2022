<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GIP_Smart.Pages.Home" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
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
                    <li><a href="Wall_Outlet.aspx">Wall Outlet</a></li>
                    <li><a href="Camera.aspx">Camera</a></li>
                    <li><a href="Settings.aspx">Settings</a></li>
                    <li><a href="Login.aspx">LogOut</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        


<div class="jumbotron">
    <h1>Sm@rt Power</h1>
    <p class="lead">Sm@rt Power is ons GIP. Op deze site ga je kunnen zien hoeveel er is verbruikt. Je kan ook het licht aan en uit sturen op deze site
        ook gaat het licht automatisch aan als er beweging is.</p>
</div>
    </div>
    <!--<div class="col-md-3">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>-->
<div class="row">
    <div class="col-md-3" runat="server">
         <h2>wall-outlet</h2>
        <div class="progressWallOutlet">
            <div class="percent">
                <svg>
                    <circle cx="70" cy="70" r="70"></circle>
                    <circle cx="70" cy="70" r="70"></circle>
                </svg>
                <div class="number">
                    <h2><asp:Label ID="lblVerbruikt" runat="server"></asp:Label></h2>
                    <asp:Label ID="label12" runat="server" Text="0"></asp:Label>
                </div>
            </div>
            <h2 class="text">verbruikt</h2> 
            </div>
        </div>
    <div class="col-md-3">
        <h2>Ligths</h2>
        <div class="progressLights">
            <div class="percent">
                <svg>
                    <circle cx="70" cy="70" r="70"></circle>
                    <circle cx="70" cy="70" r="70"></circle>
                </svg>
                <div class="number">
                    <h2>87<span>%</span></h2>
                </div>
            </div>
            <h2 class="text">verbruikt</h2>
</div> 
        </div>
        <div class="col-md-3">
        <h2>Temperatuur</h2>
        <div id="circularProgess" class="circularprogress background" runat="server">  
          <div id="ProgressText" class="overlay" runat="server"></div>  
            </div>
</div> 
        <hr />
</div>
        <footer>
            <p> Sm@rt Power  -   Yenthe Van den Eynden, Nicolas Hutsebaut</p>
        </footer>
  
    <script src="/Scripts/jquery-3.3.1.js"></script>

    <script src="/Scripts/bootstrap.js"></script>

    
    </form>

    
       

                
</body>
</html>

<style>  

    .background {  
        background-image: linear-gradient(<%= Val1 %>, <%= ColorCode %> 50%, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0)), linear-gradient(<%= Val2 %>, #18bc9c 50%, #ffffff 50%, #ffffff);  
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