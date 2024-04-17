
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Masterlocation1.aspx.cs" Inherits="logix.Maintenance.Masterlocation1" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap-select.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/lodash.compat.min.js"></script>

    <!-- Smartphone Touch Events -->
    <script type="text/javascript" src="../Theme/Content/plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/event.swipe/jquery.event.swipe.js"></script>

    <!-- General -->
    <script type="text/javascript" src="../Theme/Content/assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/respond/respond.min.js"></script>
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- Page specific plugins -->
    <!-- Charts -->
    <script type="text/javascript" src="../Theme/Content/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/blockui/jquery.blockUI.min.js"></script>

    <!-- Forms -->
    <script type="text/javascript" src="../Theme/Content/plugins/typeahead/typeahead.min.js"></script>
    <!-- AutoComplete -->
    <script type="text/javascript" src="../Theme/Content/plugins/autosize/jquery.autosize.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/inputlimiter/jquery.inputlimiter.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/uniform/jquery.uniform.min.js"></script>
    <!-- Styled radio and checkboxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/select2/select2.min.js"></script>
    <!-- Styled select boxes -->
    <script type="text/javascript" src="../Theme/Content/plugins/fileinput/fileinput.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/duallistbox/jquery.duallistbox.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-inputmask/jquery.inputmask.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.min.js"></script>

    <!-- Globalize -->
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/globalize.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/globalize/cultures/globalize.culture.ja-JP.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>
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
    <link href="../Styles/Mastercompany1.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/ControlStyle2.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>

        <script type="text/javascript">
            function disableBtn(btnID, newText) {
                //initialize to avoid 'Page_IsValid is undefined' JavaScript error
                Page_IsValid = null;
                //check if the page request any validation
                // if yes, check if the page was valid
                if (typeof (Page_ClientValidate) == 'function') {
                    Page_ClientValidate();
                    //you can pass in the validation group name also
                }
                //variables
                var btn = document.getElementById(btnID);
                var isValidationOk = Page_IsValid;
                /********NEW UPDATE************************************/
                //if not IE then enable the button on unload before redirecting/ rendering
                if (navigator.appName !== 'Microsoft Internet Explorer') {
                    EnableOnUnload(btnID, btn.value);
                }
                /***********END UPDATE ****************************/
                // isValidationOk is not null
                if (isValidationOk !== null) {
                    //page was valid
                    if (isValidationOk) {
                        btn.disabled = true;
                        btn.value = newText;
                        btn.style.background = 'url(~/images/ajax-loader.gif)';
                    }
                    else {//page was not valid
                        btn.disabled = false;
                    }
                }
                else {//the page don't have any validation request
                    setTimeout("setImage('" + btnID + "')", 10);
                    btn.disabled = true;
                    btn.value = newText;
                }
            }

            //set the background image of the button
            function setImage(btnID) {
                var btn = document.getElementById(btnID);
                btn.style.background = 'url(images/Loading.gif)';
            }

            //enable the button and restore the original text value
            function EnableOnUnload(btnID, btnText) {
                window.onunload = function () {
                    var btn = document.getElementById(btnID);
                    btn.disabled = false;
                    btn.value = btnText;
                }
            }
    </script>
     
    <script type="text/javascript">
        function pageLoad(sender, args) {



            $(document).ready(function () {
                $("#<%= txtlocname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_locid.ClientID %>").val(0);
                        $.ajax({
                            url: "Masterlocation1.aspx/GetLikeLocation",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtlocname.ClientID %>").val(i.item.label);
                        $("#<%=txtlocname.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtlocname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_locid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtlocname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hid_locid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtlocname.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtlocname.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });




            $(document).ready(function () {
                $("#<%= txt_districtname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_disid.ClientID %>").val(0);
                        $.ajax({
                            url: "Masterlocation1.aspx/GetLikeDistrict",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txt_districtname.ClientID %>").val(i.item.label);
                        $("#<%=txt_districtname.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txt_districtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_disid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txt_districtname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hid_disid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txt_districtname.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txt_districtname.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });





            $(document).ready(function () {
                $("#<%= txtstatename.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_stid.ClientID %>").val(0);
                        $.ajax({
                            url: "Masterlocation1.aspx/GetLikeState",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtstatename.ClientID %>").val(i.item.label);
                        $("#<%=txtstatename.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtstatename.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_stid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtstatename.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hid_stid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtstatename.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtstatename.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            //$(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });






            $(document).ready(function () {
                $("#<%= txtcountryname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_cid.ClientID %>").val(0);
                        $.ajax({
                            url: "Masterlocation1.aspx/GetCountryName",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtcountryname.ClientID %>").val(i.item.label);
                        $("#<%=txtcountryname.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcountryname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_cid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtcountryname.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hid_cid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtcountryname.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtcountryname.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });



            $(document).ready(function () {
                $("#<%= txtcityport.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_pid.ClientID %>").val(0);
                        $.ajax({
                            url: "Masterlocation1.aspx/GetPortName",
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {

                                    return {
                                        label: item.split('~')[0],
                                        val: item.split('~')[1],
                                        add: item.split('~')[2]
                                    }
                                }))

                            },

                            error: function (response) {
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtcityport.ClientID %>").val(i.item.label);
                        $("#<%=txtcityport.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcityport.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hid_pid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtcityport.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hid_pid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtcityport.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtcityport.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });

            $(document).ready(function () {
                $("#<%=txtpincode .ClientID %>").autocomplete({
                     source: function (request, response) {

                         $.ajax({
                             url: "Masterlocation1.aspx/GetPincode",
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
                         $("#<%=txtpincode .ClientID %>").val(i.item.value);
                        $("#<%=txtpincode.ClientID %>").change();
                        $("#<%=hdf_pinlocation .ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);

                    },
                    focus: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                        $("#<%=hdf_pinlocation .ClientID %>").val(i.item.val);
                    },
                    close: function (event, i) {
                        $("#<%=txtpincode .ClientID %>").val(i.item.value);
                        $("#<%=hdf_pinlocation .ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
             });

            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>

   <style type="text/css">

  .Locationcode1 {
        width: 100%;
    font-size: 11px;
    float: left;
    color: #000080;
    margin: 0px 0px 0px 0px;
}

  div#logix_CPH_ddtype_chzn {
    width: 116px !important;
}

  .chzn-drop {
    height: 140px !important;
}
  div#logix_CPH_div_save {
    margin: 0px 15px 0px 0px;
}

  .Locationcode1type
  {
          width: 13.6%;
    font-size: 11px;
    float: left;
    color: #000080;
    margin: 0px 0.5% 0px 0px;
  }
.Locationcode2 {
       width: 100%;
    font-size: 11px;
    float: left;
    color: #000080;
    margin: 0px 0px 0px 0px;
}

.Locationcode4
{
       width: 15.5%;
    font-size: 11px;
    float: left;
    color: #000080;
    margin: 0px 0px 0px 0px;
}
.Locationcode3 {
    width: 18.5%;
    font-size: 11px;
    float: left;
    color: #000080;
    margin: 0px 0px 0px 0px;
}


.UserRight {
    width: 34%;
    float: left;
    margin: 0px 0% 0px 0px;
    padding-left: 0.5%;
    border-left: 1px dotted #b1b1b1;
}


.UserLeft {
    width: 65%;
    float: left;
    padding: 0px 0.5% 0px 0px;
}

.gridview1 {
    height: 500px;
    border: 1px solid #b1b1b1;
    width: 100%;
    float: left;
    overflow: auto;
}

.chzn-container-single .chzn-single span {
    width: 200px;
    margin-right: 26px;
    display: block;
    overflow: hidden;
    white-space: nowrap;
    -o-text-overflow: ellipsis;
    -ms-text-overflow: ellipsis;
    text-overflow: ellipsis;
    /* background-color: #CC0A0A; */
    text-align: left;
    text-transform: capitalize;
}

 

input#logix_CPH_Btn_save {
    margin: 0px -12px 0px 0px !important;
}
.widget.box{
    position: relative;
    top: -8px;
}
.statename {
    float: left;
    width: 31%;
    margin: 0px 0.5% 0px 0px;
}
.divleft{
     float: left;
    width: 30%;
    margin: 0px 0.5% 0px 0px;
}
.divright{
     float: left;
    width: 69.5%;
    margin: 0px 0px 0px 0px;
}
.gridpnl {
    height: calc(100vh - 124px);
}
.TextField {
    position: relative;
    margin: 0px 1% 0px 0px !important;
}
div#logix_CPH_div_iframe .widget-content {
    top: 0px !important;
    padding-top:65px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">
    <asp:Panel runat="server">
       

        <!-- Breadcrumbs line End -->
        <div >
            <div class="col-md-12  maindiv">

                <div class="widget box" runat="server" id="div_iframe">
                    <div class="widget-header">
                        <div>
                        <div style="float: left; margin: 0px 0.5% 0px 0px;">
                            <h4 class="hide"><i class="icon-umbrella"></i>
                                <asp:Label ID="lbl_Header" runat="server" Text="MasterLocation"></asp:Label></h4>
                             <!-- Breadcrumbs line -->
        <div class="crumbs">
            <ul id="breadcrumbs" class="breadcrumb">
                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                <li><a href="#" title="">Maintenance</a> </li>
                <li class="current"><a href="#" title="">MasterLocation</a> </li>
            </ul>
        </div>
                        </div>
                      </div>


                                                       <div  class="FixedButtons" >
                <div class="right_btn">


               <div runat="server"   id="div_save" class="btn ico-save">
           <asp:Button ID="Btn_save" runat="server"  Text="Save" ToolTip="save" OnClick="btnSave_Click" TabIndex="10"/></div>

<div class="btn ico-cancel" id="btn_back1" runat="server">
           <asp:Button ID="Btn_cancel" runat="server" Text="Cancel" TabIndex="11" ToolTip="Cancel"  OnClick="Btn_cancel_Click" /></div>

<div class="btn ico-back" id="btnBack1" runat="server" visible="false">
               <asp:Button ID="btnBack" runat="server" ToolTip="Back" TabIndex="5"  Visible="false" />
           </div>

        </div>
           </div>

                    </div>
                    <div class="widget-content">
                       
                            
                        <div class="FormGroupContent4">
                            <div class="divleft">
                                <div class="FormGroupContent4">
                                      <div class="Locationcode1">
                                <asp:Label ID="lblLocName" runat="server" CssClass="hide" Text="Location Name"></asp:Label>

                            <asp:TextBox ID="txtlocname" ToolTip="Location Name" CssClass="form-control" placeholder="Location Name" runat="server" OnTextChanged="txtloc_TextChanged" AutoPostBack="true" TabIndex="1"></asp:TextBox>                             
                            </div>
                                </div>
                                <div class="FormGroupContent4">
                                      <div class="Locationcode2">
                                <asp:Label ID="Label1" runat="server" CssClass="hide" Text="City Port"></asp:Label>

                     <asp:TextBox ID="txtcityport" ToolTip="Port" CssClass="form-control" placeholder="City Port" runat="server" TabIndex="2" AutoPostBack="true" OnTextChanged="txtcityport_TextChanged" ></asp:TextBox>

                               
                            </div>
                                </div>
                                <div class="FormGroupContent4">
                                      <div class="Locationcode2">
                                <asp:Label ID="lbldisname" runat="server" CssClass="hide" Text="District"></asp:Label>

                     <asp:TextBox ID="txt_districtname" ToolTip="District" CssClass="form-control" placeholder="District" runat="server" TabIndex="5" AutoPostBack="true" OnTextChanged="txt_districtname_TextChanged"></asp:TextBox>

                               
                            </div>
                                </div>
                                <div class="FormGroupContent4">
                                      <div class="statename">
                                <asp:Label ID="lblstname" runat="server" CssClass="hide" Text="State"></asp:Label>

                     <asp:TextBox ID="txtstatename" ToolTip="State" CssClass="form-control" placeholder="State" runat="server" TabIndex="6" AutoPostBack="true" OnTextChanged="txtstatename_TextChanged"></asp:TextBox>

                               
                            </div>
                                      <div class="Locationcode2" style="width: 31%;margin-right: 0.5%;
" >
                                <asp:Label ID="lblcircle" runat="server" CssClass="hide" Text="Circle"></asp:Label>

                     <asp:TextBox ID="txtcircle" ToolTip="Port Type" CssClass="form-control" placeholder="Circle" runat="server" TabIndex="4" ></asp:TextBox>

                               
                            </div>
                                        <div class="Locationcode4" id="divgst" runat="server" visible="false">
                                <asp:Label ID="lblgstcode" runat="server" CssClass="hide" Text="GST"></asp:Label>

                     <asp:TextBox ID="txt_gstcode"  ToolTip="gstcode" CssClass="form-control" placeholder="GST" runat="server" TabIndex="9" Enabled="false"></asp:TextBox>

                               
                            </div>
                                        <div class="Locationcode3">
                                <asp:Label ID="lblpincode" runat="server" CssClass="hide" Text="Pincode"></asp:Label>

                     <asp:TextBox ID="txtpincode" ToolTip="Pincode" MaxLength="6" CssClass="form-control" placeholder="Pincode" runat="server" TabIndex="8" ></asp:TextBox>

                               
                                </div>
                               
                                <div class="FormGroupContent4">
                                      <div class="Locationcode2">
                                <asp:Label ID="lblcname" runat="server" CssClass="hide" Text="Country"></asp:Label>

                     <asp:TextBox ID="txtcountryname" ToolTip="Country" CssClass="form-control" placeholder="Country" runat="server" TabIndex="7" AutoPostBack="true" OnTextChanged="txtcountryname_TextChanged"></asp:TextBox>

                               
                            </div>
                                </div>
                                
                                <div class="FormGroupContent4">
                                        <div class="Locationcode2 hide">
                                <asp:Label ID="lblpotype" runat="server" CssClass="hide" Text="Port Type"></asp:Label>

                     <asp:TextBox ID="txtpotype" ToolTip="Port Type" CssClass="form-control" placeholder="Port Type" runat="server" TabIndex="3" ></asp:TextBox>

                               
                            </div>
                                </div>
                             
                                </div>
                               
                          


                            </div>

                            <div class="divright">
                                  <div class="FormGroupContent4 boxmodal">
                                <div class="gridpnl">
                                    <asp:GridView ID="GrdLocDtls" runat="server" Width="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"  AutoGenerateColumns="false" 
                                         EmptyDataText="No Record Found" OnSelectedIndexChanged="GrdLocDtls_SelectedIndexChanged" OnRowDataBound="GrdLocDtls_RowDataBound" AllowPaging="false" PageSize ="20" OnPageIndexChanging="GrdLocDtls_PageIndexChanging" >
                                        <Columns><asp:BoundField DataField="locationid" HeaderText="ID" >
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                               
                                            <asp:BoundField DataField="location" HeaderText="Location Name">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="portname" HeaderText="Port Name">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="districtname" HeaderText="District Name">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="statename" HeaderText="State Name">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="countryname" HeaderText="Country Name">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="circle" HeaderText="Circle">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="potype" HeaderText="Port Type">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pincode" HeaderText="Pincode">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="GSTCode" HeaderText="GSTCode">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="" Wrap="false" />
                                        <AlternatingRowStyle CssClass="GrdAltRow" />
                                        <RowStyle Font-Italic="False" />
                                    </asp:GridView>
                                </div>
                            </div>
                  
                            </div>
                        </div>
                              

                             

        </div>


                    </div>
                </div>
            </div>
        
    </asp:Panel>
    <asp:HiddenField ID="hid_locid" runat="server" />
   <asp:HiddenField ID="hid_disid" runat="server" />
    <asp:HiddenField ID="hid_stid" runat="server" />
    <asp:HiddenField ID="hid_cid" runat="server" />
    <asp:HiddenField ID="hid_pid" runat="server" />
   <asp:HiddenField ID="hdf_pinlocation" runat="server" /> 
</asp:Content>
