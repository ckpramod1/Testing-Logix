<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="AssignCalls.aspx.cs"
    Inherits="logix.CRM.AssignCalls" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css">

    <!-- Theme -->
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <%--<link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />--%>
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">

  <%--  <!--=== JavaScript ===-->

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
  --%>
      <link href="../Theme/assets/css/systemcrmnewcs.css" rel="stylesheet" type="text/css" />
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



    <link href="../Styles/chosen.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Scripts/validationfortextbox.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/TeleSalescrm.css" rel="stylesheet" />
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }

        .hide {
            display: none;
        }

        .div_txtEmpName {
            width: 100%;
            float: left;
            margin-top: 0.5%;
        }
        .row {
    height: 584px !important;
    margin: 0px 5px 0px 0px;
    clear: both;
    overflow-x: hidden !important;
    overflow-y: hidden !important;
    width: 99%;
}
        .widget.box {

    border: 1px solid #D9D9D9;
    float: left;
    width: 100%;
    margin-left: 0px;
    margin-top: 0px;
    height: 556px;

}

        .modalPopupss {
    background-color: #FFFFFF;
    border-width:1px;
    border-style: solid;
    border-color: #CCCCCC;
    /*width: 1062px;*/
    width: 97.5%;
    height: 565px;
    margin-left: 1%;
    margin-top: -0.9%;
    /*padding:1px;            
            display:none;*/
}

        #logix_CPH_pln_cust {
            left:8px!important;
            top:50px!important;
        }
        iframe#logix_CPH_iframecost {
            width:1329px;
            height:520px;
        }


    </style>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtcustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../CRMNew/AssignCalls.aspx/GetCustomer",
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
                                //alertify.alert(response.responseText);
                            },
                            failure: function (response) {
                                // alertify.alert(response.responseText);
                            }
                        });
                    },

                    select: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=txtcustomer.ClientID %>").change();
                        $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                        $("#<%=HdnCusId.ClientID %>").val(i.item.val);
                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=HdnCusId.ClientID %>").val(i.item.val);

                        }

                    },
                    close: function (event, i) {
                        var result = $("#<%=txtEmpname.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtEmpname.ClientID %>").val($.trim(result));

                    },
                    minLength: 1
                });
            });






            $(document).ready(function () {
                $("#<%=txtEmpname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_Empname.ClientID %>").val(0);
                            $.ajax({
                                url: "../CRMNew/AssignCalls.aspx/GetEmpname",
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
                                    alertify.alert(response.responseText);
                                },
                                failure: function (response) {
                                    alertify.alert(response.responseText);
                                }
                            });
                        },

                        select: function (event, i) {
                            $("#<%=txtEmpname.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtEmpname.ClientID %>").change();
                            $("#<%=hid_Empname.ClientID %>").val(i.item.val);
                        },
                    focus: function (event, i) {
                        $("#<%=txtEmpname.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_Empname.ClientID %>").val(i.item.val);
                        },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtEmpname.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hid_Empname.ClientID %>").val(i.item.val);

                            }

                        },
                    close: function (event, i) {
                        var result = $("#<%=txtEmpname.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txtEmpname.ClientID %>").val($.trim(result));

                        },
                    minLength: 1
                });
            });


                $(document).ready(function () {
                    $("#<%=txtRemarks.ClientID %>").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "../CRMNew/AssignCalls.aspx/GetRemarks",
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
                            $("#<%=txtRemarks.ClientID %>").val(i.item.label);
                        $("#<%=txtRemarks.ClientID %>").change();


                    },
                        focus: function (event, i) {
                            $("#<%=txtRemarks.ClientID %>").val(i.item.label);


                    },
                    close: function (event, i) {
                        $("#<%=txtRemarks.ClientID %>").val(i.item.label);


                    },
                    minLength: 1
                    });
                });

                $(document).ready(function () {
                    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

                });
            }
    </script>
    <%--  <script type="text/javascript">
        function CheckBoxCheck() {
            debugger;
            //var gv = document.getElementById("chkall");
            var gv=  $("#chkall").is(":checked");
            if (gv)
            {
                var GridView = GrdCustomer.parentNode.parentNode.parentNode;
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chb = GridView.rows[i].cells[11].getElementsByTagName("input")[0];
                    chb.checked = GrdCustomer.checked;
                }
            }
            
        }
</script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">




    <!-- Breadcrumbs line -->
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#" title="">CRM</a> </li>
            <li><a href="#" title="">CRM</a> </li>
            <li class="current"><a href="#" title="">Assign Calls</a> </li>
        </ul>
    </div>
    <!-- Breadcrumbs line End -->
    <div >
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <h4><i class="icon-umbrella"></i>
                        <asp:Label ID="lbal_Header" runat="server" Text="Assign Calls"></asp:Label></h4>
                </div>
                <div class="widget-content">
                    <div class="FormGroupContent4">
                        <div class="div_txtEmpName">
                            <asp:TextBox ID="txtEmpname" runat="server" TabIndex="1" CssClass="form-control" Width="100%" PlaceHolder=" Emp Name" ToolTip="Emp Name" AutoPostBack="True" OnTextChanged="txtEmpname_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="StateDrop">
                            <asp:DropDownList data-placeholder="City" ID="ddlCity" runat="server" ToolTip="City" TabIndex="2" CssClass="chzn-select" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" ForeColor="Black">

                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>

                        </div>

                        <div class="DistrictDrop">
                            <asp:DropDownList data-placeholder="Commdity" ID="dllCommdity" runat="server" ToolTip="Commdity" TabIndex="3" CssClass="chzn-select"
                                Width="100%" AutoPostBack="True" OnSelectedIndexChanged="dllCommdity_SelectedIndexChanged" ForeColor="Black">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LocationDrop">
                            <asp:DropDownList data-placeholder="Grade" ID="ddlGrade" runat="server" ToolTip="Grade" TabIndex="4" CssClass="chzn-select" Width="100%"
                                AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LocationDropproduct">
                            <asp:DropDownList data-placeholder="Product" ID="ddlProduct" runat="server" ToolTip="Product" TabIndex="5" CssClass="chzn-select" Width="100%" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                <asp:ListItem Text="Product" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">Ocean Exports FCL</asp:ListItem>
                                <asp:ListItem Value="2">Ocean Exports LCL</asp:ListItem>
                                <asp:ListItem Value="3">Ocean Imports FCL</asp:ListItem>
                                <asp:ListItem Value="4">Ocean Imports LCL</asp:ListItem>
                                <asp:ListItem Value="5">Air  Exports</asp:ListItem>
                                <asp:ListItem Value="6">Air  Imports</asp:ListItem>
                                <asp:ListItem Value="7">Projects</asp:ListItem>
                                <asp:ListItem Value="8">CHA [Ony CHA]</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LocationDropP1">
                            <asp:DropDownList data-placeholder="Export/Import Country" ID="ddlCountry" ToolTip="Export/Import Country" runat="server" TabIndex="6" CssClass="chzn-select" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" ForeColor="Black">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LocationDropPincode">
                            <asp:DropDownList data-placeholder="Pincode" ID="ddlPicode" runat="server" ToolTip="Pincode" TabIndex="7" CssClass="chzn-select" Width="100%" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlPicode_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- <div class="NewRad"> <asp:RadioButtonList ID="CustListchk" runat="server" AutoPostBack="true" Width="100%" CssClass="LabelValue" BorderColor="White"
                RepeatDirection="Horizontal"  OnSelectedIndexChanged="CustListchk_SelectedIndexChanged" TabIndex="4">
                <asp:ListItem Text="New" Value="New"></asp:ListItem>
                <asp:ListItem Text="Followup" Value="Followup"></asp:ListItem>
                <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
          </asp:RadioButtonList> </div>--%>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="Custoemr2">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TabIndex="8" PlaceHolder=" Remarks" ToolTip="Remarks" AutoPostBack="True" OnTextChanged="txtRemarks_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="FormGroupContent4">
                        <div class="CustoemrAssign">
                            <asp:TextBox ID="txtcustomer" runat="server" CssClass="form-control" PlaceHolder=" Customer" ToolTip="Customer" AutoPostBack="True" TabIndex="9" OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                        </div>
                        <%--  <div class="pincodefil">
                            <asp:TextBox ID="txtpincode" runat="server" CssClass="form-control" PlaceHolder=" Pincode" ToolTip="Pincode" AutoPostBack="True" TabIndex="6" OnTextChanged="txtpincode_TextChanged"></asp:TextBox>
                        </div>--%>
                        <%-- <div class="right_btn MT0">
                            <div class="btn ico-back ADDPad">
                               
                            </div>
                        </div>--%>
                    </div>
                    <div class="FormGroupContent4">
                        <div style="margin-top: 0.5%; margin-left: 8%; color: red">
                            <asp:Label ID="LblName" Font-Size="17px" runat="server" Text=""></asp:Label>
                        </div>

                        <div style="height: 308px; width: 100%; margin-bottom: 0.8%;border-bottom:1px dotted #b1b1b1;">

                            <asp:GridView ID="GrdCustomer" runat="server" Width="100%" CellPadding="3"
                                AutoGenerateColumns="False" CssClass="Grid FixedHeader"  ShowHeaderWhenEmpty="true" OnRowDataBound="GrdCustomer_RowDataBound" OnSelectedIndexChanged="GrdCustomer_SelectedIndexChanged" AllowPaging="false" PageSize="12" OnPageIndexChanging="GrdCustomer_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="customerid" HeaderText="customerid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="customername" HeaderText="Company">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="location" HeaderText="Location">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="city" HeaderText="City">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="80px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="pincode" HeaderText="Pincode">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="50px" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="officetype" HeaderText="Office">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="80px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="website" HeaderText="Website">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="landline" HeaderText="Landline">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cityid" HeaderText="cityid" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countryid" HeaderText="LocationId" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="remarks" HeaderText="remarks" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkall" runat="server" AutoPostBack="true" OnCheckedChanged="chkall_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle CssClass="GrdRow" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="FormGroupContent4">
                        <div class="right_btn MT0">
                        <div class="btn ico-update">
                            <asp:Button ID="btnUpdate" runat="server" ToolTip="Update" TabIndex="10" OnClick="btnUpdate_Click" />

                        </div>
                        <div class="btn ico-back" id="btn_back1" runat="server">
                            <asp:Button ID="btnClear" runat="server" ToolTip="Back" OnClick="btnClear_Click" TabIndex="11" /></div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>


    <div class="imgHelp" style="display: none;">
        <asp:ImageButton ID="imghelp" runat="server" ImageUrl="~/images/helpicon3.png" ImageAlign="Right" Width="100%" Height="100%" Style="margin-right: 1%;" OnClick="imghelp_Click" />
    </div>


    <%--   <div class="div_total">

       <div class="Header"></div>
   
        <div class="div_Break "></div>
     
         <div class="DivStateTxt"> </div> 

         <div class="DivDistictTxt"></div> 

         <div class="DivLocationTxt">  </div> 

<%--    <link href="../Styles/chosen.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
         
       <div class ="divRadioList">
         
       </div>
         
       <div class="div_Break"> </div>
       <div> <hr /> </div>
       <div class="div_Break"> </div>
        
       <%--<div class="DivJoblbl"><asp:Label ID="Label1" runat="server" Text="Customer" CssClass="LabelValue"></asp:Label></div>
       <div class="DivJobTxt"> </div>
        <div class="DivClear"></div>
         
         <div class="div_Break"> </div>
       <div> <hr /> </div>
       <div class="div_Break" > </div>

         

 
        

       <div class="div_Break"> </div>
       <div class="div_Break"> </div>
       <div class="div_Break"> </div>
       <div class="div_Break"> </div>
       <div class="div_Break"> </div>
      
    </div>--%>




       <asp:Panel ID="pln_cust" runat="server"  CssClass="modalPopup"  style="display:none;">
       
        <div class="DivSecPanel"> <asp:Image ID="Close_Cheque" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"/>  </div>
             
     <%--<asp:Panel ID="Panel2" runat="server" class="Gridpnl1" ScrollBars="None">--%>
         <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames">
            </iframe>
          <%--  </asp:Panel>--%>
             <div class="div_Break"></div>
      
    </asp:Panel>
        <asp:ModalPopupExtender ID="popup_Cus" runat="server" PopupControlID="pln_cust" TargetControlID="Label1" CancelControlID="Close_Cheque">
    </asp:ModalPopupExtender>

        <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:HiddenField ID="HdnCusId" runat="server" />
    <asp:HiddenField ID="hid_City" runat="server" />
    <asp:HiddenField ID="hid_Empname" runat="server" />
    <asp:HiddenField ID="hid_country" runat="server" />
    <asp:HiddenField ID="Hid_commm" runat="server" />
    <asp:HiddenField ID="hid_product" runat="server" />
    <asp:HiddenField ID="hid_grage" runat="server" />
    <asp:HiddenField ID="Hid_remarks" runat="server" />
    <asp:HiddenField ID="hid_pincode" runat="server" />
</asp:Content>
