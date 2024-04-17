<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" CodeBehind="Mastercustomertds.aspx.cs" Inherits="logix.Maintenance.Mastercustomertds" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />--%>
    <!-- Bootstrap -->
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
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" />
    <link href="../Styles/slotRateMaster.css" rel="stylesheet" />
    <link href="../Theme/assets/css/systemhomedesign.css" rel="stylesheet" />
    <link href="../Styles/MRG.css" rel="stylesheet" />
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
    <script src="../Theme/Content/assets/js/canvasjs.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridviewScroll.css" rel="stylesheet" />
    <link href="../Styles/button1.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/new_style_responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/system.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/ContainerTracking.css" rel="stylesheet" />
    <script src="../js/helper.js" type="text/javascript"></script>
    <script src="../js/TextField.js" type="text/javascript"></script>
    <%--TEST--%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../Theme/assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />

    <script type="text/javascript">
        function dropdownButton() {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>


    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../Styles/Chosenlogin.css" rel="stylesheet" />
    <link href="../Styles/DropDownButton.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }

    </script>
    <%--   <script type="text/javascript">
         $(function () {
             $("Grd_MAsterCredit. > tbody > tr:not(:has(table, th))")
                 .css("cursor", "pointer")
                 .click(function (e) {
                     $(".Grd_MAsterCredit td").removeClass("highlite");
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
    <style>
        .CardLbl {
            padding: 5px 0 0 5px;
        }

        .Gridpnl {
            width: 99% !important;
            height: 97%;
            border: 1px solid var(--lightgrey) !important;
            margin: 0 auto !important;
            overflow-x: auto !important;
        }
    

        div#logix_CPH_plblan {
            margin: 15px 0px 0px 6px;
        }

        .CustomerName12 {
            float: left;
            margin: 15px 0.5% 14px 4px;
        }

        span.headingName {
            font-weight: bold !important;
        }
        
     
        .description{
            width:100%;
            float:left;
            margin:0px 0.5% 0px 0px;
        }
        .type{
              width:100%;
  float:left;
  margin:0px 0.5% 0px 0px;
        }
        .slab{
       width:100%;
float:left;
margin:0px 0.5% 0px 0px;
            }


         .percentage{
     width:50%;
     float:left;
     margin:0px 0.5% 0px 0px;
 }
   .limit {
    width: 49.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
                 
 .exemptionfrom{
    width:50%;
    float:left;
    margin:0px 0.5% 0px 0px;
}
.exemptionto {
    width: 49.5%;
    float: left;
    margin: 0px 0px 0px 0px;
}
        .certificate{
    width:100%;
    float:left;
    margin:0px 0.5% 0px 0px;
}
                .tdsexemption{
    width:100%;
    float:left;
    margin:0px 0.5% 0px 0px;
}
.left_btn {
    float: left;
    margin: 17px 0px 0px 20%;
}
 
.PageHeight {
    padding-top: 0px !important;
}
.chzn-drop {
    width: 100% !important;
    min-height: 150px !important;
    max-height: fit-content !important;
    height: 276px !important;
    overflow: auto;
}

   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    <asp:Panel ID="pnl_emp1" runat="server" Width="100%" Height="100%" CssClass="">
        <div class="FormGroupContent4 boxmodal">
            <div class="CardLbl">
                <asp:Label ID="Label54" runat="server" class="headingName">TDS Details </asp:Label>
            </div>
            <div class="FormGroupContent4 ">
                <div class="panno12" id="plblan" runat="server">
    <span class="headingName">PAN #       :</span>
    <asp:Label ID="lblpanno" runat="server"></asp:Label>
</div>
            </div>
            <div class="FormGroupContent4 ">
                <div class="CustomerName12">
                    <span class="headingName">CUSTOMER NAME :</span>
                    <asp:Label ID="lblcustomername" runat="server"> </asp:Label>
                </div>
                
            </div>
                 <div class="bordertopNew" style=" float: right;min-height: 1px;width: 100%;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;" ></div>
            <div class="FormGroupContent4">
                <div class="description">
                    <asp:Label ID="Label33" runat="server" Text="Description"> </asp:Label>
                    <asp:DropDownList ID="ddl_description" Height="23px" CssClass="chzn-select" TabIndex="47" data-placeholder="Description" ToolTip="Descripttion" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_description_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                </div>

            <div class="FormGroupContent4">
                <div class="type">
                    <asp:Label ID="Label34" runat="server" Text="Type"> </asp:Label>
                    <asp:DropDownList ID="ddl_type" runat="server" Height="23px" CssClass="chzn-select" TabIndex="48" data-placeholder="Type" ToolTip="Type" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                </div>

            <div class="FormGroupContent4">
                <div class="slab">
                    <asp:Label ID="Label35" runat="server" Text="Slab"> </asp:Label>
                    <asp:DropDownList ID="ddl_slab" Height="23px" runat="server" CssClass="chzn-select" TabIndex="49" data-placeholder="Slab" AutoPostBack="true" ToolTip="Slab" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_slab_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                </div>


            <div class="FormGroupContent4">

                <div class="percentage">
                    <asp:Label ID="Label36" runat="server" Text="Percentage"> </asp:Label>
                    <asp:DropDownList ID="ddl_percentage" Height="23px" CssClass="chzn-select" TabIndex="50" data-placeholder="Percentage" ToolTip="Percentage" runat="server" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </div>
                <div class="limit">
                    <asp:Label ID="Label40" runat="server" CssClass="hide" Text="LIMIT"> </asp:Label>
                    <asp:TextBox ID="txt_limit" runat="server" placeholder="LIMIT" ToolTip="LIMIT" TabIndex="51" CssClass="form-control"></asp:TextBox>
                </div>
               
                </div>
            <div class="FormGroupContent4">
                 <div class="exemptionfrom">
     <asp:Label ID="Label41" runat="server" CssClass="hide" Text="Exemption From"> </asp:Label>
     <asp:TextBox ID="txt_empfrom" runat="server" CssClass="form-control" TabIndex="52" placeholder="Exemption From" ToolTip="Exemption From"></asp:TextBox>

     <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empfrom" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
 </div>
 <div class="exemptionto">
     <asp:Label ID="Label42" runat="server" CssClass="hide" Text="Exemption To"> </asp:Label>
     <asp:TextBox ID="txt_empto" runat="server" CssClass="form-control" TabIndex="53" placeholder="Exemption To" ToolTip="Exemption To"></asp:TextBox>

     <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empto" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
 </div>
            </div>
            <div class="FormGroupContent4">
                <div class="tdsexemption">
    <asp:Label ID="Label44" runat="server" CssClass="hide" Text="TDS Exemption"> </asp:Label>
    <asp:TextBox ID="txt_tds_exp" runat="server" CssClass="form-control" placeholder="TDS Exemption" TabIndex="55" ToolTip="TDS Exemption"></asp:TextBox>
</div>
            
            </div>

            <div class="FormGroupContent4">
                <div class="certificate">
                    <asp:Label ID="Label43" runat="server" CssClass="hide" Text="Certificate #"> </asp:Label>
                    <asp:TextBox ID="txt_certno" runat="server" placeholder="Certificate #" TabIndex="54" ToolTip="Certificate Number" CssClass="form-control"></asp:TextBox>
                </div>

                
                </div>


            <%--                                        <div class="FormGroupContent4">

                                            <div class="TDSDescription">
                                                <asp:Label ID="Label33" runat="server" CssClass="hide" Text="Description"> </asp:Label>
                                                <asp:DropDownList ID="ddl_description" Height="23px" CssClass="chzn-select" TabIndex="47" data-placeholder="Description" ToolTip="Descripttion" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_description_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="CusTypeDrop3">
                                                <asp:Label ID="Label34" runat="server" CssClass="hide" Text="Type"> </asp:Label>
                                                <asp:DropDownList ID="ddl_type" runat="server" Height="23px" CssClass="chzn-select" TabIndex="48" data-placeholder="Type" AutoPostBack="True" ToolTip="Type" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="CusDrop1">
                                                <asp:Label ID="Label35" runat="server" CssClass="hide" Text="Slab"> </asp:Label>
                                                <asp:DropDownList ID="ddl_slab" Height="23px" runat="server" CssClass="chzn-select" TabIndex="49" data-placeholder="Slab" ToolTip="Slab" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_slab_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="CusPerDrop">
                                                <asp:Label ID="Label36" runat="server" CssClass="hide" Text="Percentage"> </asp:Label>
                                                <asp:DropDownList ID="ddl_percentage" Height="23px" CssClass="chzn-select" TabIndex="50" data-placeholder="Percentage" ToolTip="Percentage" runat="server" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="FormGroupContent4">
                                            <div class="Limit">
                                                <asp:Label ID="Label40" runat="server" CssClass="hide" Text="LIMIT"> </asp:Label>
                                                <asp:TextBox ID="txt_limit" runat="server" placeholder="LIMIT" ToolTip="LIMIT" TabIndex="51" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="empfrom">
                                                <asp:Label ID="Label41" runat="server" CssClass="hide" Text="Exemption From"> </asp:Label>
                                                <asp:TextBox ID="txt_empfrom" runat="server" CssClass="form-control" TabIndex="52" placeholder="Exemption From" ToolTip="Exemption From" AutoPostBack="True"></asp:TextBox>

                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empfrom" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>
                                            <div class="empto">
                                                <asp:Label ID="Label42" runat="server" CssClass="hide" Text="Exemption To"> </asp:Label>
                                                <asp:TextBox ID="txt_empto" runat="server" CssClass="form-control" TabIndex="53" placeholder="Exemption To" ToolTip="Exemption To" AutoPostBack="True"></asp:TextBox>

                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_empto" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                            </div>

                                            <div class="certno">
                                                <asp:Label ID="Label43" runat="server" CssClass="hide" Text="Certificate #"> </asp:Label>
                                                <asp:TextBox ID="txt_certno" runat="server" placeholder="Certificate #" TabIndex="54" ToolTip="Certificate Number" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>

                                            <div class="tds_exp">
                                                <asp:Label ID="Label44" runat="server" CssClass="hide" Text="TDS Exemption"> </asp:Label>
                                                <asp:TextBox ID="txt_tds_exp" runat="server" CssClass="form-control" placeholder="TDS Exemption" TabIndex="55" ToolTip="TDS Exemption" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </div>--%>
        </div>
        <div class="right_btn">
            <%-- <div class="btn ico-save" id="btnpanadd1" runat="server">
                            <asp:Button ID="btnpanadd" runat="server" ToolTip="Add" OnClick="btnpanadd_Click" TabIndex="56" />
                        </div>--%>

            <div class="btn ico-save">
                <asp:Button runat="server" ID="btnsave" ToolTip="Save" TabIndex="57" OnClick="btnsave_Click" />
            </div>

            <div class="btn ico-cancel" id="btnBack1" runat="server">
                <asp:Button ID="btnpancancel" runat="server" ToolTip="Cancel" TabIndex="58" OnClick="btnpancancel_Click" /><%--OnClick="btnpancancel_Click"--%>
            </div>

        </div>
    </asp:Panel>

    <asp:HiddenField ID="hid_type" runat="server" />
    <asp:HiddenField ID="hidpaninput" runat="server" />
</asp:Content>

