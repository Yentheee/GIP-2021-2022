
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Wall Outlet</title>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
<link href="/Content/site.css" rel="stylesheet"/>

    <script src="/Scripts/modernizr-2.8.3.js"></script>

</head>
<body>
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
                    <li><a href="Login.aspx">Log Out</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        


<div class="jumbotron">
    <h1>Wall Outlet</h1>
    <p class="lead">Op deze pagina vindt u hoeveel er is verbruikt op de stopcontacten.</p>
    <!--<p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>-->
</div>
<div class="row">
    <div class="col-md-3">
         <h2>wall-outlet</h2>
        <div class="progressWallOutlet">
            <div class="percent">
                <svg>
                    <circle cx="70" cy="70" r="70"></circle>
                    <circle cx="70" cy="70" r="70"></circle>
                </svg>
                <div class="number">
                    <h2>50<span>%</span></h2>
                </div>
            </div>
            <h2 class="text">verbruikt</h2> 
            </div>
        </div>
    </div>

</div>
        <hr />
        <footer>
            <p>Sm@rt Power  -   Yenthe Van den Eynden, Nicolas Hutsebaut</p>
        </footer>
    </div>

    <script src="/Scripts/jquery-3.3.1.js"></script>

    <script src="/Scripts/bootstrap.js"></script>

    
</body>
</html>

