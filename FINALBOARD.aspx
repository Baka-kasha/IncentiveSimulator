<%@ Page Title="" Language="C#" MasterPageFile="~/INCENTIMasterPage.master" AutoEventWireup="true" CodeFile="FINALBOARD.aspx.cs" Inherits="FINALBOARD" %>

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
    }
    .leftforlab
    { 
        margin-right:10%;
    }
    .centerforlab
    { 
        margin-left:45%;
    }
                           </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
  <table style=" width:100%; margin-top:0px; top: 86px;"> <td class="style4"><span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; </span> </td> 
     
          <td> <div id="header pull-right" style="width: 100%;text-align:left;">  <asp:Label ID="Lblcount"  Font-Size="Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        <asp:Label ID="Lblwelcm"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label> 
        <br />
        <asp:Label ID="Lbldetail"  Font-Size="Medium" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
        </td>
                   <div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>   
       <asp:Button ID="Button7" CssClass="button" runat="server" OnClick="btnEMP"  Text="MY INCENTIVE" />
    <br />
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
    <br />
    <asp:Button ID="Button8" CssClass="button" runat="server" OnClick="btnFINAL" Text="DASHBOARD" />
    <br />
      <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btnsimi"   Text="SIMULATOR" />
    <br />
   <asp:Button ID="btnout" CssClass="button"  runat="server" OnClick="btnLOGOUT" Text="LOGOUT" />
   </div> <td><center>  <asp:Label ID="Label5" Font-Size="X-Large" Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label></center></td>
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
<div>  
   <hr style="width: 100%; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
   <asp:Label ID="Label4" Font-Size="Large" CssClass="centerforlab" Font-Bold="true" Font-Names="calibri" runat="server">[INCENTIVE BOARD]</asp:Label>
   <hr style="width: 100%; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
  <asp:Label ID="Lblwh" Font-Size="Large"   Font-Bold="true" Font-Names="calibri" runat="server"></asp:Label>
<hr style="width: 100%; box-shadow:0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19); margin-top: 8px; margin-left: 0px;" />
                       <table>   <tr>     <td><asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="BU: " Font-Names="calibri" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlbu" Width="150px" CssClass="ddl" ViewStateMode="Enabled"  runat="server" AutoPostBack= "true" onselectedindexchanged="ddlbu_SelectedIndexChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddlbu.ClientID %>').chosen();
                             </script> 
                  <asp:Label ID="Label2" Font-Size="Medium" Font-Bold="true" Text="ZONE: " Font-Names="calibri" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlzone" Width="150px" CssClass="ddl" ViewStateMode="Enabled"  runat="server" AutoPostBack= "true" onselectedindexchanged="ddlzone_SelectedIndexChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddlzone.ClientID %>').chosen();
                </script> 
                 <asp:Label ID="Label3" Font-Size="Medium" Font-Bold="true" Text="TEAM: " Font-Names="calibri" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlteam" Width="150px" CssClass="ddl"  ViewStateMode="Enabled"  runat="server" AutoPostBack= "true" onselectedindexchanged="ddlteam_SelectedIndexChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddlteam.ClientID %>').chosen();
                </script>
                <asp:Label ID="Label6" Font-Size="Medium" Font-Bold="true" Text="DESIGNATION: " Font-Names="calibri" runat="server"></asp:Label>
                <asp:DropDownList ID="ddldesg" Width="150px" CssClass="ddl"  ViewStateMode="Enabled"  runat="server" AutoPostBack= "true" onselectedindexchanged="ddldesg_SelectedIndexChanged">
                 </asp:DropDownList>       <script type="text/javascript">
                                               $('#<%=ddldesg.ClientID %>').chosen();
                </script>
                        
            </td>
    <td><asp:Button ID="Button4" CssClass="addbtn" runat="server" Text="ANALYSE" onclick="refersh_Click" /></td>
    <td> <asp:Button ID="Button5" CssClass="addbtn" runat="server" Text="CLEAR" onclick="Clear_Click" /></td>
    <td style="button-container"  align="right">  
    <asp:Button ID="Btnexport2" runat="server" OnClick="BtnExport_Click"  ToolTip="Export all List of your DIVISION" CssClass="addbtn" Text="EXPORT TO EXCEL" />
    
</td></tr></table>
   <hr />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:GridView ID="Organo" HeaderStyle-BackColor="#0d9dbc"
            HeaderStyle-BorderColor="#f2f2f2" HeaderStyle-BorderWidth="5px" 
        HeaderStyle-Font-Names="calibri" HeaderStyle-Font-Bold="false"
            RowStyle-BorderWidth="5px" AlternatingRowStyle-BorderWidth="5px" 
        RowStyle-Font-Names="calibri" RowStyle-HorizontalAlign="Center" 
            HeaderStyle-Height="3px" AlternatingRowStyle-Height="1px" RowStyle-Height="1px" 
            HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="#f2f2f2"  
        ShowHeader="true" ShowHeaderWhenEmpty="true"
            AlternatingRowStyle-ForeColor="Black"    AutoGenerateColumns="false"  
            AlternatingRowStyle-BorderColor="#f2f2f2"  RowStyle-BackColor="white"  OnRowDataBound="Organo_RowDataBound"
            RowStyle-BorderColor="#f2f2f2" runat="server" 
            Height="50px" Width="1506px"  >
            <Columns>
           <asp:BoundField DataField="ROW_ID" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="ROW_ID" Visible="false" ItemStyle-Width="100px"  HeaderStyle-Width="100px" />
                          <asp:BoundField DataField="DIVISION" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left" HeaderText="DIVISION" ItemStyle-Width="100px"   HeaderStyle-Width="100px" Visible="false" />
                           <asp:BoundField DataField="TEAM" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="left"  HeaderStyle-HorizontalAlign="Left" HeaderText="TEAM" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                                <asp:BoundField DataField="DESIGNATION" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="DESIGNATION" ItemStyle-Width="50px"   HeaderStyle-Width="100px" />
   <asp:BoundField DataField="ZONE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="ZONE"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" Visible="false" /> 
       <asp:BoundField DataField="FS_CODE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="FS_Code"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" /> 
                     <asp:BoundField DataField="EMP_NAME" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderText="NAME"  ItemStyle-Width="450px"  HeaderStyle-Width="100px" /> 
  <asp:BoundField DataField="CLIENT_HQ" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left" HeaderText="HQ"  ItemStyle-Width="350px"  HeaderStyle-Width="300px" /> 
  <asp:BoundField DataField="NOP_HQ" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="center" HeaderText="NOP"  ItemStyle-Width="100px"  HeaderStyle-Width="100px" />      
                    <asp:BoundField DataField="BRAND1" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="BRAND1 ₹"   ItemStyle-Width="200px"  HeaderStyle-Width="200px" /> 
                              <asp:BoundField DataField="BRAND2" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="BRAND2 ₹"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
                           <asp:BoundField DataField="BRAND3" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="BRAND3 ₹"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
  <asp:BoundField DataField="KPI1" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="KPI1 ₹"   ItemStyle-Width="200px"  HeaderStyle-Width="200px" /> 
                              <asp:BoundField DataField="KPI2" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="KPI2 ₹"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
                           <asp:BoundField DataField="Consistency" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="CONSISTENCY"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
  <asp:BoundField DataField="PCPM" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="PCPM"   ItemStyle-Width="200px"  HeaderStyle-Width="200px" /> 
                              <asp:BoundField DataField="DIQ" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="DAYS in QTR"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
                            <asp:TemplateField HeaderText="TOTAL AMOUNT ₹" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Width="200px" >
        <ItemTemplate >
       
             <asp:Label ID="Incent1" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="PAYOUT" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="PAYOUT  ₹"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
                            <asp:BoundField DataField="ELIGIBLE" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="EXCEPTION"  ItemStyle-Width="200px"  HeaderStyle-Width="200px" />    
                          
 </Columns>           
                  </asp:GridView>
</asp:Content>

