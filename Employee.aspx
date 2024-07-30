<%@ Page Title="" Language="C#" MasterPageFile="~/INCENTIMasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" 
    integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" 
    integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" /> 
    <style type="text/css">
      .sidenav {
  height:100%;
  width: 0;
  position: fixed;
  z-index: 1;
  top: 10;
  left: 0; 
  background-color:#0d9dbc;
  overflow-x: hidden;
  transition: 0.5s;
  border-radius: 0px 10px 0px 0px;
  padding-top:60px;
}

.sidenav a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color:White;
  display: block;
  transition: 0.3s;
}

.sidenav a:hover {
  color:#0d9dbc;
}

.sidenav .closebtn {
  position: absolute;
  top: 0;
  right: 25px;
  font-size: 36px;
  margin-left: 50px;
}
 .button
 {
   box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
       border:none;
       width:300px;
       height:50px;
       background-color:#0d9dbc;
       color:white;
       text-align:center;
      }
     #header
        {
            width: 1731px;
            margin-left: 0px;
        }
        .Panell
        {
            margin-left: 0px;
            text-align:center;
            background-color:#0d9dbc;
            color:White;
            margin-top: 0px;
            margin-bottom: 0px;
            margin-left: 118px;
            border-radius:13px;
            padding:15px 50px 0px 20px;
            font-size:large;
            
        }
        .addbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
            color:White;
            height:30px;
                           }
      .popblbtn
      { 
             border:none;
             background-color:White;
             color:White;
             height:1px;
             width:1px;
                           }
             .popbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:50px;
                           }
                           .popbtn2
 .popbtn
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:35px;
             width:100px;
                           }
          .modalBackground
    {
        background-color:Black;
        filter:alpha(opacity=90) !important;
        opacity:0.6 !important;
        z-index:30;
    }
    .box
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:200px;
    }
    .boxsresn
      {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:100px;
    }
     .ddl
    {
         box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
         border-radius:6px;
         border-style:none;
         height:25px;
         width:80px;
    }
     .btn1
        { 
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            border-radius:6px;
            border-style:none;
            background-color:#0d9dbc;
             color:White;
             height:40px;
             Width:150px; 
                          }
                           .PanelB
    { border-color:Black; 
       border-radius:15px 15px 0px 0px;
       background-color:#F2F2F2;
        width:200px;
        height:150px;
             box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        }
          
    .modalpopup
    {
     border-radius:15px 15px 15px 15px; 
        position:relative;
        width:450px;
        height:90px;
         top: 50px;
          left:500px;
        text-align:center;
        background-color:White;
        border:1px solid black;    
       vertical-align:middle;    
    }
                   .rigg
               {
                   text-align:left;
               }
        .hidden { display: none; }
     .badge-notify {
            background: red;
            position: relative;
            top: -20px;
            left: -35px;
        }
                           .style4
    {
        width: 45px;
            height: 33px;
        }
    .leftforlab
    { 
        margin-right:10%;
    }
    .centerforlab
    { 
        margin-left:45%;
    }
                           .style5
        {
        }
                           .style8
        {
            width: 309px;
            height: 23px;
        }
                           .style10
        {
            width: 541px;
            height: 33px;
        }
        .style11
        {
            height: 33px;
            width: 4250px;
        }
                           </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:HiddenField ID="Hidnfldname" runat="server" />
        <asp:HiddenField ID="Hidnfldcode" runat="server" />
            <asp:HiddenField ID="Hidnfldiv" runat="server" />
              <asp:HiddenField ID="Hidnfldlogin" runat="server" />  
                <div id="header pull-left" style="width: 100%">
       <p style="background-color:#0d9dbc; height: 9px; width: 100%; margin-bottom: 9px;"><br />
          <img src="images/222200000GALDERMA_LOGO_BLACK_RGB_SMALLLogo.jpg" style=" margin-left:10px; height: 50px; width:100px" />
  <asp:Panel ID="Panel1" CssClass="Panell" runat="server" Width="87%" Height="31px">
      <label style="width: 718px; text-align:left;  margin-bottom:30px; margin-top:20px; font-family:Calibri; margin-left:0px"><b>
          INCENTIVE </b></label> 
        </asp:Panel>
   <hr style="height:8px; background-color:#0d9dbc; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); width: 100%; margin-left: 0px;" />
   <table style=" width:100%; margin-top:0px; top: 86px; height: 41px;"> <td class="style4"><span style="font-size:15px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
     
          <td class="style10"> <div id="header pull-right" 
                  style="width: 91%; text-align:left;">  <asp:Label ID="Lblcount"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> 
        <br />
        <asp:Label ID="Lbldetail"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        </td>
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>   
    <asp:Button ID="Button7" CssClass="button" runat="server" OnClick="btnEMP"  Text="MY INCENTIVE" />
     <asp:DropDownList ID="ddlparameters1" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlparameters1_SelectedIndexChanged" runat="server">
                         <asp:ListItem Text="QUANTITATIVE"></asp:ListItem>
                         <asp:ListItem Text="BRAND 1" Value="Brnd1"></asp:ListItem>
                         <asp:ListItem Text="BRAND 2" Value="Brnd2"></asp:ListItem>
                         <asp:ListItem Text="BRAND 3" Value="Brnd3"></asp:ListItem>
                        </asp:DropDownList>
          <asp:DropDownList ID="ddlparameters2" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlparameters2_SelectedIndexChanged" runat="server">              
                      <asp:ListItem Text="QUALITATIVE"></asp:ListItem>
                           <asp:ListItem Text="KPI 1" Value="K1"></asp:ListItem>
                         <asp:ListItem Text="KPI 2" Value="K2"></asp:ListItem>
                          </asp:DropDownList>

         <asp:DropDownList ID="ddlparameters3" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlparameters3_SelectedIndexChanged" runat="server"> 
                          <asp:ListItem Text="CONSISTENCY"></asp:ListItem>
                          <asp:ListItem Text="Consistency" Value="cnstncy"></asp:ListItem>
    </asp:DropDownList>

    <asp:DropDownList ID="ddlmultiplier" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlmultiplier_SelectedIndexChanged" runat="server">
                         <asp:ListItem Text="PRODUCTIVITY"></asp:ListItem>
                         <asp:ListItem Text="PCPM" Value="pcpm"></asp:ListItem>
                         <asp:ListItem Text="PRO RATA FACTOR" Value="pfactor"></asp:ListItem>                       
    </asp:DropDownList>

    <asp:DropDownList ID="ddlqualifiers" CssClass="button" AutoPostBack="true" onselectedindexchanged="ddlqualifiers_SelectedIndexChanged" runat="server">
                         <asp:ListItem Text="QUALIFIERS"></asp:ListItem>
                         <asp:ListItem Text="OVERALL ACH" Value="ovrall"></asp:ListItem>
                         <asp:ListItem Text="PRI-SEC RATIO" Value="prisec"></asp:ListItem>
                         <asp:ListItem Text="SnB" Value="snb"></asp:ListItem>
                         <asp:ListItem Text="NEXT MONTH ACH" Value="nxtmon"></asp:ListItem>
                         <asp:ListItem Text="CALL AVERAGE" Value="callavg"></asp:ListItem>
                 </asp:DropDownList>
                     <asp:Button ID="Button6" CssClass="button" runat="server" OnClick="btnQuailifiers"   Text="APPROVAL PAGE" />
    <asp:Button ID="Button8" CssClass="button" runat="server" OnClick="btnFINAL" Text="DASHBOARD" />
      <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btnsimi"   Text="SIMULATOR" />
   <asp:Button ID="btnout" CssClass="button"  runat="server" OnClick="btnLOGOUT" Text="LOGOUT" />
   </div> <td class="style11"> <center><asp:Label ID="Label5" Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center></td>
  <td class="style10"> 
      <div id="Div1" 
                  style="width: 100%; text-align:left;"> <left><asp:Label ID="Label81"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></left> 
      <left>  <asp:Label ID="Label82"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> </left> 
        <br />
      <left>  <asp:Label ID="Label83"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></left> 
        </td>
     </table>   
<script type="text/javascript">
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
</script>
</p>
</div>
 <hr style="width: 100%; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
   
<div id = "DIV111" runat="server" >    
   <table>
   <%----HEADER----%>
   <tr><th class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal;  border-radius: 10px" > COMPONENTS </th> 
   <th class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal;  border-radius: 10px" > TARGET (in Lacs.)</th> 
   <th class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);background-color:#0d9dbc;color:White; font-style:normal; border-radius: 10px" > VALUE (in Lacs.)</th> 
   <th class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);background-color:#0d9dbc;color:White; font-style:normal; border-radius: 10px"> ACH %</th> 
   <th class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px"> INCENTIVE ₹ (in Rupees)</th> </tr>
    
   <%----BRAND 1----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label11" CssClass="style5" Height="100%" Font-Bold="True" Text="BRAND 1" Font-Names="calibri" runat="server"  Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label9" CssClass="style5" Height="100%" Font-Bold="true"  ToolTip="Brand 1 Target" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label6" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Brand 1 Value" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label7" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 1 Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label8" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 1 Incentive" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
    <%----BRAND 2----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label10" CssClass="style5" Height="100%" Font-Bold="True" Text="BRAND 2" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label12" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 2 Target" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label13" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Brand 2 Value" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label14" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 2 Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label15" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 2 Incentive" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
    <%----BRAND 3----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label16" CssClass="style5" Height="100%" Font-Bold="True" Text="BRAND 3" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label17" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 3 Target" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label18" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Brand 3 Value" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label19" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 3 Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label20" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Brand 3 Incentive" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
     <%----KPI 1----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label21" CssClass="style5" Height="100%" Font-Bold="True" Text="KPI 1" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label22" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Minimum KPI 1 value" Text="-" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label24" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="KPI 1" Text="-" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label23" CssClass="style5" Height="100%" Font-Bold="true"  ToolTip="KPI 1 Ach%"  Text="-" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label25" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="KPI 1 Incentive" Text="KPI 1 Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
    <%----KPI 2----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label26" CssClass="style5" Height="100%" Font-Bold="True" Text="KPI 2" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label27" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Minimum KPI 2 value" Text="-" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label29" CssClass="style5" Height="100%"  Font-Bold="true" Text="-" ToolTip="KPI 2" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label28" CssClass="style5" Height="100%" Font-Bold="true"  ToolTip="KPI 2 Ach%" Text="-" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label30" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="KPI 2 Incentive" Text="KPI 2 Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
     <%----Total ----%>
   <tr>  
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px"> <center><asp:Label ID="Label67" CssClass="style5" Height="100%" Font-Bold="True" Text="TOTAL AMOUNT" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label69" CssClass="style5" Height="100%" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label73" CssClass="style5" Height="100%"  Font-Bold="true"  Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label74" CssClass="style5" Height="100%" Font-Bold="true"  Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);background-color:White;color:Black; font-style:normal; border-radius: 10px"><center> <asp:Label ID="Label75" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Total Amonut" Text="Consistency Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
   </table>
<%--     <hr />
   <table>
   <tr><td  colspan="5"  class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px" > 
   <center><asp:Label ID="Label67" CssClass="style5" Height="100%" Font-Bold="True" 
           Text="MUTLIPLIER" Font-Names="calibri" runat="server" Width="1500px"></asp:Label> </center> </td> 
  </tr> </table> --%>
     <hr />
   <table>
    <%----PCPM ----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label36" CssClass="style5" Height="100%" Font-Bold="True" Text="PCPM" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label37" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Minimum PCPM value" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label38" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="PCPM value"  Text="-" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label39" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="PCPM Ach%"  Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label40" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Power factor"  Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
    <%----DIQ ----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label61" CssClass="style5" Height="100%" Font-Bold="True" Text="DAYS in QTR" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label62" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Minimum Days Count" Text="-" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label63" CssClass="style5" Height="100%"  Font-Bold="true"  ToolTip="Days in Company" Text="-" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label64" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="DIQ Ach%"  Text="-" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label65" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Pro Rata Factor"  Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
     <%----Consitency ----%>
   <tr>  
   <td class="style8"> <center><asp:Label ID="Label31" CssClass="style5" Height="100%" Font-Bold="True" Text="CONSISTENCY Q2" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label32" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Minimum Consistency value" Text="-" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label33" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Consistency" Text="-" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label34" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Consistency Ach%" Text="-" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label35" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Consistency Qtr 2" Text="Consistency Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
    <%----Total ----%>
   <tr>  
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px"> <center><asp:Label ID="Label84" CssClass="style5" Height="100%" Font-Bold="True" Text="TOTAL AMOUNT" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label85" CssClass="style5" Height="100%" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label86" CssClass="style5" Height="100%"  Font-Bold="true"  Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label87" CssClass="style5" Height="100%" Font-Bold="true"  Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);background-color:White;color:Black; font-style:normal; border-radius: 10px"><center> <asp:Label ID="Label88" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Total Amonut" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
   </table>
     <hr />
<%--<table>
   <tr><td colspan="5" class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px" > 
   <center><asp:Label ID="Label69" CssClass="style5" Height="100%" Font-Bold="True" 
           Text="APPROVAL PAGE" Font-Names="calibri" runat="server" Width="1500px"></asp:Label> </center> </td> 
  </tr> </table>  <hr />--%>
 
     <%----HEADER----%>
   
      <%----Overall ----%>
        <table>
   <tr id ="TAB11" runat="server">  
   <td class="style8"> <center><asp:Label ID="Label41" CssClass="style5" Height="100%" Font-Bold="True" Text="OVERALL ACH" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label42" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Qtr Target"  Text="Overall Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label43" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Qtr Value"  Text="Overall Ach%" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label44" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Qtr Ach %"  Text="Overall Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label45" CssClass="style5" Height="100%" Font-Bold="true" Text="Overall Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
     <%----NxtMon ----%>
   <tr id ="TAB12" runat="server">  
   <td class="style8"> <center><asp:Label ID="Label56" CssClass="style5" Height="100%" Font-Bold="True" Text="NEXT MONTH ACH" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label57" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Next Month Target"  Text="Next Month Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label58" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Next Month Value"  Text="Next Month Ach%" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label59" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Next Month Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label60" CssClass="style5" Height="100%" Font-Bold="true" Text="Next Month Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>  

  <%----CallAvg ----%>
    <tr id ="TAB13" runat="server">  
   <td class="style8"> <center><asp:Label ID="Label4" CssClass="style5" Height="100%" Font-Bold="True" Text="CALL AVG" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label68" CssClass="style5" Height="100%" Font-Bold="true"   Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label70" CssClass="style5" Height="100%"  Font-Bold="true" Text="-" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label71" CssClass="style5" Height="100%" Font-Bold="true" Text="-" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label72" CssClass="style5" Height="100%" Font-Bold="true" Text="Next Month Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>  
 
   <%----PriSec ----%>
   <tr id ="TAB14" runat="server">  
   <td class="style8"> <center><asp:Label ID="Label46" CssClass="style5" Height="100%" Font-Bold="True" Text="PRI vs SEC ACH" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label47" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Pri Value"  Text="PriSec Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label48" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="Sec Value"  Text="PriSec Ach%" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label49" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="PriSec Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label50" CssClass="style5" Height="100%" Font-Bold="true" Text="PriSec Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
    <%----SnB ----%>
   <tr id ="TAB15" runat="server">  
   <td class="style8"> <center><asp:Label ID="Label51" CssClass="style5" Height="100%" Font-Bold="True"  Text="SNB ACH " Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label52" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Minimum SnB value" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label53" CssClass="style5" Height="100%"  Font-Bold="true" ToolTip="SnB Value" Text="SnB Ach%" Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label54" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="SnB Ach%" Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8"><center> <asp:Label ID="Label55" CssClass="style5" Height="100%" Font-Bold="true" Text="SnB Ach%" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   <%----Total ----%>
   <tr id ="TAB16" runat="server">  
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px"> <center><asp:Label ID="Label76" CssClass="style5" Height="100%" Font-Bold="True" Text="ELIGIBILITY" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label77" CssClass="style5" Height="100%" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> </center></td> 
   <td class="style8"> <center><asp:Label ID="Label78" CssClass="style5" Height="100%"  Font-Bold="true"  Font-Names="calibri" runat="server"></asp:Label></center> </td> 
   <td class="style8"> <center><asp:Label ID="Label79" CssClass="style5" Height="100%" Font-Bold="true"  Font-Names="calibri" runat="server"></asp:Label></center></td> 
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);background-color:White;color:Black; font-style:normal; border-radius: 10px"><center> <asp:Label ID="Label80" CssClass="style5" Height="100%" Font-Bold="true" ToolTip="Total Amonut" Font-Names="calibri" runat="server"></asp:Label> </center></td> </tr>
   
   </table> 
   <hr />
     <table>
     <%----HEADER----%>
   <tr><td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px" > 
   <center><asp:Label ID="Label1" CssClass="style5" Height="100%" Font-Bold="True" Text="TOTAL INCENTIVE" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center> </td> 
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:White ; color:Black; font-style:normal;  border-radius: 10px" > 
   <center><asp:Label ID="Label2" CssClass="style5" Height="100%" Font-Bold="True" Text="AMOUNT" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center> </td>  
   <td class="style8"  >  </td> 
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); background-color:#0d9dbc; color:White; font-style:normal; border-radius: 10px"> 
    <center><asp:Label ID="Label3" CssClass="style5" Height="100%" Font-Bold="True" Text="PAYOUT AMOUNT" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center> </td>  
   <td class="style8" style="box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);background-color:White;color:Black; font-style:normal; border-radius: 10px"> 
   <center><asp:Label ID="Label66" CssClass="style5" Height="100%" Font-Bold="True" Text="AMOUNT" Font-Names="calibri" runat="server" Width="272px"></asp:Label> </center>  </td> </tr>
      </table>
   <hr />
   </div>
</asp:Content>

