<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskDetailsDashMain.aspx.cs" Inherits="logix.TaskDetailsDashMain" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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

    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>


    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script>
    <script src="../js/TaskDashBordCardMain.js"></script>

    <%--<script>
        $(document).ready(function () {
            initializeSelectAllFunctionality();
        });
    </script>--%>



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
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gridr {
            width: 60.5%;
            float: left;
            margin: 47px 0px 0px 0px;
        }

        .header {
            display: none;
        }
        /*      .card h2 {
    font-size: 20px;
    margin: 0;
    color: black;
}

.card p {
    margin: 10px 0;
}



.card .span1 {
    color: #06529c !important;
    font-size: 16px !important;
    font-weight: 400 !important;
    cursor: pointer;
    min-height: 66px !important;
    position: relative;
    top: 91px;
    left: -5px;
    text-align: center;
}
.card .span2 {
  
     cursor: pointer;
     font-size:14px !important;
}
.card .span3 {
  font-size: 36px !important;
    font-weight: 500;
    position: relative;
    left: 97px;
    top: -40px;
    text-align: left;
}
.card img {
    scale: 1.5;
    margin-top: 15px;
    margin-left: 15px;
}
.span2 {
    display: none;
}
.dynamic {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 125px;
    padding: 0px 50px 10px 50px;
    margin-top: 60px;
}
.box-shadow {
    -webkit-transition: all .2s ease-out;
    -moz-transition: all .2s ease-out;
    -ms-transition: all .2s ease-out;
    -o-transition: all .2s ease-out;
    transition: all .2s ease-out !important;
}*/


        .span1 {
            color: #06529c !important;
        }
        /* .span2 {
color: #f8a350 !important;
    display: inline-block;
    width: 100%;
    margin-top: 12px !important;
}*/
       

        .cardborder {
            border: 1px solid #9f9b9b69;
            position: relative;
            top: 102px;
        }

     .dynamic {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 80px;
    /* padding: 0px 50px 10px 50px; */
    margin-top: 60px;
    row-gap: 80px;
    column-gap: 135px;
}

      

       

     



        .span2 {
            display: none;
        }

        #listContainer {
            list-style-type: none; /* Remove bullet points */
        }

            #listContainer li {
                margin-bottom: 5px; /* Optional: Add some spacing between items */
            }

        ul#listContainer {
            width: 100% !important;
            height: 769px;
            overflow: auto;
            margin-top: 10px;
        }

        .customer {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        .Formdisplay {
            float: left;
            width: 100%;
            color: #313131;
            padding: 0px 0px;
            margin: 0px 0.5% 0px 0px;
        }

        .dashleft {
            width: 100%;
            float: left;
            margin: 50px 0.5% 0px 0px;
        }

        .dashright {
            width: 100%;
            float: left;
            margin: 0px 0px 0px 0px;
        }

        #sp {
            position: relative;
            left: 54px;
            top: 32px;
            display: none;
        }

        #branch {
            position: relative;
            left: 19px;
            top: 17px;
        }

        .BillType1 {
            width: 14.6%;
            float: left !important;
            margin: 0px 0% 0px 0.5%;
        }

        ul, ol {
            margin-top: 0;
            margin-bottom: 0px;
            list-style: none;
        }


        input[type="radio"], input[type="checkbox"] {
            margin: 0px 0 0;
            line-height: normal;
            margin-right: 5px;
        }

        ul#listContainerbranch li {
            display: flex;
            line-height: 33px;
        }

        span#vouchar {
            position: relative;
            left: 19px;
            top: 17px;
        }






        ul#listContainervouchar li {
            display: flex;
            line-height: 33px;
        }

        ul#listContainerbranch {
            padding: 0px;
        }

        .taskleft {
            width: 15%;
            float: left
        }

        .taskright {
            width: 85%;
            float: left
        }

        ul#listContainervouchar {
            padding: 0px;
        }
        form {
    overflow-y: auto !important;
}
    </style>
</head>
<body>

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%= txtcustomer.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hf_customerid.ClientID %>").val(0);

                        $.ajax({
                            url: "TaskDetailsDashMain.aspx/GetCustomer",
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
                                //alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
                            }


                        });
                    },
                    select: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val(i.item.label);
                        $("#<%=txtcustomer.ClientID %>").change();


                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));
                            $("#<%=hf_customerid.ClientID %>").val(i.item.val);

                        }
                    },

                    focus: function (event, i) {
                        $("#<%=txtcustomer.ClientID %>").val($.trim(i.item.label.split(' ,')[0]));

                        $("#<%=hf_customerid.ClientID %>").val(i.item.val);
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtcustomer.ClientID %>").val().toString().split(' ,')[0];
                        $("#<%=txtcustomer.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txtSalesPerson.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hdf_salesperson.ClientID %>").val(0);
                        $.ajax({
                            url: "TaskDetailsDashMain.aspx/GetSales",
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
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                        $("#<%=txtSalesPerson.ClientID %>").change();
                        $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);
                    },
                    focus: function (event, i) {
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));

                        $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);

                    },
                    change: function (event, i) {
                        if (i.item) {
                            $("#<%=txtSalesPerson.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hdf_salesperson.ClientID %>").val(i.item.val);

                        }
                    },

                    close: function (event, i) {
                        var result = $("#<%=txtSalesPerson.ClientID %>").val().toString().split(',')[0];
                        $("#<%=txtSalesPerson.ClientID %>").val($.trim(result));
                    },
                    minLength: 1
                });
            });
        }
    </script>


    <%--<script type="text/javascript">
        function DoAction(Text) {
            $("#<%=hd_op.ClientID %>").val('');
            $("#<%=hd_op.ClientID %>").val(Text);
            $("#<%=btn_show.ClientID %>").click();
        }
    </script>--%>

    <%--    <script type="text/javascript">
        $(function () {
            $(".grd_operProfit_AC > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function (e) {
                    $(".grd_operProfit_AC td").removeClass("highlite");
                    var $cell = $(e.target).closest("td");
                    $cell.addClass('highlite');
                    var $currentCellText = $cell.text();
                    var $leftCellText = $cell.prev().text();
                    var $rightCellText = $cell.next().text();
                    var $colIndex = $cell.parent().children().index($cell);
                    var $colName = $cell.closest("table")
                        .find('th:eq(' + $colIndex + ')').text();
                    $("#para").empty()
                    .append("<b>Current Cell Text: </b>"
                        + $currentCellText + "<br/>")
                    .append("<b>Text to Left of Clicked Cell: </b>"
                        + $leftCellText + "<br/>")
                    .append("<b>Text to Right of Clicked Cell: </b>"
                        + $rightCellText + "<br/>")
                    .append("<b>Column Name of Clicked Cell: </b>"
                        + $colName)
                });

        });

    </script>--%>
    <%--</asp:Content>--%>
    <%--<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">--%>
    <div class="Maindiv">
    <form id="form1" runat="server">
       
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>
        <div class="maindiv">
        <div class="FormGroupContent4">



            <div id="Branch_list">
                <!-- Data will be populated here dynamically -->
            </div>



            <div class="BillType1 hide">

                <asp:DropDownList ID="ddl_branch" runat="server" onchange="voutypeddlChanged()">
                    <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                    <asp:ListItem Value="1" Text="CHENNAI"></asp:ListItem>
                    <asp:ListItem Value="2" Text="CORPORATE"></asp:ListItem>
                    <asp:ListItem Value="3" Text="TUTICORIN"></asp:ListItem>
                    <asp:ListItem Value="4" Text="BANGALORE"></asp:ListItem>
                    <asp:ListItem Value="5" Text="COCHIN"></asp:ListItem>
                    <asp:ListItem Value="10" Text="MUMBAI"></asp:ListItem>
                    <asp:ListItem Value="11" Text="NEW DELHI"></asp:ListItem>



                </asp:DropDownList>
            </div>


            <div class="BillType1 hide">

                <asp:DropDownList ID="ddl_voutype" runat="server" onchange="voutypeddlChanged()">
                    <asp:ListItem Value="All" Text="ALL"></asp:ListItem>
                    <asp:ListItem Value="FE" Text="Ocean Export"></asp:ListItem>
                    <asp:ListItem Value="FI" Text="Ocean Import"></asp:ListItem>
                    <asp:ListItem Value="AE" Text="Air Export"></asp:ListItem>
                    <asp:ListItem Value="AI" Text="Air Import"></asp:ListItem>



                </asp:DropDownList>
            </div>






            <div class="left_btn">
                <div class="btn ico-get">
                    <asp:Button ID="btn_GetScrSql" runat="server" Text="Get" CssClass="txtclr" ToolTip="Get" Visible="false" OnClientClick="ClearEmployeeTask(); return false;" />
                </div>

            </div>
        </div>

        <div class=" FormGroupContent4">


            <div class="taskleft">
                <div class="dashleft hide">

                    <asp:Label ID="sp" runat="server">Select All</asp:Label>
                    <asp:CheckBox ID="selectAllCheckBox" runat="server" Text="Select All" Visible="false" />
                    <ul id="listContainer"></ul>

                </div>
                <div class="dashleft">
                    <span>Branch</span>
                    <asp:Label ID="branch" runat="server">Select All</asp:Label>
                    <asp:CheckBox ID="selectAllCheckBoxbranch" runat="server" Text="Select All" Visible="false" />
                    <ul id="listContainerbranch"></ul>

                </div>



                <div class="dashleft">
                    <span>Product</span>

                    <asp:Label ID="vouchar" runat="server">Select All</asp:Label>
                    <asp:CheckBox ID="selectAllCheckBoxvouchar" runat="server" Text="Select All" Visible="false" />
                    <ul id="listContainervouchar"></ul>

                </div>




                <div class="FormGroupContent4">
                    <div class="Formdisplay ">
                        <span>Salesperson / Assigne</span>
                        <asp:TextBox ID="txtSalesPerson" runat="server" ToolTip="SALESPERSON" PlaceHolder="Salesperson" onblur="FinalFunTaskDashBord()" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="FormGroupContent4">
                    <div class="customer">
                        <asp:Label ID="customer_label" runat="server" CssClass="hide" Text="Customer"> </asp:Label>
                        <asp:TextBox ID="txtcustomer" ToolTip="Customer" placeholder="Customer" CssClass="form-control" onblur="FinalFunTaskDashBord()" runat="server"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="taskright">

                <div class="dashright">

                    <div class="dynamic" id="card_parent" runat="server">
                    </div>
                </div>







                <!-- Data will be rendered here -->
            </div>
        </div>


        <asp:HiddenField ID="hf_customerid" runat="server" />
        <asp:HiddenField ID="hdf_salesperson" runat="server" />
            </div>
    </form>
        </div>
</body>
</html>
<%--</asp:Content>--%>
