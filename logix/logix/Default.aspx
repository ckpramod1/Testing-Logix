<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="logix.Default" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>logix</title>
    <link href="Style/Controls.css" rel="stylesheet" type="text/css" />
    <link href="Theme/assets/css/cscss.css" rel="stylesheet" />
    
    <link href="Styles/ControlStyle2.css" rel="stylesheet" />
    <link href="Theme/assets/css/buttonicon.css" rel="stylesheet" />
     <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <style type="text/css">
        body {
            font-size: 13px;
            font-family: 'Segoe UI';
        }

        .ContainerPopupdiv {
            /*height: 241px;
            border-collapse: collapse;
            overflow: auto;*/
            border: 1px solid #b1b1b1;
            margin: 48px 0px 0px 0px;
            width: 467px;
            background-color: #fff;
            height: 233px;
            padding: 0px 5px 5px;
        }


            .ContainerPopupdiv h4 {
                color: brown;
                font-size: 13px;
                font-family: 'Segoe UI';
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                width: 20%;
                float: left;
            }

            .ContainerPopupdiv label {
                color: brown;
                display: inline-block;
                font-size: 13px;
                font-family: 'Segoe UI';
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                width: 31%;
                float: left;
            }


                .ContainerPopupdiv label.lblDate {
                    color: brown;
                    display: inline-block;
                    font-size: 13px;
                    font-family: 'Segoe UI';
                    padding: 3px 3px 3px 3px;
                    margin: 0px 0px 0px 0px;
                    width: auto;
                    float: left;
                }


            .ContainerPopupdiv span#SpanBookingNo {
                display: inline-block;
                float: left;
                width: 23%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }

            .ContainerPopupdiv span#SpanDate {
                display: inline-block;
                float: left;
                width: 18%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }




            .ContainerPopupdiv span {
                display: inline-block;
                float: left;
                width: 32%;
                padding: 3px 3px 3px 3px;
                margin: 0px 0px 0px 0px;
                color: #4e4e4c;
                font-size: 13px;
            }
            .modalPopupss1 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            /*border-style:solid; 
            border-color:#CCCCCC;*/
            width: 1027px;
            Height: 405px;
            margin-top: -2.5%;
            margin-left: -0.2%;
            border:1px solid #b1b1b1;
            /*padding:1px;
            margin-left:-4%;
            display:none;*/
        }



             .modalPopupssn1 {
            background-color: #FFFFFF;
            /*border-width:1px;*/
            /*border-style:solid; 
            border-color:#CCCCCC;*/
            width: 1027px;
            Height: auto;
            margin-top: -2.5%;
            margin-left: -0.2%;
            /*padding:1px;
            margin-left:-4%;
            display:none;*/
        }

            .Gridpnl {
            width: 1029px;
            Height: 410px;
            margin-bottom: 0.5%;
            margin-left: 0%;
            /*margin-left:0.2%;
            overflow-y :scroll;*/
            overflow: hidden;
        }


            .frames {
    width: 1030px;
    height: 409px;
    overflow: hidden;
}

        .row {
            height:413px !important;
        }

        #popupfro {
            top:216px!important; left:22px!important;
        }
        /*POPUP CSS*/
        .modalPopupss {
            background-color: #FFFFFF;
            border: 1px solid #b1b1b1;
            /* width: 1062px; */
            width: 99.5%;
            height: 566px;
            margin-left: 0%;
            margin-top: -0.9%;
        }

        .DivSecPanelLog img {
            float: right;
            width: 16px !important;
            height: 16px !important;
        }

        .DivSecPanel {
            width: 20px;
            Height: auto;
            border: 0px solid white;
            margin-left: 96%;
            margin-top: -2.3%;
            border-radius: 90px 90px 90px 90px;
                position: absolute;
    z-index: 9999;
    top: 4%;
        }


                .DivSecPaneln {
            width: 20px;
            Height: auto;
            border: 0px solid white;
            margin-left: 97%;
            margin-top: 0.4%;
            margin-bottom:2.5%;
            border-radius: 90px 90px 90px 90px;
        }


                 .DivSecPaneln img {
            float: right;
            width: 16px !important;
            height: 16px !important;
        }


        .GridViewTbln1 {
            width: 96%;
            float: left;
            margin: 5px 0px 0px 0px;
        }

        #DivCount {
            width: 100%;
            float: left;
            height: 160px;
            overflow: auto;
        }

        #DivGrdInfo {
            width: 96%;
            float: left;
            height: 240px;
            margin-top: 5px;
            overflow-x: auto;
            overflow-y: hidden;
            background-color: #fff;
        }

        #Divbooking {
            width: 96%;
            float: left;
            height: 240px;
            margin-top: 5px;
            overflow-x: auto;
            overflow-y: hidden;
            background-color: #fff;
        }

        .Hiden1 {
            display: none !important;
        }

        .table-fixed thead {
            float: left;
            display: block;
            width: 546px;
        }

        .table-fixed tbody {
            height: 213px;
            overflow-y: auto;
            width: 546px;
            overflow-x: hidden;
        }

        .table-fixed thead, .table-fixed tbody, .table-fixed tr, .table-fixed td, .table-fixed th {
            display: inline-block;
        }

            .table-fixed tbody td {
                float: left;
                border-bottom-width: 0;
                display: block;
                /*border-left:0px solid #000;
                border-right:0px solid #000;
                border-top:0px solid #000;*/
            }

            .table-fixed thead > tr > th {
                float: left;
                /*border-bottom-width: 0;*/
                display: block;
            }

                .table-fixed thead > tr > th:last-child {
                    float: left;
                }

            .table-fixed tbody td:last-child {
                float: left;
            }

            .table-fixed tbody td:last-child {
                float: left;
            }

                .table-fixed tbody td:last-child::after {
                    clear: both;
                }



        .Grid {
            border: 0px solid #fff;
        }

        #Div_NoOf_Container {
            left: 669px !important;
            top: 280px !important;
        }

        .XLIcon {
            float: right;
            margin: 0px -3px 4px 0px;
        }

        .XLIcon1 {
            float: right;
            margin: 5px -3px -3px 0px;
            width: 9%;
        }

        #ifrmaster {
            width: 1029px;
            margin: 0px 10px 0px 20px;
            height: 412px;
        }

        .QuickViewLeft {
            margin-left: 0px;
        }

        .PolWdth {
            width: 90px !important;
        }

        .PodWidth {
            width: 90px !important;
        }

        .LblHead {
            font-size: 13px;
            color: #fff;
            padding: 2px 0px 2px 0px;
            float: left;
            font-weight: bold;
            margin: 10px 0px 0px 5px;
            font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
        }

        .GridMt1 {
            margin-bottom: 5px;
            margin-top: 5px;
        }

        .BookingTxtBox1 {
            width: 83%;
            float: left;
            margin: 11px 15px 0px 0px;
        }

        input[type="search"] {
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            -webkit-appearance: textfield;
        }

        .PendingRightnewLRightNew1 {
            float: left;
            width: 510px;
            margin: 60px 0px 0px 18px;
        }
        .PendingRightnewLRightNew {
            float: left;
            width: 510px;
            margin: 60px 0px 0px 18px;
        }

         .PendingRightnewLRightNewn1 {
            float: right;
            width: 470px;
            margin: -25px 0px 0px 18px;
        }

        #chart_divbar svg > rect {
            fill:#fff;
            width:100px!important;
        }

        #chart_divbar svg > rect {
            color:#fff;
        }
        rect[Attributes Style] {
            fill:rgb(255,255,255);
        }


        #chartdiv1 {
            float:right;
            margin:0px 15px 0px 15px;
        }

        #chartdiv1 svg > rect {
            fill:#fff;

        }
        .btn-get1 input {
            padding:5px 0px 22px 28px;
        }
        .div_Grid {
            width:50%;
            float:left;
            margin:0px 0px 0px 0px;
            padding:10px 10px 10px 20px;           
           height:385px;
            border:0px solid #003166;
        }

        .Gridn2 {
    width: 100%;
    border: 1px solid #b1b1b1;
    margin: 0px 0px 0px 0px;
    overflow-x: hidden !important;
    overflow-y: auto !important;
    background-color: #fff;
}
        .Gridn2 td {
    border-right: 1px solid #003166;
    border-top: 1px solid #003166;
    border-left: 1px solid #003166;
    font-size: 14px;
    text-align: left;
    font-family: tahoma;
    padding: 15px 20px 15px 20px!important;
    margin: 0px;
    color: #4e4c4c;
    border-bottom: 1px solid #003166;
}
        .Gridn2 th {
    background-color: #05467e !important;
    border-right: 1px solid #003166;
    border-top: 1px solid #003166;
    border-bottom: 1px solid #003166;
    border-left: 1px solid #003166;
    font-family: tahoma;
    padding: 15px 20px 15px 20px;
    font-size: 14px;
    color: #ffffff !important;
}





        .GrdAltRow {
            border:0px solid #000;
        }
        .BookingHead span {
    margin: 0px 0px 10px 0px;   
    padding: 3px 0px 8px 20px;
    color: #000;   
    width: 94%;
    font-size: 15px;
    font-weight: normal;
    font-family:'Segoe UI';
}


        .GridBorder1 {
            width:100%;
            border:0px solid #003166;
            height:356px;
            overflow:auto;
            margin-top:5px;
        }

        .div_Gridn {
    width: 96.5%;
    float: left;
    margin: 0px 0px 0px 0px;
    padding: 10px 10px 10px 20px;
    height: 368px;
    border: 0px solid #003166;
}

        .Hiden {
            display:none;
        }

        .GridBorder1 td a {
            color:navy!important;
            text-decoration:none!important;
        }
        #Paneln2 {
            left:20px!important; top:215px!important;
        }

        /*.Grid th:first-child {
            border-left:0px solid #000;
        }
          .Grid td:first-child {
            border-left:0px solid #000;
        }
           .Grid th:last-child {
            border-right:0px solid #000;
        }
          .Grid td:last-child {
            border-right:0px solid #000;
        }*/


           #logix_CPH_ddlEvents_chzn {
            width: 100% !important;
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
                font-size: 11px;
            }



        .LogHeadJob {
            width: auto;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
        }


        .LogHeadJobInput {
            width: 15%;
            float: left;
            margin: 1px 0.5% 0px 0px;
        }

            .LogHeadJobInput span {
                color: #1a65af;
                font-size: 11px;
                margin: 4px 0px 0px 0px;
            }


        .EventsDrop {
            width: 19%;
            float: left;
            margin: 0px;
        }

        .LogHeadJobInput label {
            font-size: 11px;
            font-family: sans-serif;
            color: #4e4e4c;
        }

        .MawblCal {
            width: 6%;
            float: right;
            margin: 0px 0% 0px 0px;
        }

        span#logix_CPH_mailcontent {
            width: 1044px;
            margin: 0px auto;
            padding: 10px;
            border: 1px solid #000;
            background-color: #fff;
            z-index: 9999;
            position: absolute;
            left: 14%;
            overflow: auto;
            top: 1%;
            height: 549px;
        }

        .MT15 {
            margin: 15px 0px 0px 0px;
        }

        
        .chzn-drop {
            height: 180px !important;
        }

        .chzn-container-single .chzn-single span {
            color: #000 !important;
        }

        table#logix_CPH_grd {
            margin: 0.5% 0px;
        }
        .gridpnl {
    height: calc(100vh - 200px);
}
        .Product{
              width: 18%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
  .Job{
              width: 19%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
    .Booking{
              width: 19%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
      .Container{
              width: 19%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
        .Customer{
              width: 19%;
            float: left;
            margin: 0px 0.5% 0px 0px;
        }
       


    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
               
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: 'Default.aspx/GetChartDataBooking',
                    data: '{}',
                    success:
                    function (response) {
                        drawchart(response.d);
                    },

                    error: function () {
                        alertify.alert("Error loading data! Please try again.");
                    }
                });
            })
           
        })

        //function drawchart(dataValues) {
        //    var data = new google.visualization.DataTable();
        //    data.addColumn('string', 'Column Name');
        //    data.addColumn('number', 'Column Value');
        //    if (dataValues.length != 0) {
        //        for (var i = 0; i < dataValues.length; i++) {
        //            data.addRow([dataValues[i].Countryname, dataValues[i].Total]);
        //        }

        //        new google.visualization.PieChart(document.getElementById('chartdiv1')).
        //        draw(data, { title: "Booking" });
        //    }
        //}
        function drawchart(dataValues) {

            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Column Name');

            data.addColumn('number', 'Column Value');

            for (var i = 0; i < dataValues.length; i++) {

                data.addRow([dataValues[i].Countryname, dataValues[i].Total]);

            }

            new google.visualization.PieChart(document.getElementById('chartdiv1')).
                                       draw(data, { title: "Booking" });

        }



    </script>
    
   
  <script type="text/javascript">
      function pageLoad(sender, args) {
          $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });


      }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="float: left; border-right: 2px dotted #000; width: 77.5%; margin: 15px 0px 15px 0px; min-height: 555px;">


            
                    <div class="FormGroupContent4">
                         <div class="Product">
                              <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label>
                             <asp:DropDownList ID="ddl_product"  runat="server" data-placeholder="Product" ToolTip="Product" AutoPostBack="true"  CssClass="chzn-select"   OnSelectedIndexChanged="ddl_product_SelectedIndexChanged">                                                                                                            
                                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                   <asp:ListItem Value="AE" Text="AIR EXPORTS"></asp:ListItem>
                                   <asp:ListItem Value="AI" Text="AIR IMPORTS"></asp:ListItem>
                                   <asp:ListItem Value="FE" Text="OCEAN EXPORTS"></asp:ListItem>
                                   <asp:ListItem Value="FI" Text="OCEAN IMPORTS"></asp:ListItem>
                                 </asp:DropDownList>
                              </div>
                         <div class="Job">
                             <asp:Label ID="Label32" runat="server" Text="Job #"></asp:Label>
                                    <asp:TextBox ID="txt_job" runat="server"  CssClass="form-control" ToolTip="Job #" OnTextChanged="txt_job_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                         <div class="Booking">
                             <asp:Label ID="Label2" runat="server" Text="Booking #"></asp:Label>
                                   
                              <asp:DropDownList ID="txt_booking" runat="server" CssClass="form-control"   ToolTip="Booking #" AutoPostBack="true" OnSelectedIndexChanged="txt_booking_TextChanged">
                              <asp:ListItem Value="0" Text=""></asp:ListItem>

                             </asp:DropDownList>
                               </div>
                         <div class="Container">
                             <asp:Label ID="Label3" runat="server" Text="Container #"></asp:Label>
                                    <asp:DropDownList ID="txt_container" runat="server" CssClass="form-control"   ToolTip="Container #" AutoPostBack="true" OnSelectedIndexChanged="txt_bl_TextChanged"> <asp:ListItem Value="0" Text=""></asp:ListItem>

                             </asp:DropDownList>
                                </div>
                        <div class="Customer">
                             <asp:Label ID="Label4" runat="server" Text="Customer"></asp:Label>
                                    <asp:DropDownList ID="txt_customer" runat="server" CssClass="form-control"   ToolTip="Customer" AutoPostBack="true" OnSelectedIndexChanged="txt_customer_TextChanged"> <asp:ListItem Value="0" Text=""></asp:ListItem>

                             </asp:DropDownList>
                                </div>


                   
                        <div class="right_btn">
                            <%--<div class="btn ico-update" id="visblehid">
                                <asp:Button ID="btn_update" runat="server" ToolTip="Update" OnClick="btn_update_Click" />
                            </div>--%>
                            <div class="btn ico-cancel" id="btn_cancel1" runat="server">
                                <asp:Button ID="btn_Cancel" runat="server" ToolTip="Cancel/Back" OnClick="btn_Cancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="FormGroupContent4" >
                        <div class="gridpnl">
                      <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" Width="100%"
                                            ShowHeaderWhenEmpty="True" EnableTheming="False" OnPreRender="grd_PreRender">
                            

                               <Columns>
                                   <%--<asp:TemplateField HeaderText="Sl #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>--%>
                                    <asp:BoundField DataField="product" HeaderText="Product">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="bookingno" HeaderText="Booking #">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="blno" HeaderText="Bl #">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="containerno" HeaderText="Container #">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="jobno" HeaderText="Job #">
                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                </asp:BoundField>
                                      <asp:BoundField DataField="lastevent" HeaderText="Last Event">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="lasteventupdatedon" HeaderText="Last Event updated On" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundField>
                            

                                     <asp:BoundField DataField="NextEvent" HeaderText="Next Event" >
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundField>

                                  <asp:BoundField DataField="noofdays" HeaderText="Next event Due days" >
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundField>

                                   

                                     
                               

                             </Columns>
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <HeaderStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="GrdAltRow" />
                                            <RowStyle CssClass="GrdRow" />
                                        </asp:GridView>
                            </div>
                                   
                                </div>
                   

                     
            <div class="HomeMenu" style="display: none;" >
                <h3>Shipment Details</h3>
                <div style="display: none;">
                    <div class="Booking">
                        <asp:LinkButton ID="bookingic" runat="server" Text="Booking" OnClick="bookingic_Click" target='frmContent'>         

                <div class="BookingIc">
                    Booking

                </div>          

                        </asp:LinkButton>
                    </div>
                    <div class="EblC">

                        <asp:LinkButton ID="lnk_eBL" runat="server" Text="e-BL" OnClick="lnk_eBL_Click" target='frmContent'>
                    <div class="Ebl">
                        e-BL

                    </div>
                        </asp:LinkButton>
                    </div>
                    <div class="ChangePassC">
                        <asp:LinkButton ID="lnk_chgpwd" runat="server" Text="Receipts" OnClick="lnk_chgpwd_Click" target='frmContent'>
                    <div class="ChangePass">
                       Change Password

                    </div>
                        </asp:LinkButton>
                    </div>
                </div>
                <div style="clear: both;"></div>

                <div class="HomeMenuleft"  style="display: none;">
                    <div class="OceanExportc1">
                        <asp:LinkButton ID="lnk_OceanExpor" runat="server" Text="Ocean Export" OnClick="lnk_OceanExpor_Click" target='frmContent'>
       
           
                <div class="OceanExport">
                    Ocean Export
                </div>
                        </asp:LinkButton>
                    </div>

                    <div class="OceanImportC1">
                        <asp:LinkButton ID="lnk_OceanImport" runat="server" Text="Ocean Import" OnClick="lnk_OceanImport_Click" target='frmContent'>
          
               
                    <div class="OceanImport">
                        Ocean Import
                    </div>
                
       
                        </asp:LinkButton>
                    </div>
                    <div class="AirExportC1">
                        <asp:LinkButton ID="lnk_AirExport" runat="server" Text="Air Export" OnClick="lnk_AirExport_Click" target='frmContent'>
          
         
                
                    <div class="AirExport">
                        Air Export
                    </div>
                        </asp:LinkButton>
                    </div>
                    <div class="AirImportC1">
                        <asp:LinkButton ID="lnk_AirImport" runat="server" Text="Air Import" OnClick="lnk_AirImport_Click" target='frmContent'>
          

                    <div class="AirImport">
                        Air Import
                    </div>
                        </asp:LinkButton>
                    </div>



                     <div class="CHAC">
                        <asp:LinkButton ID="lnk_CHA" runat="server" Text="CHA"  target='frmContent' OnClick="lnk_CHA_Click" > 
                    <div class="CHA">
                      CHA

                    </div>
                        </asp:LinkButton>
                    </div>

                     <div class="Clear"></div> 
                    <div class="EbookingC">
                        <asp:LinkButton ID="lnk_ebooking" runat="server" Text="E-Booking" OnClick="lnk_ebooking_Click" target='frmContent'>
                    <div class="Ebooking">
                       e-Booking

                    </div>
                        </asp:LinkButton>
                    </div>
                        <div class="PODetailsC">
                        <asp:LinkButton ID="lnk_PO" runat="server" Text=" PO Details" OnClick="lnk_PO_Click" target='frmContent'>
                    <div class="PoDetails">
                       PO Details

                    </div>
                        </asp:LinkButton>
                    </div>

                    <div class="InvoiceC1">
                        <asp:LinkButton ID="lnk_InvocieDebitNote" runat="server" Text="Invocie/Debit Note" OnClick="lnk_InvocieDebitNote_Click" target='frmContent'>
                    <div class="Invocie">
                       Invoice / BOS

                    </div>
                        </asp:LinkButton>
                    </div>
                   

                    <div class="ReceiptC">
                        <asp:LinkButton ID="lnk_Receipts" runat="server" Text="Receipts" OnClick="lnk_Receipts_Click" target='frmContent'>
                    <div class="Receipt">
                       Receipts

                    </div>
                        </asp:LinkButton>
                    </div>

                    <div class="LedgerC">
                        <asp:LinkButton ID="lnk_Ledger" runat="server" Text="Receipts" OnClick="lnk_Ledger_Click" target='frmContent'>
                    <div class="Ledger">
                       Ledger

                    </div>
                        </asp:LinkButton>
                    </div>





                    
                


                    <div class="OutStandingC" style="display: none;">
                        <asp:LinkButton ID="lnk_Outstanidng" runat="server" Text="Receipts" OnClick="lnk_Outstanidng_Click" target='frmContent'>
                    <div class="OutStanding">
                       Outstanding

                    </div>
                        </asp:LinkButton>
                    </div>
                    <div style="clear: both;"></div>

                </div>

            </div>


            <div class="RightSideMenu"  style="display: none;">

                <h3>Quick View</h3>

                <div class="QuickViewLeft">
                    <div class="OceanExportc">
                        <asp:LinkButton ID="linkFE" runat="server" OnClick="linkFE_Click">
                <div class="OceanExport">
                    Ocean Export
                </div>
                        </asp:LinkButton>
                    </div>



                    <div class="OceanImportC">
                        <asp:LinkButton ID="linkFI" runat="server" OnClick="linkFI_Click">
                <div class="OceanImport">
                    Ocean Import
                </div>
                        </asp:LinkButton>


                    </div>


                    <div class="AirExportC">

                        <asp:LinkButton ID="linkAE" runat="server" OnClick="linkAE_Click">
                <div class="AirExport">
                    Air Export
                </div>
                        </asp:LinkButton>
                    </div>



                    <div class="AirImportC">
                        <asp:LinkButton ID="linkAI" runat="server" OnClick="linkAI_Click1">
                <div class="AirImport">
                    Air Import
                </div>
                        </asp:LinkButton>
                    </div>



                    <div class="BookingHeadn1" runat="server" id="lnk_upd" visible="false">
                       <asp:LinkButton ID="Lnk_all" runat="server" Text="Update Status" OnClick="Lnk_all_Click" target='frmContent'>
                    <div class="Ebooking">
                      Status

                    </div>
                        </asp:LinkButton>
                     </div>


                </div>
            </div>
             <div style="clear: both;"></div>
          <div style="width:96.5%; margin:5px auto; border-top:1px dotted #000;"></div>



             <div id="div_bar" runat="server" class="FormGroupContent4" visible="false">



                 <div class="BookingHead"  style="display: none;"><asp:Label Text="Event Details" ID="BookingLbl" runat="server"></asp:Label></div>




                     



                  <asp:Label ID="Label1" runat="server"></asp:Label>
                   <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1" BehaviorID="programmaticModalPopupBehavior4"
                                        PopupControlID="Paneln2" Drag="true"
                                        BackgroundCssClass="modalBackground">
                                    </ajaxtoolkit:ModalPopupExtender>
                 
                        <asp:Panel ID="Paneln2" runat="server" ScrollBars="Auto" CssClass="Grid modalPopupn1">
                            <asp:Label ID="LblDetails" runat="server" Visible="false"></asp:Label>
                             <div class="DivSecPaneln">
                                 <asp:LinkButton ID="LnkClose"   runat="server"  OnClick="LnkClose_Click">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%"  />
                                     </asp:LinkButton>
                                            </div>
                            <div class="GridBorder1 Hide">
                 
                                <asp:GridView ID="GrdDetails" TabIndex="13" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="false" PageSize="3" Width="100%" ForeColor="Black" AllowPaging="false" CssClass="Grid FixedHeader"  OnRowDataBound="GrdDetails_RowDataBound" OnSelectedIndexChanged="GrdDetails_SelectedIndexChanged">
                <Columns>


                 <%--     <asp:BoundField DataField="SI" HeaderText="SI #">   
                        <HeaderStyle Wrap="false"  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="S #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" Width="30px" />
                                                    <HeaderStyle Wrap="true" Width="30px" />
                                                </asp:TemplateField>

                      <asp:BoundField DataField="type" HeaderText="Status">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                      <%-- <asp:BoundField DataField="status" HeaderText="Status">   
                        <HeaderStyle Wrap="false"  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                   <asp:BoundField DataField="Service" HeaderText="Service">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                      <asp:BoundField DataField="Bookingno" HeaderText="Booking #">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="bookingdate" HeaderText="Booking Date">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Origin" HeaderText="Origin">   
                        <HeaderStyle  />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Destination" HeaderText="Destination">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="ETAOrigin" HeaderText="ETA Origin">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="ETDDestintation" HeaderText="ETD Destintation">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                       <asp:BoundField DataField="blno" HeaderText="BL #">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                      <asp:BoundField DataField="job" HeaderText="job">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>
                     <asp:BoundField DataField="bid" HeaderText="bid">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="trantype" HeaderText="trantype">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>

                     <asp:BoundField DataField="flight" HeaderText="flight">   
                        <HeaderStyle  CssClass="Hiden" />                                             
                        <ItemStyle HorizontalAlign="Left" CssClass="Hiden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="shipmentstatus" HeaderText="Shipment Status">   
                        <HeaderStyle />                                             
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>


                        <asp:TemplateField HeaderText="View"><%--11--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lnk_job" runat="server" CommandName="select" Font-Underline="false"
                                                                CssClass="Arrow">⇛</asp:LinkButton>
                                                            <br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
                <RowStyle Font-Italic="False" />
            </asp:GridView>
                        

                            </div>
            <div class="div_Break"></div>
        </asp:Panel>

            
                      









                         <div  class="PendingRightnewLRightNew1" visible="false" style="display:none;">
                            <asp:Literal ID="lts" runat="server"></asp:Literal>
                            <div id="chart_divbar"></div>

                        </div>

                <div runat="server" id="div2_Bookchart" class="PendingRightnewLRightNewn1" visible="false" style="display:none;" >
                            <div id="chartdiv1" style="width: 470px; height: 340px;">
                                Booking</div>
                        </div>

                 </div>
            <div class="Clear"></div>
            <iframe id="ifrmaster" name="centerfrm" class="div_Menu" frameborder="0" src="" scrolling="no" runat="server"></iframe>


        </div>
           
        <div class="CSValue">
            <div class="BookingTxtBox1">
                <asp:TextBox ID="txt_bookingno" runat="server" ToolTip="Booking #" placeholder="Booking #"
                    CssClass="form-control" ></asp:TextBox> <%-- OnTextChanged="txt_bookingno_TextChanged"--%>
            </div>


            <div class="btn ico-get" style="margin-top:12px;">
                          <asp:Button ID="BtnSelect" runat="server" ToolTip="Find" OnClick="txt_bookingno_TextChanged" />
              </div>
            <div class="RoundHeight" id="RoundHeight1" runat="server"></div>
            <div class="Round" id="RBooking" runat="server"></div>
            <div class="Round1" id="RStuffing" runat="server"></div>
            <div class="Round2" id="RSailling" runat="server"></div>
            <div class="Round3" id="RTranshipment" runat="server"></div>
            <div class="Round4" id="RDOReq" runat="server"></div>
            <div class="Round5" id="RDOCofirm" runat="server"></div>


           <div class="Round6" id="Originaldocsenton" runat="server"></div>

            <div class="Round7" id="releasedon" runat="server"></div>

            <div class="Round8" id="jodate1" runat="server"></div>

            <div class="Round9" id="Div1" runat="server"></div>
             <div class="Round10" id="Div2" runat="server"></div>
            <div class="Round11" id="Div3" runat="server"></div>
            <div class="Round12" id="Div4" runat="server"></div>
            <div class="Textlinkc">

                 <div class="TxtLbl">
                       <span id ="lblbk" runat="server">Booking</span>
                    <label id="LblBookingDate" runat="server"></label>
                  
                </div>
                 <div class="TxtLbl1">
                     <span id ="lblsail" runat="server">Sailed</span>
                    <label id="LblSailingDate" runat="server"></label>
                </div>
                 <div class="TxtLbl2">
                   <span id ="lblstuf" runat="server">Stuffing</span>
                    <label id="LblStuffingDate" runat="server"></label>
                </div>                      
               
               
                <div class="TxtLbl3" id="lblClear1" runat="server" visible="false">


                     <span id="lblClear" runat="server">Clearance Pro On</span>
                    <label id="lblCleardate" runat="server"></label>


                </div>
                <div class="TxtLbl4" id="lbltran1" runat="server" visible="false">
                      <span id ="lbltran" runat="server">Transhipped</span>
                    <label id="LblTranshipmentDate" runat="server"></label>
                    
                </div>
                <div class="TxtLbl5" id="lblcargo1" runat="server" visible="false">
                     <span id="lblcargo" runat="server">Cargo Air On</span>
                    <label id="lblcargodate" runat="server"></label>
                </div>



                   <div class="TxtLbl6" id="lblOrig" runat="server" visible="false">
                        <span id ="lblDocon" runat="server">DO Confirm Request</span>
                    <label id="LblDOConfirmReqDate" runat="server"></label>
                   
                </div>

                     <div class="TxtLbl7" id="lblrel" runat="server" visible="false">
                          <span id="lblarr" runat="server">Arrival On</span>
                    <label id="lblarrdate" runat="server"></label>
                </div>

                 <div class="TxtLbl8" id="lbljob" runat="server" visible="false">
                       <span id ="lblOriginaldocsenton" runat="server"></span>
                    <label id="LblOriginaldocsentonDate" runat="server"></label>
                     
                </div>

                <div class="TxtLbl9" id="lbldel1" runat="server" visible="false">
                   
                    <span id="lbldel" runat="server">Delivery Update On</span>
                    <label id="lbldeldate" runat="server"></label>
                </div>
                 <div class="TxtLbl10" id="lblDoconfirmed1" runat="server" visible="false">
                       <span id ="lblDoconfirmed" runat="server">DO Confirmed</span>
                    <label id="LblDOConfirmedDate" runat="server"></label>
                  
                                      
                  
                </div>
                  <div class="TxtLbl11" id="lblreleasedonon1" runat="server" visible="false">
                       <span id ="lblreleasedonon" runat="server"></span>
                    <label id="lblreleasedondate" runat="server"></label>
                   
                </div>
                <div class="TxtLbl12" id="lbljobon1" runat="server" visible="false">

                     <span id ="lbljobon" runat="server"></span>
                    <label id="lbljobDte" runat="server"></label>
                </div>

            </div>



            
                                            <asp:Label ID="lblcrm" runat="server"></asp:Label>
                                    <ajaxtoolkit:ModalPopupExtender ID="PopupBL" runat="server" TargetControlID="lblcrm" BehaviorID="programmaticModalPopupBehavior3"
                                        PopupControlID="popupfro" Drag="true"
                                        BackgroundCssClass="modalBackground" > <%-- CancelControlID="imgcrok"--%>
                                    </ajaxtoolkit:ModalPopupExtender>

                                    <asp:Panel ID="popupfro" runat="server"  CssClass="modalPopup1" BorderStyle="Solid" BorderWidth="2px" Style="display: none;">
                                        <div class="divRoated">
                                            <div class="DivSecPanel">
                                                <asp:LinkButton ID="LinkButton1"   runat="server"  OnClick="LinkButton1_Click">
                                                <asp:Image ID="imgcrok" runat="server" ImageUrl="~/Theme/assets/img/buttonIcon/active/close-sm.png" Width="100%" Height="100%" />
                                                    </asp:LinkButton>
                                            </div>

                                            <asp:Panel ID="Panel31" runat="server" CssClass="Gridpnl">

                                                <iframe id="iframecost" runat="server" frameborder="0" src="" visible="true" class="frames" style="background-color: #FFFFF"></iframe>

                                            </asp:Panel>
                                            <div class="divBk"></div>
                                        </div>
                                    </asp:Panel>

        </div>
    </form>
</body>
</html>
