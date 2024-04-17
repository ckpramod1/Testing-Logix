<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="logix.CustomerRegistration" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register Assembly="Typad" Namespace="Typad" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Customer Registration</title>


     <script type="text/javascript" src="Scripts/Calendar.js"></script> 
    <script type="text/javascript" src="Scripts/Validation.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Style/jquery-ui.css" rel="Stylesheet" type="text/css" />
     <!-- Bootstrap -->
    <link href="Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Theme/bootstrap/css/bootstrap-select.css">
    <link rel="icon" type="image/png" sizes="36x21" href="Theme/assets/img/favicon.png">
    <link href="Theme/assets/css/new_style.css" rel="stylesheet" />
    <!-- Theme -->

    <link href="Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Theme/assets/css/fontawesome/font-awesome.min.css">
    
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />

    <!--=== JavaScript ===-->

    <%--<script type="text/javascript" src="Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="Theme/Content/bootstrap/js/bootstrap.min.js"></script>

    <!-- Smartphone Touch Events -->


    <!-- Page specific plugins -->
    <!-- Charts -->
    


   

  

    <!-- Demo JS -->








   <script type="text/javascript" src="Scripts/Calendar.js" ></script> 
   <script type="text/javascript" src="Scripts/Validation.js" ></script> 
   <%--<script type="text/javascript" src="Scripts/Focus.js" ></script>--%> 

   <%-- <script src="Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>--%>
        <link href="Style/jquery-ui.css" rel="stylesheet" type="text/css" />

     <script type="text/javascript">

         function pageLoad(sender, args) {

             $(document).ready(function () {
                 $("#<%=txtCity .ClientID %>").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             url: "CustomerRegistration.aspx/GetLikePort",
                             data: "{ 'prefix': '" + request.term + "'}",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             success: function (data) {

                                 response($.map(data.d, function (item) {

                                     return {
                                         label: item.split('~')[0],
                                         val: item.split('~')[1],
                                         address: item.split('~')[2],
                                         text: item.split('~')[3]

                                     }
                                 }))

                             },

                             error: function (response) {
                                 alertify.alert(response.responseText);
                             },
                             failure: function (response) {
                                 alertify.alert(response.responseText);
                             }
                         });

                     },
                     select: function (event, i) {
                         $("#<%=txtCity.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtCountry.ClientID %>").val(i.item.val);


                            $("#<%=txtCity.ClientID %>").change();
                        },
                     focus: function (event, i) {
                         $("#<%=txtCity.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtCountry.ClientID %>").val(i.item.val);


                        },

                     change: function (event, i) {
                         if (i.item) {
                             $("#<%=txtCity.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=txtCountry.ClientID %>").val(i.item.val);

                                $("#<%=txtCity.ClientID %>").change();
                            }
                        },

                     close: function (event, i) {
                         var result = $("#<%=txtCity.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txtCity.ClientID %>").val($.trim(result));
                        },
                     minLength: 1

                 });

             });
              <%--  $('#<%=grdcus.ClientID %>').Scrollable();--%>
         }
</script>
    <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js'></script>
<script src='https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js' type='text/javascript'></script>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
<script src="js/scriptcapt.js"></script>
    <script src="https://www.google.com/recaptcha/api.js"></script>
  
<style type="text/css">
    .crumbs {
    background: #fff none repeat scroll 0 0;
    border-bottom: 1px solid #d9d9d9;
    height: 36px;
    margin: 50px -20px 0 0;
}
    .widget.box {
    border: 1px solid #d9d9d9;
    float: left;
    margin-left: 0;
    margin-top: 0;
    width: 98%;
    height:550px;
}
    .right_btn {
    float: left;
    margin: 0px 0 0 358px;
}



.Caddress {
    
    
    color: #FFFFFF;
    font-size: 18px;   
    text-align: left;    
    white-space: nowrap;     
     width:85%; 
     margin:-15px 0px 0px 0px; 
     float:left;
     font-family:"Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
}

   .Caddress span {
    display: inline-block;
    padding: 24px 0px 0px 0px;
    margin: 0px 0px -12px 0px;
}
.LoginCompanyName img {
    margin: 1px 10px 0px 0px;
    width: 32px;
    height: 28px;
}
.row {
    height: 568px !important;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    background-color: #ffffff;
    width: 82%;
     margin: 73px 0px 0px -4px!important; 
}   
</style>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       </ContentTemplate>
       </asp:UpdatePanel>
         

        <header class="header navbar navbar-fixed-top" role="banner"> 
      <!-- Top Navigation Bar -->

                       <div class="container"> 
                            <div class="LoginCompanyName">

         <a class="navbar-brand" href="#"><asp:Image ID="img_Logo" runat="server" Width="75" Height="48" ImageUrl="~/images/MR.png" /> </a>
             
             <div id="div_address" runat="server" class="Caddress">
                       <span>FORWARDING PRIVATE LIMITED</span> 
                    </div>
<span id="div_user" runat="server" class="CNAME"></span>

    </div>
                           <div class="FloatRightbtn1">
                           
                           <div class="LogIn">
                               <a href="login.aspx">
                            <img src="Theme/buttonIcon/login_ic.png" title="Login" alt="Login" />
                                   </a>
                               <%--<a href="UserLogin.aspx" class="SignOut">&nbsp; </a>--%>
                                <asp:LinkButton role="menuitem"  ID="LinkButton2"  CssClass="LOGINBTN"   runat="server"></asp:LinkButton>
                           </div>
                           </div>

                           </div>
                      </header>

        <div style="clear:both;"></div>
          <!-- Breadcrumbs line -->
          

<div  style="margin:73px 0px 0px 0px;!important">
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box">
     
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i>  <asp:Label ID="Label10" runat="server" Text="Thank you for your interest on services."></asp:Label></h4>
                </div>
          <div class="widget-content">
             
              <div class="FormGroupContent4">
                  <div class="SignupContent">

                      <p>Please fill in following format. After having received your relevant details, we will contact you as soon as possible to provide you with a Password and ID allowing you to go on-line with us. After having received your Password we recommend you to change this Password immediately for your own safety. A Password and ID No. will however only be provided to genuine users of our system. We reserve the right to a final decision on whom to supply a Password and ID No. Your comments are welcome, if you have any questions or comments you may contact us by email. <font color="Red">Please do not update more than one e-Mail ID</p>


                  </div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="TypeTxt">Type</div>
                  <div class="TypeDrop"><asp:DropDownList ID="ddlCustType" runat="server" Font-Names="sans-serif" Font-Size="Small"
                                    Width="119px" TabIndex="1">
                                    <asp:ListItem>Shipper</asp:ListItem>
                                    <asp:ListItem>Consignee</asp:ListItem>
                                 <asp:ListItem>OverSeas Agent</asp:ListItem>
                                    <asp:ListItem>Forwarder</asp:ListItem>
                                   <asp:ListItem>Customs House Broker</asp:ListItem>
                                    <%--<asp:ListItem>CHA</asp:ListItem>--%>
                                </asp:DropDownList></div>
                  <div class="right_btn MT0">

                       <div class="btn btn-submit"><asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit"  TabIndex="13" /></div>
                      <div class="btn ico-cancel"><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" TabIndex="14" /></div>

                  </div>
                
                  </div>
              <div class="FormGroupContent4">
                  <div class="CompanyNameTxt">Company Name</div>
                  <div class="CompanyNameTxtbox"><asp:TextBox ID="txtCompanyName" runat="server" TabIndex="2" MaxLength="100" CssClass="form-control"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="ContactPersontxt">Contact Person</div>
                  <div class="ContactPersonTxtbox"><asp:TextBox ID="txtContPerson" runat="server" TabIndex="3" MaxLength="50" CssClass="form-control"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="AddressTxt">Address</div>
                  <div class="AddressTxtbox"><asp:TextBox ID="txtAddr" runat="server"  TabIndex="4" MaxLength="250" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="CityTxt1">City</div>
                  <div class="CityTxtbox"><asp:TextBox ID="txtCity" runat="server" TabIndex="5" MaxLength="50" CssClass="form-control"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="CountryTxt">Country</div>
                  <div class="CountryTxtbox"><asp:TextBox ID="txtCountry" runat="server" TabIndex="6" CssClass="form-control"></asp:TextBox></div>
                  <div class="ZipTxt2">Zip</div>
                  <div class="ZipTxtDrop"><asp:TextBox ID="txtZip" runat="server" MaxLength="15"  Width="100%" TabIndex="7" CssClass="form-control"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                   <div class="PhoneTxt2">Phone</div>
                   <div class="PhoneTxtbox"><asp:TextBox ID="txtPhone" runat="server"  TabIndex="8"  MaxLength="25" CssClass="form-control"></asp:TextBox></div>
                   <div class="FAXTxt2">Fax</div>
                   <div class="FAXTxtbox1"><asp:TextBox ID="txtFax" runat="server"  TabIndex="9" MaxLength="25" CssClass="form-control"></asp:TextBox></div>
                   </div>
              <div class="FormGroupContent4">
                  <div class="EmailTxt2">e-Mail</div>
                  <div class="EmailTxtbox"><asp:TextBox id="txtEMail" runat="server" TabIndex="10" Width="100%" MaxLength="50" CssClass="form-control"></asp:TextBox></div>
                  </div>
              <div class="FormGroupContent4">
                  <div class="ReferrerTxt">Referredby</div>
                  <div class="ReferrerTxtbox"><asp:TextBox id="txtrefby" runat="server" TabIndex="11" MaxLength="50" CssClass="form-control"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                   <div class="BranchOfficeTxt">Branch Office</div>
                   <div class="BranchOfficeTxtbox"><asp:DropDownList ID="txtbranchoff" runat="server" TabIndex="12"  MaxLength="50"></asp:DropDownList></div>
                   </div>
            <%--  <div class="FormGroupContent4">
                    <span>
          <div class="g-recaptcha" data-sitekey="6LcRDR8TAAAAAENCSkw5UnVOnDtdjeWS826sLP_0"></div>
            </span>
                  
                  <div class="CaptchaBox"><recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LcP0OoSAAAAAA9mFFzLnAXqkHp2b8byzmeTyQG7" PrivateKey="6LcP0OoSAAAAAIqGn7Ptd8LW_zABLBx-MXNx44ae"/></div>   <%--PublicKey="6LcP0OoSAAAAAA9mFFzLnAXqkHp2b8byzmeTyQG7" PrivateKey="6LcP0OoSAAAAAIqGn7Ptd8LW_zABLBx-MXNx44ae"



                  </div>--%>
           
              </div>
         </div>
            </div>
    </div>

















    </form>
</body>
</html>
