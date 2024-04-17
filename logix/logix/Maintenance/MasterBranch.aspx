<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterBranch.aspx.cs" Inherits="logix.Maintenance.MasterBranch" %>
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

   <%-- <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->


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












    <link href="../Styles/MasterBranch.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css"/>
     <link href="../Styles/chosen.css" rel="stylesheet" />
     <script src="../Scripts/chosen.jquery.js" type="text/javascript" ></script>
 <style type ="text/css" >
     
     .fileUpload {
    position: relative;
    overflow: hidden;
   display: block;
width: 97%;
/*height:21px;*/
height:20px;
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
margin-top:0.1%;
/*margin-top:3%;*/
margin-left:1%;
 margin-bottom:0%;
 /*margin-top :1%;*/
 text-align:center;

}
.fileUpload input.upload {
    position: absolute;
    top: 0px;
    margin: 0px 0 0 0;
    padding: 0;
    font-size:13px;
    cursor: pointer;
    opacity: 0;
    filter: alpha(opacity=4);
         left: 0px;
         width: 304px;
     }
.logoimg
{
    height:73px;
    width:102%;
    margin-left :1%;
    color:aliceblue;
    /*float:right;*/
    left:10%;
    /*margin-top:-11.5%;*/
    /*margin-top:1%;*/
    margin-top:0%;
    margin-right:1%;
    border:1px solid #b1b1b1;
        
}
.ShortRight {
    float: left;
    width: 30.9%;
    margin: 0px 0px 0px 0px;
}
.FileUpload4 {
    width: 102.5%;
    float: left;
    margin: 2px 0px 0px 1px !important;
}

     #logix_CPH_droptype_region_chzn {
         width:100%!important;
     }

     div.file_upload {
	/*width: 10.5%;*/
    width:110px;
	height: 18px;
	/*background: #D0D0C9;*/
    background-color:aliceblue;
	/*background: -moz-linear-gradient(top,  #D0D0C9 0%, #D0D0C9 44%, #D0D0C9 100%);
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#D0D0C9), color-stop(44%,#D0D0C9), color-stop(100%,#D0D0C9));
	background: -webkit-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -o-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: -ms-linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);
	background: linear-gradient(top,  #D0D0C9 0%,#D0D0C9 44%,#D0D0C9 100%);*/
	filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#D0D0C9', endColorstr='#D0D0C9',GradientType=0 ); 
    font-size:small;
	display: inline;
	position: absolute;
	overflow: hidden;
	cursor: pointer;
	margin-top:0.1%;
    /*margin-left:0.9%;*/
    /*margin-bottom:3%;*/

	/*-webkit-border-top-right-radius: 5px;
	-webkit-border-bottom-right-radius: 5px;
	-moz-border-radius-topright: 5px;
	-moz-border-radius-bottomright: 5px;
	border-top-right-radius: 5px;
	border-bottom-right-radius: 5px;*/
	
	font-weight: bold;
	/*color: Black;*/
	text-align: center;
	padding-top: 3px;
	padding-bottom:0.2%;
}
div.file_upload:before {
	content: 'UPLOAD';
	color:Black;
    margin-bottom:3%;
	position: absolute;
	left: 0; right: 0;
	text-align: center;
	
	cursor: pointer;
}

div.file_upload input {
	position: relative;
	height: 30px;
	width: 100%;
	display: inline;
	cursor: pointer;
	opacity: 0;
         top: 0px;
         left: 0px;
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

.chzn-drop {
    height: 166px !important;
    overflow: auto;
}
.BaseTxt1 {
    width: 31%;
    float: left;
    margin: 0px 1% 0px 0px;
}
.BaseTxt2 {
    width: 35.9%;
    float: left;
    margin: 0px 0px 0px 0px;
}
.FormGroupContent4 textarea {
    height: 38px !important;
}
.FormGroupContent4 .BankAddress textarea {
    height: 33px !important;
}
.FormGroupContent4 .BankAddress1 textarea {
    height: 33px !important;
}
 </style>



<script type="text/javascript">
    function pageLoad(sender, args) {
        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        $(document).ready(function () {
            $("#<%=txt_location.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MasterBranch.aspx/GetLocation",
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('~')[0],
                                    val: item.split('~')[1],                                  
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
                    $("#<%=txt_location.ClientID %>").val(i.item.label);
                    $("#<%=txt_location.ClientID %>").change();
                    $("#<%=hdf_Locationid.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txt_location.ClientID %>").val(i.item.label);
                    $("#<%=hdf_Locationid.ClientID %>").val(i.item.val);
                },
                close: function (event, i) {
                    $("#<%=txt_location.ClientID %>").val(i.item.label);
                    $("#<%=hdf_Locationid.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        });


        $(document).ready(function () {
            $("#<%=txt_BrMngr.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MasterBranch.aspx/GetBranchManager",
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
                    $("#<%=txt_BrMngr.ClientID %>").val(i.item.label);
                    $("#<%=txt_BrMngr.ClientID %>").change();
                    $("#<%=hdn_bmid.ClientID %>").val(i.item.val);
                },
                focus: function (event, i) {
                    $("#<%=txt_BrMngr.ClientID %>").val(i.item.label);
                    $("#<%=hdn_bmid.ClientID %>").val(i.item.val);
                },
                close: function (event, i) {
                    $("#<%=txt_BrMngr.ClientID %>").val(i.item.label);
                    $("#<%=hdn_bmid.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        });

        $(document).ready(function () {
            $("#<%=txt_regionMgr.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MasterBranch.aspx/GetRegionalManager",
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
                    if (i.item) {
                        $("#<%=txt_regionMgr.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_rmid.ClientID %>").val(i.item.val);
                    }
                 },
                focus: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_regionMgr.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_rmid.ClientID %>").val(i.item.val);
                    }
                },
                change: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_regionMgr.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_rmid.ClientID %>").val(i.item.val);                        
                    }
                },
                close: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_regionMgr.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_rmid.ClientID %>").val(i.item.val);                       
                    }
                },
                minLength: 1                
            });
        });


        $(document).ready(function () {
            $("#<%=txt_personto.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "MasterBranch.aspx/GetPTC",
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
                    if (i.item) {
                        $("#<%=txt_personto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_PTC.ClientID %>").val(i.item.val);
                    }
                },
                focus: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_personto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_PTC.ClientID %>").val(i.item.val);
                    }
                },
                change: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_personto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_PTC.ClientID %>").val(i.item.val);                        
                    }
                },
                close: function (event, i) {
                    if (i.item) {
                        $("#<%=txt_personto.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=hdn_PTC.ClientID %>").val(i.item.val);                       
                    }
                },
                minLength: 1
            });
        });
    }

//    -------------------------------------------------------------------
  


         </script>
    
   <script type="text/javascript">
      function ShowpImagePreview(input) {
        if (input.files && input.files[0]) {
          var reader = new FileReader();
          reader.onload = function (e) {
  //  $('#img_flag').attr('src', e.target.result);
              $('#<%= ImgLogo.ClientID %>').attr('src', e.target.result);
             }
         reader.readAsDataURL(input.files[0]);
        }
 }
    </script>

<%--       <script type="text/javascript">
           function validateEmail(emailField) {
               var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

               if (reg.test(emailField.value) == false) {
                   alertify.alert('Enter Correct Email Format');
                   return false;
               }

               return true;

           }
    </script>--%>
     

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <div> <asp:HiddenField ID="hdn_id" runat="server" /></div>


      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
              <li><a href="#" title="">Maintenance</a> </li>
              <li class="current"><a href="#" title="">Branch</a> </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <div style="float: left; margin: 0px 0.5% 0px 0px;">  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_Header" runat="server" Text="Branch"></asp:Label></h4></div>
            <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                </div>
          <div class="widget-content">
             
                 <div class="BranchLeft">
                     <div class="FormGroupContent4">
                         <div class="Branchtxt2"><asp:TextBox ID="txt_Branch" runat="server"  ToolTip="BRANCH" placeHolder="BRANCH"
                Cssclass="form-control" AutoPostBack="True" Visible="False" ontextchanged="txt_Branch_TextChanged" ></asp:TextBox></div>
                         <div class="BranchDrop6">  <asp:DropDownList ID="branch_droptype" runat="server"  CssClass="chzn-select" width="100%"  ToolTip="Branch Name" Data-placeHolder="Branch Name"
                 onselectedindexchanged="branch_droptype_SelectedIndexChanged" 
                 AutoPostBack="True" TabIndex="1">
            <asp:ListItem Text="" Value="0"></asp:ListItem>
        </asp:DropDownList></div>
                         </div>
                      <div class="FormGroupContent4">
                          <div class="ThumbLeft">
                               <div class="FormGroupContent4">
                                   <asp:TextBox ID="txt_location" runat="server"   ToolTip="LOCATION" placeHolder="LOCATION"
                Cssclass="form-control" AutoPostBack="True" 
                ontextchanged="txt_location_TextChanged" TabIndex="2"></asp:TextBox>
                                   </div>
                               <div class="FormGroupContent4">
                                   <div class="PersonLeft"><asp:TextBox ID="txt_personto" runat="server"  ToolTip="Person To Contact" placeHolder="Person To Contact"
               CssClass="form-control" AutoPostBack="True" 
               ontextchanged="txt_personto_TextChanged" TabIndex="3"></asp:TextBox></div>
                                   <div class="ShortRight"><asp:TextBox ID="txt_shortname" runat="server"  ToolTip="ShortName" placeHolder="ShortName"
               CssClass="form-control" TabIndex="4"></asp:TextBox></div>
                                   </div>
                                <div class="FormGroupContent4">
                                    <asp:TextBox ID="txt_address" runat="server"  ToolTip="ADDRESS" Rows="3" placeHolder="ADDRESS" style="resize:none;"
               CssClass="form-control" TextMode="MultiLine"  TabIndex="5"></asp:TextBox>
                                    </div>
                              <div class="FormGroupContent4">
                                  <div class="PhoneTxt1"></div>
                                  <div class="Faxtxt1"></div>
                                  </div>
                          </div>
                          <div class="ThumbRight"><div class="FormGroupContent4">   <%--src="../images/branch_img.jpg"--%>
                         <div class="logoimg"><asp:Image ID="ImgLogo" runat="server"  ToolTip="IMAGE"  Height="75px" Width="100%" placeholder="IMAGE"  />      </div> 
<%--                          <div class="fileUpload">
   <%-- <span style =" margin-top :0.5%;margin-left:0%; display :block; background-color:lightblue; width:110px;height:18px; color:black;border:2px solid #999997;">Upload</span>
      <asp:FileUpload ID="FileUpd_logo" runat="server" TabIndex="35" class="upload" onchange="ShowpImagePreview(this);" /></div>--%>
                              <div class="FileUpload4 fileUpload">
                            <span style=" margin-top :0%; display :block; color:#fff!important; background-color:#28609b; color:black; width:163px; font-size:12px; padding:0px 0px 0px 0px; height:25px;">UPLOAD</span>
                           <asp:FileUpload ID="FileUpd_logo" runat="server" TabIndex="35" class="upload" onchange="ShowpImagePreview(this);" />
                       </div>
                     </div></div>
                          </div>
                        <div class="FormGroupContent4">
                  <div class="PhoneTxt1"><asp:TextBox ID="txt_phone" runat="server" CssClass="form-control"  ToolTip="Phone" placeHolder="Phone" 
               Width="100%" onkeypress="return isNumberKey(event,'Phone');" TabIndex="7"></asp:TextBox></div>
                  <div class="Faxtxt1"> <asp:TextBox ID="txt_fax" runat="server" CssClass="form-control"  ToolTip="Fax" placeHolder="Fax"
               Width="100%" TabIndex="8"></asp:TextBox></div>
              </div> 
              <div class="FormGroupContent4">
                   <div class="PhoneTxt1"><asp:TextBox ID="txt_email" runat="server" CssClass="form-control"  ToolTip="Email" placeHolder="Email"
               Width="100%"  TabIndex="9" AutoPostBack="True" ontextchanged="txt_email_TextChanged"></asp:TextBox></div>
                  <div class="Faxtxt1"><asp:TextBox ID="txt_city" runat="server" CssClass="form-control"  ToolTip="City" placeHolder="City"
               Width="100%" TabIndex="10"></asp:TextBox></div>

                  </div>
              <div class="FormGroupContent4">
                  <div class="PhoneTxt1"> <asp:TextBox ID="txt_PanNo" runat="server" CssClass="form-control"  ToolTip="PermenantAccount#" placeHolder="PermenantAccount#"
               Width="100%" TabIndex="11" AutoPostBack="True"></asp:TextBox></div>
                  <div class="Faxtxt1"><asp:TextBox ID="txt_service" runat="server" CssClass="form-control"  ToolTip="Service Tax#" placeHolder="Service Tax#"
               Width="100%" TabIndex="12" AutoPostBack="True"></asp:TextBox> </div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="PhoneTxt1"> <asp:TextBox ID="txt_carr" runat="server" CssClass="form-control"  ToolTip="CARR NO" placeHolder="CARR NO" 
               Width="100%" TabIndex="13"></asp:TextBox></div>
                  <div class="Faxtxt1"><asp:TextBox ID="txt_cinno" runat="server" CssClass="form-control"  ToolTip="CIN NO" placeHolder="CIN NO"
               Width="100%" TabIndex="14"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="PhoneTxt1"> <asp:TextBox ID="txt_BrMngr" runat="server" CssClass="form-control"  ToolTip="Branch Manager" placeHolder="Branch Manager"
               Width="100%" AutoPostBack="True" ontextchanged="txt_BrMngr_TextChanged" TabIndex="15"></asp:TextBox></div>
                  <div class="Faxtxt1"><asp:TextBox ID="txt_EDIUser" runat="server" CssClass="form-control"  ToolTip="Custom EDI User ID" placeHolder="Custom EDI User ID"
               Width="100%" TabIndex="16"></asp:TextBox> </div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="PhoneTxt1">  <asp:DropDownList ID="droptype_region" runat="server"  ToolTip="Region Name" Data-placeHolder="Region Name"
               CssClass="chzn-select" width="100%" onselectedindexchanged="droptype_region_SelectedIndexChanged" AutoPostBack="True" TabIndex="17">
               <asp:ListItem Text="" Value="0"></asp:ListItem>
           </asp:DropDownList></div>
                  <div class="Faxtxt1"> <asp:TextBox ID="txt_regionMgr" runat="server" CssClass="form-control"  AutoPostBack="True"  ToolTip="Regional Manager" placeHolder="Regional Manager"
               ontextchanged="txt_regionMgr_TextChanged" TabIndex="18"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                  <div class="PhoneTxt1"><asp:TextBox ID="txt_Mrcode" runat="server" CssClass="form-control"  ToolTip="M+R Code" placeHolder="M+R Code"
               Width="100%" TabIndex="19"></asp:TextBox></div>
                  <div class="Faxtxt1"><asp:TextBox ID="txt_transbond" runat="server"  ToolTip="Trans Bond#" placeHolder="Trans Bond#"
               CssClass="form-control" Width="100%" TabIndex="20"></asp:TextBox> </div>
                  </div>
                 </div>
                 <div class="BranchRight">
                     <div class="FormGroupContent4">
                     <div class="BankLbl"><asp:Label ID="Label1" runat="server" Text="Bank Details for OSDN/OSCN"></asp:Label></div>
                         </div>
                       <div class="FormGroupContent4">
                           <asp:TextBox ID="txt_favrg_first" runat="server"  ToolTip="Favouring" placeHolder="Favouring"
                 CssClass="form-control" TabIndex="21"></asp:TextBox>
                           </div>
                     <div class="FormGroupContent4">
                         <div class="Shipper1"> <asp:TextBox ID="txt_acc_first" runat="server"  ToolTip="Account#" placeHolder="Account#"
               CssClass="form-control" Width="100%" onkeypress="return isNumberKey(event,'ACCOUNT');" 
               TabIndex="22"></asp:TextBox></div>
                         <div class="Consignee4"> <asp:TextBox ID="txt_SwiftCode" runat="server"  ToolTip="SwiftCode" placeHolder="SwiftCode"
               CssClass="form-control" Width="100%" TabIndex="23"></asp:TextBox></div>
                         </div>
                      <div class="FormGroupContent4">
                          <asp:TextBox ID="txt_Bank_OSDN" runat="server"  ToolTip="Bank Name" placeHolder="Bank Name"
               CssClass="form-control" Width="100%" TabIndex="24"></asp:TextBox>
                          </div>
                     <div class="FormGroupContent4">
                         <div class="BankAddress">
                         <asp:TextBox ID="txt_bankaddr_OSDN" runat="server"  ToolTip="Bank Address" placeHolder="Bank Address" 
               CssClass="form-control"  TextMode="MultiLine" Height="30px" style="resize:none;" Rows="2"
               TabIndex="25"></asp:TextBox>
                             </div>
                         </div>
                     <div class="bordertopNew"></div>
                      <div class="FormGroupContent4">
                          <div class="BankLbl"><asp:Label ID="Label2" runat="server" Text="Bank Details for Invoice/Local DN"></asp:Label></div>
                          </div>
                       <div class="FormGroupContent4">
                            <asp:TextBox ID="txt_favrg_second" runat="server"  ToolTip="Favouring" placeHolder="Favouring"
                 CssClass="form-control" TabIndex="26"></asp:TextBox> 
                           </div>
                      <div class="FormGroupContent4">
                           <div class="Shipper1"><asp:TextBox ID="txt_Acc_second" runat="server"  ToolTip="Account#" placeHolder="Account#" 
               CssClass="form-control" Width="100%" onkeypress="return isNumberKey(event,'ACCOUNT');" 
               TabIndex="27"></asp:TextBox> </div>
                          <div class="Consignee4"><asp:TextBox ID="txt_NEFTcode" runat="server"  ToolTip="NEFT Code" placeHolder="NEFT Code"
               CssClass="form-control"  TabIndex="28"></asp:TextBox></div>
                          </div>
                       <div class="FormGroupContent4">
                            <asp:TextBox ID="txt_Bank_LocalDN" runat="server"  ToolTip="Bank Name" placeHolder="Bank Name" 
               CssClass="form-control" TabIndex="29"></asp:TextBox>
                           </div>
                      <div class="FormGroupContent4">
                          <div class="BankAddress1">
                          <asp:TextBox ID="txt_BankAddr_LocalDN" runat="server"   ToolTip="Bank Address" placeHolder="Bank Address"
               CssClass="form-control" Width="100%" TextMode="MultiLine" TabIndex="30" style="resize:none;" Rows="2"></asp:TextBox> 
                              </div>
                          </div>
                     <div class="bordertopNew"></div>
                      <div class="FormGroupContent4">
                          <div class="BaseTxt1"><asp:TextBox ID="txt_baseCurr" runat="server"  ToolTip="Base Currency" placeHolder="Base Currency"
               CssClass="form-control" TabIndex="31"></asp:TextBox></div>
                          <div class="BaseTxt1"> <asp:TextBox ID="txt_seperator" runat="server"  ToolTip="Seperator" placeHolder="Seperator"
               CssClass="form-control" TabIndex="32"></asp:TextBox> </div>
                          <div class="BaseTxt2"> <asp:TextBox ID="txt_acc_mailid" runat="server"  ToolTip="Account Mail ID" placeHolder="Account Mail ID"
               CssClass="form-control"  TabIndex="33" ontextchanged="txt_acc_mailid_TextChanged" AutoPostBack="True"></asp:TextBox></div>
                          </div>
                 </div>
           <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="Export1"> <asp:TextBox ID="txt_exdoc_mailid" runat="server"  ToolTip="Export Ducumention Mail Id" placeHolder="Export Ducumention Mail Id"
               CssClass="form-control" Width="100%" TabIndex="34" AutoPostBack="True" ontextchanged="txt_exdoc_mailid_TextChanged"></asp:TextBox></div>
                  <div class="Export1"><asp:TextBox ID="txt_excoord_mailid" runat="server"  ToolTip="Export Coordination Mail Id" placeHolder="Export Coordination Mail Id"
               CssClass="form-control"  TabIndex="35" AutoPostBack="True" ontextchanged="txt_excoord_mailid_TextChanged"></asp:TextBox></div>
                  <div class="Export2"><asp:TextBox ID="txt_exope_mailid" runat="server"  ToolTip="Export Operation Mail Id" placeHolder="Export Operation Mail Id"
               CssClass="form-control" TabIndex="36" AutoPostBack="True" ontextchanged="txt_exope_mailid_TextChanged"></asp:TextBox></div>
              </div>
                <div class="FormGroupContent4">
                    <div class="Export1"><asp:TextBox ID="txt_impdoc_mailid" runat="server"  ToolTip="Import Ducumention Mail Id" placeHolder="Import Ducumention Mail Id"
               CssClass="form-control" Width="100%" TabIndex="37" AutoPostBack="True" ontextchanged="txt_impdoc_mailid_TextChanged"></asp:TextBox></div>
                     <div class="Export1"> <asp:TextBox ID="txt_impcoord_mailid" runat="server"  ToolTip="Import Coordination Mail Id" placeHolder="Import Coordination Mail Id"
               CssClass="form-control" TabIndex="38" AutoPostBack="True" CausesValidation="True" ontextchanged="txt_impcoord_mailid_TextChanged"></asp:TextBox></div>
                     <div class="Export2"><asp:TextBox ID="txt_impoper_mailid" runat="server"  ToolTip="Import Operation Mail Id" placeHolder="Import Operation Mail Id"
               CssClass="form-control" TabIndex="39" AutoPostBack="True" ontextchanged="txt_impoper_mailid_TextChanged"></asp:TextBox></div>
                    </div>
              <div class="bordertopNew"></div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0 MB10">
                      <div class="btn ico-save" id="btnSave1" runat="server">
                           <asp:Button ID="btnSave" runat="server"  ToolTip="Save" onclick="btnSave_Click" TabIndex="40" />
         
                      </div>
                      <div class="btn ico-back" id="btnCancel1" runat="server">
                            <asp:Button ID="btnCancel" runat="server"  ToolTip="Cancel"  onclick="btnCancel_Click" TabIndex="41"  />
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
                                    <label id="lbl" runat="server">Branch :</label>

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


   <div>
        <asp:HiddenField ID="hdf_portid" runat="server" />
       <asp:HiddenField ID="hdf_Locationid" runat="server" />
        <asp:HiddenField ID="hdf_branchid" runat="server" />
        <asp:HiddenField ID="hdf_RegionId" runat="server" />
         <asp:HiddenField ID="hdf_divisionid" runat="server" />
        <asp:HiddenField ID="hdn_rmid" runat="server" />
         <asp:HiddenField ID="hdn_bmid" runat="server" />
          <asp:HiddenField ID="hdn_PTC" runat="server" />
          <asp:HiddenField ID="hdn_Flag" runat="server" />
    </div>


</asp:Content>
