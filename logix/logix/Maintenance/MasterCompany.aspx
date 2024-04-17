<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterCompany.aspx.cs" Inherits="logix.Maintenance.MasterCompany" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

  <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->
        <script type="text/javascript" src="../js/helper.js"></script>

     <script type="text/javascript">
         $(document).ready(function () {



             $('.selectpicker').selectpicker();

             "use strict";

             App.init(); // Init layout and core plugins
             Plugins.init(); // Init all plugins
             FormComponents.init(); // Init all form-specific plugins

             //$('select.styled').customSelect();

         });


    </script>












    <link href="../Styles/MasterCompany.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
      <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
     <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
     <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
      <script type="text/javascript">
          function pageLoad(sender, args) {
              $(document).ready(function () {
                  $('input:text:first').focus();
              });
            $(document).ready(function () {
                $("#<%=txt_location.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../Maintenance/MasterCompany.aspx/GetLocation",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        address: item.split('~')[2]
                                    }
                                }))
                            },
                            error: function (response) {

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=hdf_locationid.ClientID %>").val(i.item.val);
                        $("#<%=txt_location.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtPort.ClientID %>").val(i.item.address);
                        $("#<%=txt_location.ClientID %>").change();
                      
                    },
                    change: function (event, i) {
                        if (i.item) {
                        $("#<%=hdf_locationid.ClientID %>").val(i.item.val);
                        $("#<%=txtPort.ClientID %>").val(i.item.address);
                        $("#<%=txt_location.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                      
                        }
                    },
                    focus: function (event, i) {

                        $("#<%=hdf_locationid.ClientID %>").val(i.item.val);
                        $("#<%=txtPort.ClientID %>").val(i.item.address);
                        $("#<%=txt_location.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                       
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_location.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txt_location.ClientID %>").val($.trim(result));
                    
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txt_bank.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: " ../Maintenance/MasterCompany.aspx/GetBank",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=txt_bank.ClientID %>").change();
                        $("#<%=hdf_bankid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=hdf_bankid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_bank.ClientID %>").val(i.item.label);
                        $("#<%=hdf_bankid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            });


            $(document).ready(function () {
                $("#<%=txt_name.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_divisionid.ClientID %>").val(0);
                        $.ajax({
                            url: "../Maintenance/MasterCompany.aspx/GetCompany",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                //alertify.alert(response.responseText);
                            }
                        });
                    },
                    <%--select: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=txt_name.ClientID %>").change();
                        $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                        $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);
                    },
                    minLength: 1--%>

                    select: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                         $("#<%=txt_name.ClientID %>").change();
                         $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);
                     },
                    focus: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                            $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);
                        },
                    change: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                            $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);

                        },
                    close: function (event, i) {
                        $("#<%=txt_name.ClientID %>").val(i.item.label);
                            $("#<%=hdf_divisionid.ClientID %>").val(i.item.val);
                        },
                    minLength: 1
                });
            });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            //$(".date").datepicker({
            //    changeMonth: true,
            //    changeYear: true,
            //    dateFormat: 'dd-M-yy'


            //});
        }

          function ShowpImagePreview(input) {
              if (input.files && input.files[0]) {
                  var reader = new FileReader();
                  reader.onload = function (e) {
                      //  $('#img_flag').attr('src', e.target.result);
                      $('#<%= Img_Emp.ClientID %>').attr('src', e.target.result);
                     }
                     reader.readAsDataURL(input.files[0]);
                     }
          }
          function ShowpImagePreview(input) {
              if (input.files && input.files[0]) {
                  var reader = new FileReader();
                  reader.onload = function (e) {
                      //  $('#img_flag').attr('src', e.target.result);
                      $('#<%= Image1.ClientID %>').attr('src', e.target.result);
                   }
                   reader.readAsDataURL(input.files[0]);
               }
           }

      </script>
          <script type="text/javascript" >
              function openfileDialog() {
                  document.getElementById('FileUpload1.ClientID ').click();
              }
        </script>

    <script type  ="text/javascript" >
        function onChangeTest() {
            __doPostBack("txt_name", "TextChanged");
        }


        function getConfirmationValue() {
            var sector = document.getElementById('<%=txt_name.ClientID %>').value;

            if (sector == "") {
                alertify.alert("Company Name can't be Empty...");
                return false;
            }
            else {
                if (confirm('Are you sure you want to delete the details?')) {
                    $('#<%=hfWasConfirmed.ClientID%>').val('true')
                }
                else {
                    $('#<%=hfWasConfirmed.ClientID%>').val('false')
                }
            }
            return true;
        }

       </script>      

 <style type ="text/css" >

 .fileUpload {
    position: relative;
    overflow: hidden;
   display: block;
width: 34%;
/*height:21px;*/
border :1px solid #999997;
background-color:blue;
	background: #D0D0C9;
    background: -moz-linear-gradient(top,  #D0D0C9 0%, #D0D0C9 44%, #D0D0C9 100%);
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#D0D0C9), color-stop(44%,#D0D0C9), color-stop(100%,#D0D0C9));
	background: -webkit-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -o-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -ms-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
  
    font-size:small;
	display: inline;
	/*position: absolute;*/
	/*overflow: hidden;*/
	cursor: pointer;
-webkit-appearance:push-button;
margin-top:-3%;
/*margin-top:3%;*/
margin-left:0%;
 margin-bottom:0%;
 /*margin-top :1%;*/
 text-align:center;

}
.fileUpload input.upload {
    position: absolute;
    top: 0px;
    margin: 0px 0 0 0;
    padding: 0;
    font-size: 20px;
    cursor: pointer;
    opacity: 0;
    filter: alpha(opacity=4);
         left: 0px;
         width: 304px;
     }



/*LOG DETAILS CSS*/


        .btn-logic1 {
            z-index: 2;
            border-radius: 0px;
        }

            .btn-logic1 a {
                border: medium none;
                line-height: normal;
                color: #4e4e4c !important;
                padding: 5px 0px 10px 28px;
                background: url(../Theme/assets/img/buttonIcon/log_ic1.png) no-repeat left 0px;
                margin: 0px 0px 2px 10px;
                font-size: 11px;
            }


        .modalPopupssLog {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            width: 48.5%;
            height: 232px;
            margin-left: 1%;
            margin-top: -0.9%;
            overflow: auto;
        }

        .GridpnlLog {
            width: 100%;
        }

        .DivSecPanelLog {
            width: 20px;
            Height: 20px;
            border: 0px solid white;
            margin-right: 0%;
            margin-top: 0.5%;
            border-radius: 90px 90px 90px 90px;
            z-index: 999999;
            position: relative;
            float: right;
        }


            .DivSecPanelLog img {
                float: right;
                width: 16px !important;
                height: 16px !important;
            }


        .GridNew {
            font-family: sans-serif;
            font-size: 10pt;
            color: Black;
            margin-top: 0px;
            width: 100%;
        }

            .GridNew th {
                background-color: #dbdbdb !important;
                border-right: 1px solid #51789d;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                font-size: 11px;
                color: #4e4c4c !important;
            }

            .GridNew td {
                border-right: 1px solid #dddddd;
                font-size: 11px;
                text-align: left;
                font-family: tahoma;
                padding: 2px 5px 2px 5px;
                margin: 0px;
                color: #4e4c4c;
                border-bottom: 1px solid #dddddd;
            }

             .LogHeadLbl {
             width:65%;
             float:left;
             margin:2px 0px 3px 4px;

         }

         .LogHeadLbl label
         {
             color:#af2b1a;
             font-weight:bold;
             font-size:12px;
         }



         .LogHeadJob {
             width:auto;
             float:left;
             margin:0px 0.5% 0px 0px;
         }

         .LogHeadJobInput label {
             font-size:12px;
             
            
         }


           .LogHeadJobInput {
             width:auto;
             white-space:nowrap;
             float:left;
             margin:1px 0.5% 0px 0px;
         }

             .LogHeadJobInput span {
                 color:#1a65af;
                 font-size:12px;
                 margin:4px 0px 0px 0px;
             }




             .LogHeadJobInput label {
                 font-size:12px;
                 font-family:sans-serif;
                 color:#4e4e4c;
             }

               logix_CPH_PanelLog
             {
                 top:155px!important;
             }

.BankLeft{
    margin-right:0.5% !important;
}
.Bankimg {
    width: 65%;
    float: left;
    height: 145px;
    margin: 10px 0px 0px 0px;
    background-color: #fff;
}
span#logix_CPH_lbl_bankdetails {
    color: #4d4d4d;
    font-size: 12px;
    position: relative;
    top: 5px;
    font-weight: bold !important;
}
.FileUpload3 {
    margin-top: 70px !important;
}
.City2 {
    width: 24%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Country3 {
    width: 34.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Fax2 {
        width: 33%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.Email2 {
    width: 100%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.DeciMals {
    width: 10.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.FYFrom {
    width: 17%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.FYTo {
    width: 17%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.DateDrop {
    width: 32%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.widget.box{
    position: relative;
    top: -8px;
}
.PAN1 {
    width: 32.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ST1 {
       width: 32%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.TAN1 {
        width: 34.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.Units2 {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.BuildingName1 {
   width: 87.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.Door1 {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.Street1 {
    width: 25.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.Street1 {
    width: 87.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.Locationtxt1 {
      width: 52.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.District2 {
    width: 33%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.State2 {
       width: 42%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.Phone1 {
       width: 31.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.PF1 {
    width: 32.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.ESI1 {
    width: 32%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
.CARN1 {
    width: 34.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.STD1 {
    width: 12%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 div#logix_CPH_ddl_df_chzn {
    width: 100% !important;
}
 .divleft{
     width:43.5%;
     float:left;
     margin:0px 0.5% 0px 0px;
 }
 .divright{
     width:48%;
     float:left;
     margin:0px 0.5% 0px 0px;
 }
 .BankLeft {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .BankName {
    width: 47.5%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
 .AccountDrop {
    width: 52%;
    float: left;
    margin: 0px 0px 0px 0px;
}
 .BankRight.boxmodal {
    width: 35% !important;
}
 div#UpdatePanel1 {
    /* height: 100vh; */
    height: 88vh;
    overflow-x: hidden;
    overflow-y: auto;
}
 .widget.box .widget-content {
    top: 0px !important;
    padding-top:15px !important;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


      
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
         <div>
                 <div style="float: left; margin: 0px 0.5% 0px 0px;"> <h4 class="hide"><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="Company"></asp:Label> </h4>
                      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Systems</a> </li>
              <li class="current"><a href="#" title="">Company</a> </li>
            </ul>
      </div>
                 </div>
         <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
             </div>
                </div>
          <div class="widget-content">



              <div class="FormGroupContent4">
                  <div class="divleft">
                      <div class="FormGroupContent4 boxmodal">
                <div class="FormGroupContent4" style="width: 100%;" >

                 <asp:TextBox ID="txt_name" runat="server"  CssClass="form-control" ToolTip="Name" PlaceHolder="Name" AutoPostBack="true" TabIndex="1" MaxLength="50" ontextchanged="txt_name_TextChanged" ></asp:TextBox> 
                    </div>

            
                    
                
                 
                 </div>




                <div class="FormGroupContent4 boxmodal">
                    <div class="FormGroupContent4">
                    <div class="Units2"><asp:TextBox ID="txt_unit" runat="server"  TabIndex="2" ToolTip="Unit Number" PlaceHolder="Unit #" CssClass="form-control" onkeyup="CheckTextLength(this,25);" ></asp:TextBox></div>
                    <div class="BuildingName1"><asp:TextBox ID="txt_bname" runat="server" CssClass="form-control"   ToolTip="Building Name" PlaceHolder="Building Name" TabIndex="3" onkeyup="CheckTextLength(this,50);"></asp:TextBox></div>

                    </div>
                <div class="FormGroupContent4">
                    <div class="Door1"><asp:TextBox ID="txt_door" runat="server"  CssClass="form-control" ToolTip="Door Number" PlaceHolder="Door #" TabIndex="4" onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                    <div class="Street1"><asp:TextBox ID="txt_street" runat="server" TabIndex="5"  ToolTip="Street" PlaceHolder="Street" CssClass="form-control" Width="100%"   onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                  
               
                    
                      </div>
                    
               <div class="FormGroupContent4">

                   <div class="City2"><asp:TextBox ID="txtPort" runat="server" CssClass="form-control" ToolTip="City" PlaceHolder="City" TabIndex="9" Enabled="False"></asp:TextBox></div>
                     <div class="District2"><asp:TextBox ID="txtdistrict" runat="server" CssClass="form-control" ToolTip="District" PlaceHolder="District" TabIndex="8" Enabled="False"></asp:TextBox></div>
                    <div class="State2"><asp:TextBox ID="txt_state" runat="server" ToolTip="State" PlaceHolder="State" TabIndex="10" CssClass="form-control"  Enabled="False"></asp:TextBox></div>



                    </div>
                    <div class="FormGroupContent4">
                   <div class="Country3"><asp:TextBox ID="txt_country" runat="server" ToolTip="Country"  PlaceHolder="Country" TabIndex="11" CssClass="form-control" Enabled="False" OnTextChanged="txt_country_TextChanged"></asp:TextBox></div>
                   <div class="Units2"><asp:TextBox ID="txt_pincode" runat="server" ToolTip="Pincode"  PlaceHolder="Pincode" TabIndex="6" CssClass="form-control"   Enabled="False"></asp:TextBox></div>
                   <div class="Locationtxt1"><asp:TextBox ID="txt_location" runat="server" AutoPostBack="true" CssClass="form-control"  ToolTip="Location" PlaceHolder="Location" TabIndex="7" ontextchanged="txt_location_TextChanged" onkeyup="CheckTextLength(this,60);" ></asp:TextBox></div>

                    </div>
                    </div>
                <div class="FormGroupContent4 boxmodal">

               <div class="FormGroupContent4">
                   <div class="STD1" style="width:17%;" ><asp:TextBox ID="txt_pisd" runat="server" ToolTip="PHONE ISD"  PlaceHolder="ISD" TabIndex="12"
            CssClass="form-control"  Enabled="False" OnTextChanged="txt_pisd_TextChanged"></asp:TextBox></div>
                   <div class="ISD1" style="width:17%;" ><asp:TextBox ID="txt_pstd" runat="server" ToolTip="PHONE STD" PlaceHolder="STD" TabIndex="13"
            CssClass="form-control" Enabled="False"></asp:TextBox></div>
                   <div class="Phone1"><asp:TextBox ID="txt_phone" runat="server" CssClass="form-control" Width="100%"    ToolTip="PHONE NUMBER" PlaceHolder="Phone #" TabIndex="14" MaxLength="10"   onkeypress="return isNumberKey (event)"></asp:TextBox></div>
                   <div class="Fax2"><asp:TextBox ID="txt_fax" runat="server" TabIndex="15" ToolTip="FAX" PlaceHolder="FAX" CssClass="form-control"   onkeyup="CheckTextLength(this,15);" onkeypress="return isNumberKey (event)"></asp:TextBox></div>
                   </div>
                    <div class="FormGroupContent4">
                   <div class="Email2"><asp:TextBox ID="txt_email" TabIndex="16" runat="server"  ToolTip="EMAIL" PlaceHolder="EMAIL" CssClass="form-control" Width="100%"   onblur="javascript:ValidateEmail(this)"></asp:TextBox></div>

                    </div>
                <div class="FormGroupContent4">
                    <div class="PAN1"><asp:TextBox ID="txt_pan" runat="server" TabIndex="17"  ToolTip="PAN NUMBER" PlaceHolder="PAN #" CssClass="form-control"  onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                    <div class="ST1"><asp:TextBox ID="txt_st" runat="server" CssClass="form-control" Width="100%"    ToolTip="ServiceTax Number" PlaceHolder="GST #" TabIndex="18" onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                    <div class="TAN1"><asp:TextBox ID="txt_tan" runat="server" CssClass="form-control" Width="100%"    ToolTip="Tan #" PlaceHolder="Tan #" TabIndex="19" onkeyup="CheckTextLength(this,25);"></asp:TextBox> </div>
                   
                    </div>
                    <div class="FormGroupContent4">
                         <div class="PF1"><asp:TextBox ID="txt_pf" runat="server" CssClass="form-control" Width="100%"  ToolTip="PF #" PlaceHolder="PF #" TabIndex="20" onkeyup="CheckTextLength(this,20);"></asp:TextBox></div>
                    <div class="ESI1"><asp:TextBox ID="txt_esi" runat="server" CssClass="form-control" Width="100%"  ToolTip="ESI #" PlaceHolder="ESI #" TabIndex="21" onkeyup="CheckTextLength(this,20);"></asp:TextBox></div>
                    <div class="CARN1"><asp:TextBox ID="txt_carn" runat="server" CssClass="form-control" Width="100%" ToolTip="CARN #" PlaceHolder="CARN #" TabIndex="22" onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                    </div>
                    <div class="FormGroupContent4" style="width:100%;" >
                        <div class="bordertopNew"></div>
                    </div>
                    </div>
                <div class="FormGroupContent4 boxmodal">
                    <div class="STD1"><asp:TextBox ID="txt_currshort" runat="server"  ToolTip="Currency" PlaceHolder="Curr"
            CssClass="form-control" Width="100%"  Enabled="False" TabIndex="23"  ></asp:TextBox></div>
                     <div class="ISD1" style="width:9%;" ><asp:TextBox ID="txt_paiseshort" runat="server"  ToolTip="Paise" PlaceHolder="Paise"
            CssClass="form-control" Width="100%"  Enabled="False" TabIndex="24" ></asp:TextBox></div>
                    <div class="DeciMals"><asp:TextBox ID="txt_decimals" TabIndex="25" runat="server"  ToolTip="Decimals" PlaceHolder="Decimals" CssClass="form-control" Width="100%"  onkeypress="return isNumberKey (event)"></asp:TextBox></div>
                    <div class="DateDrop"><asp:DropDownList ID="ddl_df" runat="server" TabIndex="26" BorderColor="#999997" ToolTip="Date Format" PlaceHolder="Date Format" Width="100%"  CssClass ="chzn-select"  >
    <asp:ListItem Value="0" Text="Date Format"></asp:ListItem>
        <asp:ListItem  Text="M/d/yyyy"></asp:ListItem>
        <asp:ListItem Text="M/d/yy"></asp:ListItem>
        <asp:ListItem Text="MM/dd/yy"></asp:ListItem>
        <asp:ListItem Text="MM/dd/yyyy"></asp:ListItem>
        <asp:ListItem Text="yy/MM/dd"></asp:ListItem>
        <asp:ListItem Text="yyyy-MM-dd"></asp:ListItem>
        <asp:ListItem Text="dd-MMM-yy"></asp:ListItem>
    </asp:DropDownList></div>
                    <div class="FYFrom"><asp:TextBox ID="txt_fyfrom" runat="server"   ToolTip="FINANCE YEAR FROM"  CssClass="form-control date"  Width="100%" PlaceHolder="FY From" TabIndex="27" ></asp:TextBox></div>
             <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_fyfrom"></asp:CalendarExtender>
                    <div class="FYTo"><asp:TextBox ID="txt_fyto" runat="server"  ToolTip="FINANCE YEAR TO" PlaceHolder="To"  CssClass="form-control date" Width="100%" TabIndex="28" ></asp:TextBox></div>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_fyto"></asp:CalendarExtender>                   

              </div>
             

                      <div class="FormGroupContent4">
                          <div class="bordertopNew"></div>
                      </div>
               <div class="FormGroupContent4">
                   <div class="BankLeft boxmodal">
                        <div class="FormGroupContent4">
                  <div class="BankDetails"><asp:Label ID="lbl_bankdetails" runat="server" Text="Bank details"></asp:Label></div>
              </div>
                       <div class="FormGroupContent4">
                       <div class="BankName"><asp:TextBox ID="txt_bank" runat="server" TabIndex="29"  ToolTip="Bank" PlaceHolder="Bank"
                    CssClass="form-control" Width="100%"   AutoPostBack="true" onkeyup="CheckTextLength(this,50);" 
                    ontextchanged="txt_bank_TextChanged" ></asp:TextBox></div>
                       <div class="AccountDrop"><asp:DropDownList ID="ddl_actype" runat="server"  Width="100%" TabIndex="30" ToolTip="Account Type" Data-PlaceHolder="Account Type"  CssClass ="chzn-select"  >
    <asp:ListItem Text="" Value="0"></asp:ListItem>
        <asp:ListItem  Text="SAVINGS"></asp:ListItem> 
          <asp:ListItem  Text="CURRENT"></asp:ListItem>      
    </asp:DropDownList></div>
                       </div>
                       <div class="FormGroupContent4">
                       <div class="BankName"><asp:TextBox ID="txt_address" runat="server" CssClass="form-control" Width="100%"    ToolTip="Address" PlaceHolder="Address" TabIndex="31"   onkeyup="CheckTextLength(this,100);" ></asp:TextBox></div>
                       <div class="AccountDrop"><asp:TextBox ID="txtifsccode" runat="server" CssClass="form-control" Width="100%"   ToolTip="IFSC Code" PlaceHolder="IFSC Code" TabIndex="32" onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                           </div>
                        <div class="FormGroupContent4">
                        <div class="BankName"><asp:TextBox ID="txt_ac" runat="server" CssClass="form-control" Width="100%"   TabIndex="33" ToolTip="ACCOUNT NUMBER" PlaceHolder="AC #" onkeyup="CheckTextLength(this,25);" OnTextChanged="txt_ac_TextChanged"></asp:TextBox></div>
                        <div class="AccountDrop"><asp:TextBox ID="txt_scode" runat="server"   CssClass="form-cotnrol" Width="100%"    ToolTip="Swift Code" PlaceHolder="Swift Code" TabIndex="34" onkeyup="CheckTextLength(this,25);"></asp:TextBox></div>
                  </div>
                   </div>
                  
                   </div>

              <div class="FormGroupContent4">
                  <div class="CreateBranch hide">
                       <asp:LinkButton ID="lbl_lnkrate" CssClass="anc ico-find-sm" runat="server"  ForeColor="Red" style="text-decoration:none;" OnClick="lbl_lnkrate_Click"></asp:LinkButton>
                  </div>
                  <div class="right_btn">
                      <div class="btn ico-save" id="btn_save1" runat="server"> 
                          <asp:Button ID="btn_save" runat="server"  Text="Save" ToolTip="Save"  
                   onclick="btn_save_Click" TabIndex="36" />

                      </div>
                      <div class="btn ico-view">
                          <asp:Button ID="btn_view" runat="server" Text="View" ToolTip="View"  TabIndex="37" OnClick="btn_view_Click"   /> 

                      </div>
                      <div class="btn ico-delete" id="btn_delete_id" runat="server" > 
                          <asp:Button ID="btn_delete" runat="server" Text="Delete" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this Company?');" 
                   onclick="btn_delete_Click" TabIndex="38" />

                      </div>
                      <div class="btn ico-clear" id="btn_cancel1" runat="server">
                          <asp:Button ID="btn_cancel" runat="server" Text="Clear" ToolTip="Clear" onclick="btn_cancel_Click" TabIndex="39" />

                      </div>

  <div class="btn ico-save" id="Div1" runat="server"> 
      <asp:Button ID="btn_imgupload" runat="server"    ToolTip="Logo"  
                   onclick="btn_imgupload_Click" TabIndex="36" />

  </div>
                        <div class="btn ico-save" id="Div2" runat="server"> 
      <asp:Button ID="btnblimage" runat="server"   ToolTip="blimage"  
                   onclick="btnblimage_Click" TabIndex="36" />

  </div>


                        
                  </div>
              </div>
                  </div>
                  <div class="divright">
                        <div class="BankRight boxmodal">
                       <div class="Bankimg"><asp:Image ID="Img_Emp" runat="server"  ToolTip="IMAGE" Height="100%" Width="99%"  placeholder="IMAGE"/></div>
                       <div class="FileUpload3 fileUpload">
                            <span style=" margin-top :0%; display :block; background-color:#5ba701; font-size:12px; color:black; width:100%; padding:3px 0px 0px 0px; height:25px; border:1px solid #999997;">UPLOAD</span>
                           <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="35" class="upload" onchange="ShowpImagePreview(this);" />
                      
 
                           
                            </div>




                   </div>
                  </div>
                   <div class="divright">
       <div class="BankRight boxmodal">
      <div class="Bankimg"><asp:Image ID="Image1" runat="server"  ToolTip="IMAGE" Height="100%" Width="99%"  placeholder="IMAGE"/></div>
      <div class="FileUpload3 fileUpload">
           <span style=" margin-top :0%; display :block; background-color:#5ba701; font-size:12px; color:black; width:100%; padding:3px 0px 0px 0px; height:25px; border:1px solid #999997;">UPLOAD</span>
          <asp:FileUpload ID="FileUpload2" runat="server" TabIndex="35" class="upload" onchange="ShowpImagePreview(this);" />
     
 
          
           </div>




  </div>
 </div>
                 
                  

              </div>

             
         </div>





            </div>
           </div>

                  </div>
    <div id="PanelLog1" runat="server">
                    <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                        <div class="divRoated">
                            <div class="LogHeadLbl">
                                <div class="LogHeadJob">
                                    <label id="lbl" runat="server">Company Name :</label>

                                </div>
                                <div class="LogHeadJobInput">

                                    <asp:Label ID="JobInput" runat="server"></asp:Label>

                                </div>

                            </div>
                            <div class="DivSecPanel">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                            </div>

                            <asp:Panel ID="Panel2" runat="server" CssClass="Gridpnl">

                                <asp:GridView ID="GridViewlog" CssClass="Grid FixedHeader" runat="server" AutoGenerateColumns="true"
                                    ForeColor="Black" EmptyDataText="No Record Found" PageSize="20"
                                    BackColor="White">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <HeaderStyle CssClass="myGridHeader" />
                                    <AlternatingRowStyle CssClass="GrdAltRow" />
                                    <PagerStyle CssClass="GridviewScrollPager" />
                                </asp:GridView>

                            </asp:Panel>
                            <div class="Break"></div>
                        </div>


                    </asp:Panel>
                </div>
     <asp:Label ID="Label4" runat="server"></asp:Label>

    <asp:modalpopupextender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:modalpopupextender>




<asp:HiddenField ID="hdf_portid" runat="server" />
<asp:HiddenField ID="hdf_countryid" runat="server" />
<asp:HiddenField ID="hdf_stateid" runat="server" />
<asp:HiddenField ID="hdf_locationid" runat="server" />
<asp:HiddenField ID="hdf_bankid" runat="server" />
<asp:HiddenField ID="hdf_divisionid" runat="server" />
<asp:HiddenField ID="hdf_image" runat="server" />
<asp:HiddenField ID="hfWasConfirmed" runat="server" />

</asp:Content>
