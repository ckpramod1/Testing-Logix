<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MasterExRate.aspx.cs" Inherits="logix.Maintenance.MasterExRate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>



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
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <!--=== JavaScript ===-->

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>



    <!-- App -->
    <script type="text/javascript" src="../Theme/Content/assets/js/app.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.js"></script>
    <script type="text/javascript" src="../Theme/Content/assets/js/plugins.form-components.js"></script>

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

    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%-- <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/MasterExRate.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/DropDownButton.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>


    <script type="text/javascript">

        function pageLoad(sender, args) {

          <%--$(document).ready(function () {
              $('#<%=GrdExrate.ClientID%>').gridviewScroll({
                    width: 440,
                    height: 205,
                    arrowsize: 30,

                    varrowtopimg: "../images/arrowvt.png",
                    varrowbottomimg: "../images/arrowvb.png",
                    harrowleftimg: "../images/arrowhl.png",
                    harrowrightimg: "../images/arrowhr.png"
                });
          });--%>

            $(document).ready(function () {
                $("#<%=txtcurrency.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "MasterExRate.aspx/GetCurrency",
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
                        $("#<%=txtcurrency.ClientID %>").val(i.item.label);
                        $("#<%=txtcurrency.ClientID %>").change();

                    },
                    focus: function (event, i) {
                        $("#<%=txtcurrency.ClientID %>").val(i.item.label);

                    },
                    close: function (event, i) {
                        $("#<%=txtcurrency.ClientID %>").val(i.item.label);

                    },
                    minLength: 1
                });
            });

                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


                $(".dropdown img.flag").addClass("flagvisibility");

                $(".dropdown dt a").click(function () {
                    $(".dropdown dd ul").toggle();
                });

                $(".dropdown dd ul li a").click(function () {
                    var text = $(this).html();
                    $(".dropdown dt a span").html(text);
                    $(".dropdown dd ul").hide();
                    //                $("#result").html("Selected value is: " + getSelectedValue("sample"));
                });

                function getSelectedValue(id) {
                    return $("#" + id).find("dt a span.value").html();
                }

                $(document).bind('click', function (e) {
                    var $clicked = $(e.target);
                    if (!$clicked.parents().hasClass("dropdown"))
                        $(".dropdown dd ul").hide();
                });

                $("#flagSwitcher").click(function () {
                    $(".dropdown img.flag").toggleClass("flagvisibility");
                });

            }

            //      ------------------------------------

            function validateEmpty() {

                //          var ExRateType = document.getElementById('<%=droptype.ClientID %>').value;
                var Currency = document.getElementById('<%=txtcurrency.ClientID %>').value;
                var RateOs = document.getElementById('<%=txtovers.ClientID %>').value;
                var LocalRate = document.getElementById('<%=txt_ratelocal.ClientID %>').value;
                var Date = document.getElementById('<%=txtDate.ClientID %>').value;

                //          if (ExRateType == "") {
                //              alertify.alert("Select ExRateType");
                //              return false;
                //          }
                if (Currency == "") {
                    alertify.alert("Enter Currency Value");
                    return false;
                }

                if (RateOs == "") {
                    alertify.alert("Enter RateOs Value");
                    return false;
                }
                if (LocalRate == "") {
                    alertify.alert("Enter LocalRate Value");
                    return false;
                }

            }


    </script>
    <style type="text/css">
        .DateInput4 {
            float: right;
            margin: 0;
            width: 14%;
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

        .TypeDrop1 {
            width: 15%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }


        .LogHeadJobInput label {
            font-size: 12px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        logix_CPH_PanelLog {
            top: 155px !important;
        }

        .FormTxtDate {
            float: left;
            width: 14.5%;
            margin: 0px 0.5% 0px 0px;
        }

        .GridExRate1 {
            width: 100%;
            float: left;
            max-height: 300px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }

        .GridExRate2 {
            width: 100%;
            float: left;
            max-height: 300px;
            overflow: auto;
            border: 1px solid #b1b1b1;
        }


        .ExRaten1 table {
            position: relative;
            width: 100%;
            overflow: hidden;
            border-collapse: collapse;
        }

        .ExRaten1 thead {
            position: relative;
            display: block;
            width: 100%;
            overflow: visible;
        }

            .ExRaten1 thead th {
                min-width: 90px;
            }


        .ExRaten1 tbody {
            position: relative;
            display: block; /*seperates the tbody from the header*/
            width: 100%;
            height: 440px;
            overflow: auto;
        }

            .ExRaten1 tbody td {
                min-width: 90px;
            }

        .ExRaten1 thead th:nth-child(4) {
            width: 113px !important;
        }

        .ExRaten1 thead th:nth-child(5) {
            width: 113px !important;
        }

        .ExRaten1 thead td:nth-child(4) {
            width: 111px !important;
        }

        .ExRaten1 thead td:nth-child(5) {
            width: 111px !important;
        }


        .TblGridEx {
            width: 49.5%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .TblGridEx1 {
            width: 39.5%;
            float: left;
            margin: 0px 0% 0px 0px;
        }

        .TblVerticalLine {
            border-right: 1px dotted #b1b1b1;
            width: 1px;
            float: left;
            margin: 0px 0.5% 0px 0.5%;
            min-height: 465px;
        }



        .upload_pnl {
           float: left;
    margin-top: 5px;
        }

        div#logix_CPH_Div1 {
            margin-top: 14px;
            margin-left: 7px;
        }

       div#logix_CPH_Div2 {
    margin-top: 14px;
}
        input#logix_CPH_ExrateUpload {
            padding: 8px;
            background: white;
            margin: 10px 0px 0px !important;
        }
        .gridHeight {
    height: 462px !important;
}
        .gridpnl {
    height: calc(100vh - 116px);
}
        .gridpnl1 {
    height: calc(100vh - 325px);
    overflow: auto;
    margin: 5px 0px;
}


        div#logix_CPH_div_iframe .widget-content {
    top: 0 !important;
    padding-top: 15px !important;
}
    </style>

  <%--   <script type="text/javascript">
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
    </script>--%>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">




    <!-- Breadcrumbs line End -->
    <div>
        <div class="col-md-12  maindiv">

            <div class="widget box" runat="server" id="div_iframe">
                <div class="widget-header">
                    <div>
                    <div style="float: left; margin: 0px 0.5% 0px 0px;">
                        <h4 class="hide"><i class="icon-umbrella"></i>
                            <asp:Label ID="lbl_Header" runat="server" Text="ExchangeRate"></asp:Label></h4>
                        <!-- Breadcrumbs line -->
                        <div class="crumbs">
                            <ul id="breadcrumbs" class="breadcrumb">
                                <li><i class="icon-home"></i><a href="#"></a>Home </li>
                                <li><a href="#" title="">Maintenance</a> </li>
                                <li class="current"><a href="#" title="">Exchange Rate</a> </li>
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

                    <div class="TblGridEx">
                        <div class="FormGroupContent4 boxmodal">
                            <div class="TypeDrop1">
                                <asp:DropDownList ID="droptype" runat="server" CssClass="chzn-select" data-placeholder="TYPE" ToolTip="Exchange Rate Type" OnSelectedIndexChanged="droptype_SelectedIndexChanged" TabIndex="1" AutoPostBack="True">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem>COST</asp:ListItem>
                                    <asp:ListItem>REVENUE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="DateInput4">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="Date" ToolTip="Exchange Rate Date" Enabled="false" OnTextChanged="txtDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="txtdatecalExd" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtDate"></ajaxtoolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="FormGroupContent4 boxmodal">
                            <div class="CurrencyInput">
                                <asp:TextBox ID="txtcurrency" runat="server" CssClass="form-control" MaxLength="3" ToolTip="CURRENCY" PlaceHolder="CURRENCY" AutoPostBack="True" OnTextChanged="txtcurrency_TextChanged" onKeyUp="CheckTextLength(this,5)"
                                    validationexpression="[0-9a-zA-Z' ']{5,}" TabIndex="2"></asp:TextBox>
                            </div>
                            <div class="Amount6">
                                <asp:TextBox ID="txtovers" runat="server" CssClass="form-control" ToolTip="RATE OVARSEAS" PlaceHolder="RATE OVARSEAS" onkeypress="return validateFloatKeyPress(this,event,'Currency');" OnTextChanged="txtovers_TextChanged" TabIndex="3" AutoPostBack="True"></asp:TextBox>
                            </div>
                            <div class="STInput">
                                <asp:TextBox ID="txt_ratelocal" runat="server" CssClass="form-control" ToolTip="RATELOCAL" PlaceHolder="RATELOCAL" onkeypress="return validateFloatKeyPress(this,event,'Currency');"
                                    OnTextChanged="txt_ratelocal_TextChanged" TabIndex="4" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="FormGroupContent4">
                            <div class="right_btn">
                                <div class="btn ico-save" id="btnSave1" runat="server">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" OnClick="btnSave_Click" OnClientClick="return validateEmpty();"
                                        TabIndex="5" />
                                </div>
                                <div class="btn ico-view">
                                    <asp:Button ID="btnview" runat="server" Text="View" ToolTip="View" OnClick="btnview_Click" TabIndex="6" />
                                </div>
                                <div class="btn ico-delete"   id="btnDelete_id" runat="server"  >
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" TabIndex="7" />
                                </div>
                                <div class="btn ico-back" id="btnClear1" runat="server">
                                    <asp:Button ID="btnClear" runat="server" Text="Cancel"  ToolTip="Cancel" OnClick="btnClear_Click" TabIndex="8" />

                                </div>
                            </div>
                        </div>
                        <div class="bordertopNew"></div>
                        <%--<div class="FormGroupContent4">
                  <div class="div_border">
                  <asp:GridView ID="GrdExrate" runat="server" Width="100%" ShowHeaderWhenEmpty="true" 
            AutoGenerateColumns="False" onpageindexchanged="GridView1_PageIndexChanged" CssClass="Grid FixedHeader" 
            onpageindexchanging="GridView1_PageIndexChanging" Visible="false">
             <Columns>
                 <asp:BoundField DataField="sno" HeaderText="S#" ItemStyle-HorizontalAlign="Right">
                     <ItemStyle Font-Bold="false" HorizontalAlign="Right"  />
                 </asp:BoundField>
                 <asp:BoundField DataField="extype" HeaderText="Type">
                  
                     <ItemStyle Font-Bold="false" HorizontalAlign="Right"  />
                 </asp:BoundField>
                 <asp:BoundField DataField="excurr" HeaderText="Currency">
               
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right" />
                  </asp:BoundField>
                 <asp:BoundField DataField="localexrate" HeaderText="LocalRate" ItemStyle-HorizontalAlign="Right">
                  
                     <ItemStyle Font-Bold="false" HorizontalAlign="Right"   />
                  </asp:BoundField>
                 <asp:BoundField DataField="osexrate" HeaderText="OversesRate" ItemStyle-HorizontalAlign="Right">
               
                    <ItemStyle Font-Bold="false" HorizontalAlign="Right"   />
                 </asp:BoundField>
             </Columns>
              <AlternatingRowStyle CssClass="GrdRowStyle" /> 
                <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
   
         </asp:GridView>
                      </div>
              </div>--%>
                        <div class="FormGroupContent4">
                            <div class="dldesign" id="drop_box" runat="server" visible="false">
                                <dl class="dropdown">
                                    <dt><a href="#"><span>Export To</span></a></dt>
                                    <dd>
                                        <ul>
                                            <%--     <li><a id="excel" runat="server" href="#">Excel</a></li>
                <li><a id="pdf" runat="server" href="#">Pdf</a></li>--%>

                                            <li>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnexcel_Click">Excel</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnpdf_Click">PDF</asp:LinkButton></li>

                                        </ul>
                                    </dd>
                                </dl>
                                <span id="result"></span>
                            </div>
                        </div>
                        <div class="FormGroupContent4" style="display: none;">

                            <div class="FormTxtDate">
                                <asp:TextBox ID="exdate" runat="server" placeholder="Date" AutoPostBack="true" Enabled="false" ToolTip="Date" CssClass="form-control"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="exdate" />
                            </div>


                        </div>
                        <hr />
                        <div class="FormGroupContent4">
                            <div class="FormTxtDate">
                                <asp:TextBox ID="txt_exdate" runat="server" placeholder="Date" AutoPostBack="true" ToolTip="Date" CssClass="form-control"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_exdate" />
                            </div>
                            <div class="upload_pnl">
                                <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Always" runat="server">
                                    <ContentTemplate>
                                        <span style="display: block; color: #fff; background-color: #5ba701; color: black; width: 121px; font-size: 11px; padding: 0px 0px 0px 0px;"></span>
                                        <asp:FileUpload ID="ExrateUpload" CssClass="bt" runat="server" />
                                        <div class="div_btn">
                                            <asp:Button ID="btn_Upload" runat="server" Text="Upload" Width="100%" CssClass="Button" Visible="false" />
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_AddUploaded" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%--  <asp:FileUpload ID="FileUpload1" runat="server" />--%>
                            </div>
                            <div class="btn ico-add" id="Div1" runat="server">
                                <asp:Button ID="btn_AddUploaded" runat="server"  Text="Add" ToolTip="Add" OnClick="btn_AddUploaded_Click"/> <%--OnClientClick="disableBtn(this.id, 'Loading...')"--%>
                            </div>
                            <div class="btn ico-get" id="Div2" runat="server">
                                <asp:Button ID="Btn_get" runat="server"  Text="Get" ToolTip="Get" OnClick="Btn_get_Click" />
                            </div>

                        </div>

                        <div class="FormGroupContent4">
                            <div class="gridpnl1">
                                <asp:GridView ID="GrdExrateFile" runat="server" CssClass="Grid FixedHeader" EmptyDataText="No Record Found" AutoGenerateColumns="false" OnRowDataBound="GrdExrateFile_RowDataBound"
                                    OnSelectedIndexChanged="GrdExrateFile_SelectedIndexChanged" Visible="true" OnRowCommand="GrdExrateFile_RowCommand" OnRowDeleting="GrdExrateFile_RowDeleting" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="EXRATEDATE" HeaderText="EXRATEDATE" Visible="False" />
                                        <asp:BoundField DataField="EXRATEFILE" HeaderText="EXRATEFILE" />
                                        <asp:BoundField DataField="MASTEREXRATEFILEUPLOADID" HeaderText="MASTEREXRATEFILEUPLOADID" Visible="False" />
                                        <asp:TemplateField HeaderText="DELETE">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Img_delete" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.jpg" Height="16px" OnClientClick="return confirm('Are you sure you want Delete');"  />
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>                                     

                                    </Columns>
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <HeaderStyle CssClass="" />
                                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                                <RowStyle CssClass="GrdRow" />
                                </asp:GridView>

                            </div>
                        </div>


                    </div>
                    <div class="TblVerticalLine hide"></div>
                    <div class="FormGroupContent4 boxmodal" style="width: 50%;">

                        <div class="gridpnl">
                            <asp:GridView ID="GridExrate" runat="server" AutoGenerateColumns="false" Height="100%" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader">
                                <%-- OnPreRender="GridExrate_PreRender"--%>


                                <Columns>

                                    <asp:TemplateField HeaderText="LocalExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="typecr" runat="server" Text='<%# Bind("extype") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="extype" HeaderText="ExType" Visible="false" />--%>
                                    <asp:BoundField DataField="extype1" HeaderText="Type" />
                                    <asp:BoundField DataField="exdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />


                                    <asp:BoundField DataField="excurr" HeaderText="ExCurrency" />



                                    <asp:TemplateField HeaderText="Local">
                                        <ItemTemplate>
                                            <asp:TextBox ID="Txt_LocalExRate" runat="server" CssClass="form-control" Text='<%# Bind("LoExRate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OS">
                                        <ItemTemplate>
                                            <asp:TextBox ID="Txt_OSExRate" runat="server" CssClass="form-control" Text='<%# Bind("OsExRate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Old_LocalExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="old_LocalExRate" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("localexrate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Old_OSExRate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="old_OSExRate" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("osexRate1") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                </Columns>
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <HeaderStyle CssClass="" />
                                <AlternatingRowStyle CssClass="GrdAltRow" />
                                <RowStyle Font-Italic="False" />
                            </asp:GridView>
                        </div>
                    </div>
</div>



                    <div class="FormGroupContent4">

                        <div class="TblGridEx1">

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="true" ShowHeaderWhenEmpty="True" CssClass="Grid FixedHeader"></asp:GridView>


                        </div>

                        <div class="FormGroupContent4">


                            <div class="right_btn">
                                <div class="btn ico-update">
                                    <asp:Button ID="btn_updrate" runat="server" Text="Update" ToolTip="Update_LORate" OnClick="btn_updrate_Click" />


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
                        <label id="lbl" runat="server">CURRENCY:</label>

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
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">

                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Height="100%" ShowHeaderWhenEmpty="True">

                        <%--  <Columns>
            <asp:BoundField DataField="extype" HeaderText="ExType" />
            <asp:BoundField DataField="excurr" HeaderText="ExCurrency" />
            <asp:BoundField DataField="exdate" HeaderText="ExDate" />

               <asp:TemplateField HeaderText="LocalExRate">
                     <ItemTemplate>
                     <asp:Textbox id="Txt_LocalExRate" runat="server" />
                     </ItemTemplate>
               </asp:TemplateField>
              <asp:TemplateField HeaderText="">
                     <ItemTemplate>
                     <asp:Textbox id="Txt_OSExRate" runat="server" />
                     </ItemTemplate>
               </asp:TemplateField>
              
              
         </Columns>--%>
                    </asp:GridView>



                </asp:Panel>




                <div class="Break"></div>
            </div>


        </asp:Panel>






    </div>
    <asp:Label ID="Label4" runat="server"></asp:Label>




    <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtenderlog" runat="server" PopupControlID="PanelLog"
        DropShadow="false" TargetControlID="Label4" CancelControlID="Image3" BehaviorID="Test1">
    </ajaxtoolkit:ModalPopupExtender>

    <%--OnPageIndexChanging="" OnRowCommand="" OnSelectedIndexChanged="" >--%>







    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />



    <asp:HiddenField ID="hid_ExrateId" runat="server" />
    <asp:HiddenField ID="hid_ExrateGrdid" runat="server" />
    <asp:HiddenField ID="Hid_ExrateFilename" runat="server" />
    <asp:HiddenField ID="Hid_ServerUsername" runat="server" Value="ifrtAdmin" />
    <asp:HiddenField ID="Hid_ServerPWD" runat="server" Value="05Jun!(&%" />


</asp:Content>
