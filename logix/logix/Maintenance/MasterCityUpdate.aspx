<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="MasterCityUpdate.aspx.cs"
    Inherits="logix.Maintenance.MasterCityUpdate" %>

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
    <script type="text/javascript" src="../js/helper.js"></script>

    <script>
        $(document).ready(function () {



            $('.selectpicker').selectpicker();

            "use strict";

            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins

            //$('select.styled').customSelect();

        });


    </script>


    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>


    <link href="../Styles/MasterCityUpdate.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" language="javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtpincode.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../Maintenance/MasterCityUpdate.aspx/GetPincode",
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

                            },
                            failure: function (response) {

                            }
                        });
                    },

                    select: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                        $("#<%=txtpincode.ClientID %>").change();

                    },
                    change: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                    },
                    focus: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                    },
                    close: function (event, i) {
                        $("#<%=txtpincode.ClientID %>").val(i.item.value);
                    },
                    minLength: 1
                });
            });


                $(document).ready(function () {
                    $("#<%=txtlocation.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "../Maintenance/MasterCityUpdate.aspx/GetLocation",
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
                            $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                            $("#<%=txtlocation.ClientID %>").change();
                            $("#<%=hdf_location.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                            $("#<%=hdf_location.ClientID %>").val(i.item.val);
                            // $("#<%=txtlocation.ClientID %>").val($.trim(result));

                        },
                        change: function (event, i) {
                            if (i.item) {
                                $("#<%=txtlocation.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                                $("#<%=hdf_location.ClientID %>").val(i.item.val);
                                // $("#<%=txtlocation.ClientID %>").change();
                            }
                        },

                        close: function (event, i) {
                            var result = $("#<%=txtlocation.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txtlocation.ClientID %>").val($.trim(result));
                        },
                        minLength: 1
                    });
                });

                $(document).ready(function () {
                    $("#<%=txtcity .ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../Maintenance/MasterCityUpdate.aspx/GetPortName",
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
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                    $("#<%=txtcity.ClientID %>").change();
                    $("#<%=hf_portid .ClientID %>").val(i.item.val);


                },
                    focus: function (event, i) {
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                    $("#<%=hf_portid.ClientID %>").val(i.item.val);

                },
                    close: function (event, i) {
                        $("#<%=txtcity.ClientID %>").val(i.item.label);
                    $("#<%=hf_portid.ClientID %>").val(i.item.val);

                },
                    minLength: 1
                });
            });

        $(document).ready(function () {
            $("#<%=txtstate.ClientID %>").autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: "../Maintenance/MasterCityUpdate.aspx/GetState",
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
                        $("#<%=txtstate.ClientID %>").val(i.item.label);
                    $("#<%=txtstate.ClientID %>").change();
                    $("#<%=hf_stateid .ClientID %>").val(i.item.val);


                },
                    focus: function (event, i) {
                        $("#<%=txtstate.ClientID %>").val(i.item.label);
                    $("#<%=hf_stateid.ClientID %>").val(i.item.val);

                },
                    close: function (event, i) {
                        $("#<%=txtstate.ClientID %>").val(i.item.label);
                    $("#<%=hf_stateid.ClientID %>").val(i.item.val);

                },
                    minLength: 1
                });
            });
    }</script>


    <style type="text/css">
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
            width: 65%;
            float: left;
            margin: 2px 0px 3px 4px;
        }

            .LogHeadLbl label {
                color: #af2b1a;
                font-weight: bold;
                font-size: 12px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 12px;
        }


        .LogHeadJobInput {
            width: auto;
            white-space: nowrap;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 12px;
                margin: 4px 0px 0px 0px;
            }




            .LogHeadJobInput label {
                font-size: 12px;
                font-family: sans-serif;
                color: #4e4e4c;
            }

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .widget.box {
            position: relative;
            top: -8px;
        }
        .divleft{
             width: 27.5%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
         .exlocation{
             width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }
         .Shipper1 {
    width: 100%;
    float: left;
    margin: 0px 0.5% 0px 0px;
}
         .Consignee3 {
    width: 100%;
    margin: 0px 0px 0px 0px;
    float: left;
}
         .FormGroupContent4 select {
    border-bottom: 1px solid var(--inputborder);
    border-right: none;
    border-left: none;
    overflow: auto !important;
    border-top: none;

}
         select#logix_CPH_lstLocation {
    padding: 24px 0px 0px 5px !important;
}
         .widget.box .widget-content {
    top: 0px !important;
    padding-top:65px !important;
}
   .FixedButtonsss {
    width: calc(100vw - 923px) !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="Master City Update"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Maintenance</a> </li>
                                <li class="current"><a href="#" title="">Master City Update</a> </li>
                            </ul>
                        </div>
                    </div>
                    <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm">
                        <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click"></asp:LinkButton>
                    </div>
                        </div>


                                             <div  class="FixedButtons" >
    <div class="right_btn">
        <div class="btn ico-save" id="btnSave1" runat="server">
            <asp:Button ID="btnSave" runat="server" ToolTip="Update" Text="Update" TabIndex="6" OnClick="btnSave_Click" />
        </div>
        <div class="btn ico-cancel" id="btnCancel1" runat="server">
            <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" Text="Cancel" TabIndex="7" OnClick="btnCancel_Click" />
        </div>
    </div>
</div>

                </div>
                <div class="widget-content">
                      
                    <div class="FormGroupContent4">
                    <div class="divleft">
                        <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:TextBox ID="txtpincode" runat="server" AutoPostBack="True" TabIndex="1" PlaceHolder="Pincode" ToolTip="PINCODE" CssClass="form-control" OnTextChanged="txtpincode_TextChanged"></asp:TextBox>

                        </div>

                        </div>
                        <div class="FormGroupContent4">
                        <div class="Consignee3">
                            <asp:TextBox ID="txtlocation" runat="server" AutoPostBack="True" TabIndex="2" CssClass="form-control" PlaceHolder="New Location" ToolTip="Location" OnTextChanged="txtlocation_TextChanged"></asp:TextBox>
                        </div>

                        </div>
                        <div class="FormGroupContent4">
                            <div class="exlocation">
                            <span>Existing Location</span>
                            <asp:ListBox ID="lstLocation" runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="3" PlaceHolder="Existing Location" ToolTip="ADDRESS" OnSelectedIndexChanged="lstLocation_SelectedIndexChanged"></asp:ListBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                        <div class="Shipper1">
                            <asp:TextBox ID="txtcity" runat="server" AutoPostBack="True" PlaceHolder="City" ToolTip="City" TabIndex="4" CssClass="form-control" OnTextChanged="txtcity_TextChanged"></asp:TextBox>
                        </div>

                        </div>
                        <div class="FormGroupContent4">
                        <div class="Consignee3">
                            <asp:TextBox ID="txtstate" runat="server" AutoPostBack="True" TabIndex="5" CssClass="form-control" PlaceHolder="State" ToolTip="State" OnTextChanged="txtstate_TextChanged"></asp:TextBox>
                        </div>

                        </div>
                      

                    </div>

                    </div>
                     
                    
                    
                   
                 
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdf_location" runat="server" />
    <asp:HiddenField ID="hf_portid" runat="server" />
    <asp:HiddenField ID="hf_stateid" runat="server" />


    <div id="PanelLog1" runat="server">
        <asp:Panel ID="PanelLog" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
            <div class="divRoated">
                <div class="LogHeadLbl">
                    <div class="LogHeadJob">
                        <label id="lbl" runat="server">PINCODE :</label>

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

    <asp:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </asp:ModalPopupExtender>

</asp:Content>
