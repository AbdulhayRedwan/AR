<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >

     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="author" content="ThemeSelect">
    <title>Dashboard</title>
    
    <link rel="apple-touch-icon" href="Admin/theme-assets/images/ico/apple-icon-120.png">
    <link rel="shortcut icon" type="image/x-icon" href="Admin/theme-assets/images/ico/favicon.ico">
    <link href="https://fonts.googleapis.com/css?family=Muli:300,300i,400,400i,600,600i,700,700i%7CComfortaa:300,400,700" rel="stylesheet">
    <link href="https://maxcdn.icons8.com/fonts/line-awesome/1.1/css/line-awesome.min.css" rel="stylesheet">
    <!-- BEGIN VENDOR CSS-->
    <link rel="stylesheet" type="text/css" href="Admin/theme-assets/css/vendors.css">
    <link rel="stylesheet" type="text/css" href="Admin/theme-assets/vendors/css/charts/chartist.css">
    <!-- END VENDOR CSS-->
    <!-- BEGIN CHAMELEON  CSS-->
    <link rel="stylesheet" type="text/css" href="Admin/theme-assets/css/app-lite.css">
    <!-- END CHAMELEON  CSS-->
    <!-- BEGIN Page Level CSS-->
    <link rel="stylesheet" type="text/css" href="Admin/theme-assets/css/core/menu/menu-types/vertical-menu.css">
    <link rel="stylesheet" type="text/css" href="Admin/theme-assets/css/core/colors/palette-gradient.css">
    <link rel="stylesheet" type="text/css" href="Admin/theme-assets/css/pages/dashboard-ecommerce.css" />
    
</head>
<body   >
       <form id="form1" runat="server">
 
           <!-- fixed-top-->
   

  

    <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-wrapper-before"></div>
        <div class="content-header row">
          <div class="content-header-left col-md-4 col-12 mb-2">
            <h3 class="content-header-title"> </h3>
          </div>
          <div class="content-header-right col-md-8 col-12">
            <div class="breadcrumbs-top float-md-right">
              <div class="breadcrumb-wrapper mr-1">
                <ol class="breadcrumb">
                  <li class="breadcrumb-item"><a href="index.html">Home</a>
                  </li>
                  <li class="breadcrumb-item active">Login
                  </li>
                </ol>
              </div>
            </div>
          </div>
        </div>
        <div class="content-body"><!-- ../../../theme-assets/images/carousel/22.jpg -->

 

 

<!-- Text Alignment section start -->
<section id="text-alignments">
	<div class="row">
		<div class="col-12 mt-3 mb-1">
			<h4 class="text-uppercase"> </h4>
			 
		</div>
	</div>
	<div class="row">
		<div class="col-lg-4 col-md-12">
			<div class="card">
				 
			</div>
		</div>
		<div class="col-lg-4 col-md-12">
			<div class="card text-center">
				<div class="card-body">
					<h4 class="card-title">Login</h4>
					 
                    	<div class="card-body">
						<div class="form">
							<div class="form-body">
								<div class="form-group">
									<label for="donationinput1" class="sr-only">Email</label>

                                    <asp:TextBox ID="txt_Email" runat="server"  class="form-control" placeholder="* Email"></asp:TextBox> 
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_Email" runat="server" ValidationGroup="f" ErrorMessage="*please Enter Correct Email"     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>

 
								</div>
								<div class="form-group">
									<label for="donationinput2" class="sr-only">Password</label>
									<asp:TextBox ID="txt_Password" runat="server"  class="form-control" placeholder="* Password" TextMode="Password"></asp:TextBox>

								</div>
								<div class="form-group">
									<label for="donationinput3" class="sr-only">E-mail</label>
								         <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"  >
                                             <asp:ListItem Value="1">Admin&nbsp;</asp:ListItem>
                                             <asp:ListItem Value="2">Event_Manager&nbsp;</asp:ListItem>
                                             <asp:ListItem Value="3">Guider&nbsp;</asp:ListItem>
                                              <asp:ListItem Value="4">Tourists&nbsp;</asp:ListItem>

                                    </asp:RadioButtonList>
								</div>
  <div class="form-group">
    <asp:Label ID="lbl_msg" runat="server"  ></asp:Label> 
 
    </div>
							 
							</div>
							<div class="form-actions center">

                                        <asp:Button ID="btn_Login" runat="server"  class="btn btn-outline-primary" Text="Login" OnClick="btn_Login_Click"  ValidationGroup="f"/>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Visitors/Default.aspx">Main Page ..</asp:HyperLink>
							</div>
						</div>
					</div>





				</div>
			</div>
		</div>
		<div class="col-lg-4 col-md-12">
			<div class="card text-right">
		 
			</div>
		</div>
	</div>
</section>
 
  
        </div>
      </div>
    </div>
    <!-- ////////////////////////////////////////////////////////////////////////////-->

           <br /> <br /> <br /> <br /> 
    <footer class="footer footer-static footer-light navbar-border navbar-shadow">
      <div class="clearfix blue-grey lighten-2 text-sm-center mb-0 px-2"><span class="float-md-left d-block d-md-inline-block">2023  &copy; Copyright <a class="text-bold-800 grey darken-2" href="#" target="_blank">Tout</a></span>
        <ul class="list-inline float-md-right d-block d-md-inline-blockd-none d-lg-block mb-0">
          <li class="list-inline-item"><a class="my-1" href="#" target="_blank"> More </a></li>
          <li class="list-inline-item"><a class="my-1" href="#" target="_blank"> Support</a></li>
          <li class="list-inline-item"><a class="my-1" href="#" target="_blank"> Purchase</a></li>
        </ul>
      </div>
    </footer>

    <!-- BEGIN VENDOR JS-->
    <script src="Admin/theme-assets/vendors/js/vendors.min.js" type="text/javascript"></script>
    <!-- BEGIN VENDOR JS-->
    <!-- BEGIN PAGE VENDOR JS-->
    <!-- END PAGE VENDOR JS-->
    <!-- BEGIN CHAMELEON  JS-->
    <script src="Admin/theme-assets/js/core/app-menu-lite.js" type="text/javascript"></script>
    <script src="Admin/theme-assets/js/core/app-lite.js" type="text/javascript"></script>
    <!-- END CHAMELEON  JS-->
    <!-- BEGIN PAGE LEVEL JS-->
    <!-- END PAGE LEVEL JS-->





            </form>

    

  
 
</body>
     
 
</html>
