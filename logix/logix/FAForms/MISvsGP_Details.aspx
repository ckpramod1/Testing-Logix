<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" 
    CodeBehind="MISvsGP_Details.aspx.cs" Inherits="logix.FAForms.MISvsGP_Details" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="KRI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="viewport" content="width=device-width,initial-scale=1.0" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <link href="../Theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Theme/bootstrap/css/bootstrap-select.css" />

    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />

    <!-- Theme -->
    <link href="../Theme/assets/css/system.css" rel="stylesheet" />
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../Theme/assets/css/new_style.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Theme/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Theme/assets/css/fontawesome/font-awesome.min.css" />
    <link href="../Theme/assets/css/systemFA.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
    <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css" />
    <!--=== JavaScript ===-->

    <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

    <!-- App -->
    <script type="text/javascript" src="../js/helper.js"></script>
    <script type="text/javascript" src="../js/TextField.js"></script> 
    <link rel="Stylesheet" href="../Styles/SampleDownload.css" type="text/css" /> 

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

    <link href="../CSS/Finance.css" rel="stylesheet" />
    <link href="../Styles/ControlStyle2.css" rel="stylesheet" />
    <link rel="Stylesheet" href="../Styles/TrialBalance.css" type="text/css" />
    <link href="../Styles/ProfitandLoss.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>



<style type="text/css">     

    table#logix_CPH_Grd_MisDetails {
        color: Black;
        background-color: White;
        width: 70%;
        border-collapse: collapse;
        top: 48px;
    }

    /*For Download Start*/
    button{
        background:none;
        border:none;
        color: #111;
        cursor:pointer;
        font-family : 'Roboto',Arial;
        font-size:14px;
        font-weight:500;
        height:30px;
        left:18%;
        outline:none;
        overflow:hidden;
        padding:0 10px;
        position:fixed;
        top:11%;
        transform:translate(-50%,-50%);
        width:190px;
        z-index:1;
    }

    button::before{
        background:rgb(255,255,255);
        box-shadow:20px 20px 48px #0e0e0e, -20px -20px 48px #141414;
        border-radius:50px;
        content:'';
        display:block;
        height:100%;
        margin:0 auto;
        position:relative;
        transition:width 0.2s cubic-bezier(0.39,1.86,0.64,1) 0.3s;
        width:100%
    }

    button.ready .submitMessage i{
        opacity:1;
        top:1px;
        transition:top .4s ease 600ms opacity .3s linear 600ms;
    }

    @keyframes fadeIn{
        from{
            opacity:0;
        }
        to{
            opacity:1;
        }
    }

    @keyframes loading{
        0%{
            cy:10;
        }
        25%{
            cy:10;
        }
        50%{
            cy:10;
        }
    }

    button.ready .loading::before{
        transition:width ease;
        width:80%;
    }

    button.loading .loadingMessage{
        opacity:1;
    }

    button.loading .loadingCircle{
        animation-duration:1s;
        animation-iteration-count:infinite;
        animation-name:loading;
    }

    .button-text.complete .submitMessage i{
        top:-30px;
    }

    /*For Download End*/
    .FixedButtonsss {
        top:12px !important;
    }
div#logix_CPH_Pnl_MisDetails table tbody tr:nth-child(1) {
    border-left: white !important;
    border-top: white !important;
}
div#logix_CPH_Pnl_MisDetails {
    margin-top: -19px !important;
}
div#logix_CPH_Pnl_MisDetails table tbody tr th:nth-child(2) {
    text-align: right;
}
div#logix_CPH_Pnl_MisDetails table tbody tr th:nth-child(3) {
    text-align: right;
}
</style>

<script type="text/javascript">
    // Define the clickbutton function
    function clickbutton() {
        const button = document.getElementById('button');
        button.classList.add('loading');
        button.classList.remove('ready');
        document.getElementById('default').style.display = "none";

        setTimeout(() => {
            button.classList.add('complete');
            button.classList.remove('loading');
            document.getElementById('success').style.display = "inline-block";

            setTimeout(() => {
                document.getElementById('default').style.display = "inline-block";
                document.getElementById('success').style.display = "none";
                button.classList.add('ready');
                button.classList.remove('complete');
            }, 5000);
        }, 3000);
    }
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

    
    <div class="col-md-12  maindiv">
        <div class="widget box" runat="server">
            <div class="widget-header" style="display:none;">
                <h4 class="hide"><i class="icon-umbrella"></i>
                    <asp:Label ID="lbl_MainHeader" runat="server" Text="MISvsGP_Details"></asp:Label>
                </h4>
                <!-- Breadcrumbs line -->
                <div class="crumbs">
                    <ul id="breadcrumbs1" class="breadcrumb">
                        <li><i class="icon-home"></i><a href="#"></a>Home </li>
                        <li><a href="#">Reports</a> </li>
                        <li><a href="#" title="">Profit and Loss Account</a> </li>
                        <li>
                            <asp:Label ID="lbnl_logyear" runat="server"></asp:Label></li>
                    </ul>
                </div>
                <div style="float: right; margin: 0px -0.5% 0px 0px;" class="log ico-log-sm" >
                    <asp:LinkButton ID="logdetails" runat="server" ToolTip="Log" Style="text-decoration: none" OnClick="logdetails_Click" Visible="false"></asp:LinkButton>
                </div>

            </div>

            <div class="widget-content">
                <div class="FormGroupContent4 FixedButtons">
                    <div class="right_btn">
                        <div class="btn ico-excel">
                            <asp:Button ID="btn_Export" runat="server" Text="Export" ToolTip="Export" OnClick="btn_Export_Click" />
                        </div>
                        <%--<div class="btn ico-cancel" id="btn_cancel1" runat="server">
                            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn_cancel_Click"/>
                        </div>--%>
                    </div>


                    <%--<button id="button" onclick="clickButton()">Download</button>
                    <div id="default">Click To Download</div>
                    <div id="success" style="display: none;">Downloaded Done</div>--%>

                    <%--<button id="button" class="ready" onclick="clickbutton();">
                        <div class="message submitMessage">
                            <i class="fa-american-sign-language-interpreting fa-download"></i>
                            <span class="button-text" id="default">Download Files</span>
                        </div>

                        <div class="message loadingMessage">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 19 17">
                                <circle class="loadingCircle" cx="2.2" cy="10" r="1.6" />
                                <circle class="loadingCircle" cx="9.5" cy="10" r="1.6" />
                                <circle class="loadingCircle" cx="16.8" cy="10" r="1.6" />
                            </svg>
                        </div>

                        <div class="message successMessage">
                            <i class="fa-american-sign-language-interpreting fa-check-circle show-tick"></i>
                            <span class="button-text" id="success">Downloaded</span>
                        </div>
                    </button>--%>


                </div>



                <%--<div class="container-fluid">
                <div class="vrow">
                    <div id="ms-container">
                        <label for="ms-download">
                            <div class="ms-content">
                                <div class="ms-content-inside">
                                    <input type="checkbox" id="ms-download" />
                                    <div class="ms-line-down-container">
                                        <div class="ms-line-down"></div>
                                    </div>
                                    <div class="ms-line-point"></div>
                                </div>
                            </div>
                        </label>
                    </div>
                </div>
            </div>--%>


                <div class="FormGroupContent4">
                    <asp:Panel ID="Pnl_MisDetails" runat="server">
                        <asp:GridView ID="Grd_MisDetails" runat="server" AutoGenerateColumns="false" ForeColor="Black" Width="100%" CssClass="Grid FixedHeader"  
                            EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="Grd_MisDetails_RowDataBound" 
                            OnSelectedIndexChanged="Grd_MisDetails_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="Particulars" DataField="ctype" />
                                <asp:BoundField HeaderText="Amount" DataField="amount" />
                                <asp:BoundField HeaderText="NetAmount" DataField="net" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                            <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                            <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>

                        <asp:GridView ID ="grdjob" runat="server" AutoGenerateColumns="true" ForeColor="Black" Width="100%" CssClass="Grid FixedHeader"  
                            EmptyDataText="No Record Found" BackColor="White" ShowHeaderWhenEmpty="true" OnRowDataBound="grdjob_RowDataBound" style="display:none;" >
                            <Columns>

                            </Columns>
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" Wrap="false" />
                            <HeaderStyle CssClass="myGridHeader" Wrap="false" />
                            <AlternatingRowStyle CssClass="GrdAltRow" Wrap="false" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>

                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>
    

</asp:Content>
