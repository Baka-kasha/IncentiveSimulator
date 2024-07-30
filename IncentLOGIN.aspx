    <%@ Page Title="" Language="C#" MasterPageFile="~/INCENTIMasterPage.master" AutoEventWireup="true" CodeFile="IncentLOGIN.aspx.cs" Inherits="IncentLOGIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<head>	<title>Login Page</title>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" integrity="sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP" crossorigin="anonymous">
</head>
<style type="text/css">
body,panel {
			margin: 0;
			padding: 0;
			height: 100%;
			background: #009DBC !important;
		}
		.user_card {
			height: 400px;
			width: 350px;
			margin-top: 70px;
			margin-bottom: auto;
			background: white;
			position: relative;
			display: flex;
			justify-content: center;
			flex-direction: column;
			padding: 10px;
			box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
			-webkit-box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
			-moz-box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
			border-radius: 5px;

		}
		.brand_logo_container {
			position: absolute;
			height: 165px;
			width: 168px;
			top: -75px;
			border-radius: 50%;
			border-color:#0d9dbc;
			background: #0d9dbc;
			padding: 0px;
			text-align: center;
		}
		.brand_logo {
			height: 166px;
			width: 175px;
			border-radius: 50%;
							border-bottom: 3px Solid  #009DBC;
						border-right: 3px Solid  #009DBC;
						border-left: 3px Solid  #009DBC;
						border-top: 3px Solid #009DBC;
		}
		.brand_logo1 {
			height: 50px;
			width: 120px;
			 border-color: 5px Solid white;
			 border-width: thick;
			 	border-bottom: 3px Solid  #009DBC;
						border-right: 3px Solid #009DBC;
						border-left: 3px Solid #009DBC ;
						border-top: 3px Solid #009DBC;
		}
		
		.form_container {
			margin-top: 100px;
		}
		.login_btn {
			width: 100%;
			background: #0d9dbc !important;
			color: white !important;
		}
		.login_btn:focus {
			box-shadow: none !important;
			outline: 0px !important;
		}
		.login_container {
			padding: 0 2rem;
		}
		.input-group-text {
			background: #0d9dbc !important;
			color: white !important;
			border: 0 !important;
			border-radius: 0.25rem 0 0 0.25rem !important;
		}
		.input_user,
		.input_pass:focus {
			box-shadow: none !important;
			outline: 0px !important;
		}
		.custom-checkbox .custom-control-input:checked~.custom-control-label::before {
			background-color: #0d9dbc !important;
		}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<body>
<panel>
<div class="container">
	<div class="container h-100">
		<div class="d-flex justify-content-center h-100">
			<div class="user_card">
				<div class="d-flex justify-content-center login_container">
					<div class="brand_logo_container">
						<img src="images/00000GALDERMA_LOGO_BLACK_RGB_SMALLLogo.jpg" class="brand_logo" alt="Logo"/>
					</div>
				</div>	
					<form action="Loginpage.aspx">
                       <div class="container mt-0 login_container">
                  <h3 class="container mt-5 align-items-center login_container">Member Login</h3> 
                     <div class="container mt-auto align-items-center login_container">
						<div class="input-group mb-3">
							<div class="input-group-prepend">
								<span class="input-group-text"><i class="fas fa-user"></i></span>
                        <asp:TextBox ID="Txtboxempcode" CssClass="form-control input_user" TextMode="SingleLine" runat="server"></asp:TextBox>
                     </div>
						</div>
                        </div>
                        <div class="container align-items-center login_container">
						<div class="input-group mb-2">
							<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-key"></i></span>	
                       <asp:TextBox ID="Txtboxpass" CssClass="form-control input_pass" ToolTip="Enter your password" TextMode="Password" runat="server"></asp:TextBox>			
                            </div>
						</div></div>
						<div class="form-group login_container">
							<div class="custom-control custom-checkbox">
                            <asp:CheckBox ID="customControlInline" CssClass="custom-control-input" runat="server"></asp:CheckBox>	
								<label class="custom-control-label" for="customControlInline">Remember me</label>
							</div>
						</div>
							<div class="container mt-2 login_container">
               <asp:Button ID="Btnlogin" CssClass="btn login_btn" runat="server"  onclick="Button1_Click"  Text="Login"></asp:Button>
			   </div> 
				<div class="mt-4 ">
					<%--<div class="container  align-items-center login_container">
						Don't have an account? <a href="#" class="ml-2">Sign Up</a>
					</div>--%>
					<div class="container  align-items-center login_container">
				<%--		 <asp:HyperLink id="hyperlink1" NavigateUrl="loginpassword.aspx" Text="Change password?" runat="server"/>
	--%>				</div>
				</div></div> <center><asp:Label ID="Lblmessage" runat="server"></asp:Label>	</center>
                </form>
				</div>
		</div>
	</div></div>
    </panel>
    <center>
            <br />
      <asp:Label ID="lblVersion" runat="server" Text="powered by" Font-Size="X-Small" ForeColor="White"></asp:Label>
            <div >
                <img src="images/Logo[99].jpg"  class="brand_logo1"  alt="Logo"  />		
					</div>
           </center>
</body>
</asp:Content>

