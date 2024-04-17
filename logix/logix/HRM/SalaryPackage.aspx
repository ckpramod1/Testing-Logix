<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SalaryPackage.aspx.cs" Inherits="logix.HRM.SalaryPackage" %>

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

    <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>

    <!-- Smartphone Touch Events -->

    <!-- General -->
    <!-- Polyfill for min/max-width CSS3 Media Queries (only for IE8) -->
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="../Theme/Content/plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>

  
    <!-- App -->

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


    <link href="../Styles/SalaryPackage.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txt_Empname.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $("#<%=hid_empcode.ClientID %>").val(0);
                        $.ajax({
                            url: "../Autocomplete/Autocomplete.aspx/GetEmpDetail",
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
                    select: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_Empname.ClientID %>").change();
                    },
                    change: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_Empname.ClientID %>").val(i.item.label);
                    },
                    focus: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_Empname.ClientID %>").val(i.item.label);
                    },
                    close: function (e, i) {
                        $("#<%=hid_empcode.ClientID %>").val(i.item.val);
                        $("#<%=txt_Empname.ClientID %>").val(i.item.label);
                    },
                    minLength: 1
                });
            });
            $(document).ready(function () {
                $("#<%=txt_otherallow.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $("#<%=txt_bonus.ClientID %>").val();
                        var strText = strval.substr(0, strval.length - 1)
                        $("#<%=txt_bonus.ClientID %>").val(strText);
                        return false;
                    }
                });
                $("#<%=txt_lunchallow.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_others.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_petrol.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });

                $("#<%=txt_datacard.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_driverwages.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_mobile.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_phone.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_vma.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_othervma.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_bonus.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        GetDetail();
                    }
                    else {
                        alertify.alert("Please Enter Numeric Values");
                        var strval = $(this).val();
                        var strText = strval.substr(0, strval.length - 1)
                        $(this).val(strText);
                        return false;
                    }
                });
                $("#<%=txt_car.ClientID %>").keyup(function () {
                    if (IsDouble(this) == 1) {
                        if ((parseInt($(this).val(), 10) <= 1600)) {
                            $("#<%=txt_amount.ClientID %>").val(21600);
                        }
                        else if ((parseInt($(this).val(), 10) > 1600)) {
                            $("#<%=txt_amount.ClientID %>").val(32200);
                        }
                        else {
                            $("#<%=txt_amount.ClientID %>").val(0);
                        }
                }
                else {
                    alertify.alert("Please Enter Numeric Values");
                    var strval = $(this).val();
                    var strText = strval.substr(0, strval.length - 1)
                    $(this).val(strText);
                    return false;
                }
                });

            });
    }
    function GetDetail() {
        SValue = new Array();
        SValue[0] = $("#<%=txt_Gross.ClientID %>").val();
            SValue[1] = $("#<%=txt_pf.ClientID %>").val();
            SValue[2] = "0";
            SValue[3] = $("#<%=txt_basic.ClientID %>").val();
            SValue[4] = $("#<%=txt_hra.ClientID %>").val();
            SValue[5] = $("#<%=txt_conveyance.ClientID %>").val();
            SValue[6] = $("#<%=txt_specialallow.ClientID %>").val();
            SValue[7] = $("#<%=txt_entertainallow.ClientID %>").val();
            SValue[8] = $("#<%=txt_loyality.ClientID %>").val();
            SValue[9] = $("#<%=txt_otherallow.ClientID %>").val();
            SValue[10] = $("#<%=txt_lunchallow.ClientID %>").val();
            SValue[11] = $("#<%=txt_others.ClientID %>").val();
            SValue[12] = $("#<%=txt_driverallow.ClientID %>").val();
            SValue[13] = $("#<%=txt_petrol.ClientID %>").val();
            SValue[14] = $("#<%=txt_datacard.ClientID %>").val();
            SValue[15] = $("#<%=txt_driverwages.ClientID %>").val();
            SValue[16] = $("#<%=txt_mobile.ClientID %>").val();
            SValue[17] = $("#<%=txt_phone.ClientID %>").val();
            SValue[18] = $("#<%=txt_vma.ClientID %>").val();
            SValue[19] = $("#<%=txt_othervma.ClientID %>").val();
            SValue[20] = $("#<%=txt_lta.ClientID %>").val();
            SValue[21] = $("#<%=txt_medical.ClientID %>").val();
            SValue[22] = $("#<%=txt_bonus.ClientID %>").val();
            $.ajax({
                type: "POST",
                url: "../HRM/SalaryPackage.aspx/GetTotal",
                data: '{Prefix: "' + SValue + '" }',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    $("#<%=txt_permonth.ClientID %>").val(response.d.split('~')[0]);
                    $("#<%=txt_perannum.ClientID %>").val(response.d.split('~')[1]);
                },
                failure: function (response) {
                    alertify.alert(response.d);
                }
            });
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">


       <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">HRM</a> </li>
              <li class="current">Salary/Packages Details</li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i><asp:Label ID="lbl_header" runat="server" Text="Salary/Packages Details"></asp:Label></h4>
                </div>
          <div class="widget-content">
             <div class="FormGroupContent4">
                 <div class="EmpCo"><asp:LinkButton ID="lnk_empcode" runat="server" Style="text-decoration: none;" ForeColor="Red" OnClick="lnk_empcode_Click">EmpCode</asp:LinkButton></div>
                 <div class="EmpCotxtBox"><asp:TextBox ID="txt_Empcode" runat="server" CssClass="form-control" AutoPostBack="True"  OnTextChanged="txt_Empcode_TextChanged"></asp:TextBox></div>
                 <div class="EmpTxtName"><asp:TextBox ID="txt_Empname" runat="server" placeholder="Name" ToolTip="Name" CssClass="form-control" AutoPostBack="True"  OnTextChanged="txt_Empname_TextChanged"></asp:TextBox></div>
                 <div class="EmpCompanyname"> <asp:TextBox ID="txt_company" runat="server" placeholder="Company" ToolTip="Company" CssClass="form-control"></asp:TextBox></div>
                 </div>
              <div class="FormGroupContent4">
                  <div class="SalaryGross"><asp:TextBox ID="txt_Gross" runat="server" placeholder="Gross" style="text-align:right;" ToolTip="Gross" AutoPostBack="True" CssClass="form-control" OnTextChanged="txt_Gross_TextChanged"></asp:TextBox></div>
                  <div class="SalaryCal"><asp:TextBox ID="txt_from" runat="server" placeholder="From" style="text-align:right;" ToolTip="From" CssClass="form-control"></asp:TextBox></div>
                  <div class="SalaryCal"><asp:TextBox ID="txt_to" runat="server" placeholder="To" ToolTip="To" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                  <div class="SalaryPF"> <asp:TextBox ID="txt_pf" runat="server" placeholder="PF" ToolTip="PF" style="text-align:right;" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                  <div class="SalaryEsi"> <asp:TextBox ID="txt_esi" runat="server" placeholder="ESI" ToolTip="ESI" style="text-align:right;" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                  </div>
               <div class="FormGroupContent4">
                   <div class="SalaryGross"><asp:TextBox ID="txt_basic" runat="server" placeholder="Basic" ToolTip="Basic" style="text-align:right;" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                   <div class="SalaryHRA"><asp:TextBox ID="txt_hra" runat="server" placeholder="HRA" ToolTip="HRA" CssClass="form-control" style="text-align:right;"  ReadOnly="True"></asp:TextBox></div>
                   <div class="SalaryCon"><asp:TextBox ID="txt_conveyance" runat="server" placeholder="Conveyance" ToolTip="Conveyance" style="text-align:right;" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
               <div class="SalarySpecial"><asp:TextBox ID="txt_specialallow" runat="server" placeholder="Special Allow" ToolTip="Special Allow" style="text-align:right;" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                   <div class="SalaryEntertain"> <asp:TextBox ID="txt_entertainallow" runat="server" placeholder="Entertain Allow" style="text-align:right;" ToolTip="Entertain Allow" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
               </div>
                <div class="FormGroupContent4">
                    <div class="SalaryGross"> <asp:TextBox ID="txt_loyality" runat="server" placeholder="Loyality" ToolTip="Loyality" style="text-align:right;" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                    <div class="SalaryHRA"><asp:TextBox ID="txt_otherallow" runat="server" placeholder="Other Allow" ToolTip="Other Allow" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                    <div class="SalaryCon"><asp:TextBox ID="txt_lunchallow" runat="server" placeholder="Lunch Allow" ToolTip="Lunch Allow" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                    <div class="SalarySpecial"><asp:TextBox ID="txt_others" runat="server" placeholder="Others" ToolTip="Others" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                    <div class="SalaryEntertain"><asp:TextBox ID="txt_driverallow" runat="server" placeholder="Driver Allow" style="text-align:right;" ToolTip="Driver Allow" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                    </div>
               <div class="FormGroupContent4">
                   <div class="SalaryGross"><asp:TextBox ID="txt_petrol" runat="server" placeholder="Petrol" ToolTip="Petrol" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                   <div class="SalaryHRA"><asp:TextBox ID="txt_datacard" runat="server" placeholder="Data Card" ToolTip="Data Card" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                   <div class="SalaryCon"><asp:TextBox ID="txt_driverwages" runat="server" placeholder="Driver Wages" ToolTip="Driver Wages" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                   <div class="SalarySpecial"><asp:TextBox ID="txt_mobile" runat="server" placeholder="Mobile" ToolTip="Mobile" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                   <div class="SalaryEntertain"><asp:TextBox ID="txt_phone" runat="server" placeholder="Res Phone" style="text-align:right;" ToolTip="Res Phone" CssClass="form-control"></asp:TextBox></div>
                   </div>
               <div class="FormGroupContent4">

                   <div class="SalaryGross"><asp:TextBox ID="txt_vma" runat="server" placeholder="VMA" ToolTip="VMA" style="text-align:right;" CssClass="form-control"></asp:TextBox></div>
                       <div class="SalaryHRA"><asp:TextBox ID="txt_othervma" runat="server" placeholder="Others" style="text-align:right;" ToolTip="Others" CssClass="form-control"></asp:TextBox></div>
                           <div class="SalaryCon"> <asp:TextBox ID="txt_lta" runat="server" placeholder="LTA" ToolTip="LTA" style="text-align:right;" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                               <div class="SalarySpecial"><asp:TextBox ID="txt_medical" runat="server" placeholder="Medical" style="text-align:right;" ToolTip="Medical" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                                   <div class="SalaryEntertain"><asp:TextBox ID="txt_bonus" runat="server" placeholder="Bonus" style="text-align:right;" ToolTip="Bonus" CssClass="form-control"></asp:TextBox></div>
                   </div>
                <div class="FormGroupContent4">
                    <div class="SalaryGross"><asp:TextBox ID="txt_car" runat="server" MaxLength="5" placeholder="CarCC" style="text-align:right;" ToolTip="CarCC" CssClass="form-control"></asp:TextBox></div>
                    <div class="SalaryHRA"><asp:TextBox ID="txt_amount" runat="server" placeholder="Amount" ToolTip="Amount" style="text-align:right;" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                    </div>
              <div class="FormGroupContent4">
                  <div class="SalaryCostlbl"><asp:Label ID="lbl_CTC" runat="server" Text="Cost To Company"></asp:Label></div>
                  <div class="SalaryPerM"><asp:TextBox ID="txt_permonth" runat="server" placeholder="Per Month" style="text-align:right;" ToolTip="Per Month" CssClass="form-control"  ReadOnly="True"></asp:TextBox></div>
                  <div class="SalaryPerA"><asp:TextBox ID="txt_perannum" runat="server" placeholder="Per Annum" style="text-align:right;" ToolTip="Per Annum" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                  <div class="right_btn MT0 MB05">
                      <div class="btn ico-save" id="btn_save1" runat="server"><asp:Button ID="btn_save" runat="server" ToolTip="Save" OnClick="btn_save_Click" /></div>
                      <div class="btn ico-delete"><asp:Button ID="btn_delete" runat="server" ToolTip="Delete" OnClick="btn_delete_Click" /></div>
                      <div class="btn ico-view"><asp:Button ID="btn_view" runat="server" ToolTip="View" Visible="false" /></div>
                      <div class="btn ico-back" id="btnBack1" runat="server"> <asp:Button ID="btnBack" runat="server" ToolTip="Back" OnClick="btnBack_Click" /></div>

                  </div>
                  </div>
              <div class="FormGroupContent4">
                  <asp:Panel ID="panel" runat="server" CssClass="GridPalICD">
            <asp:GridView ID="Grd_Salary" runat="server" AutoGenerateColumns="False" CssClass="Grid FixedHeader" 
                Width="100%" ForeColor="Black" ShowHeaderWhenEmpty="True"
                DataKeyNames="esi,pf,others,entertainallow,loyality,lallowence,Expr2,datacard,mobile,petrol,phoner,bonus,
                Expr1,driverallow,driverwages,vma,mc,mcamt,Gross"
                OnSelectedIndexChanged="Grd_Salary_SelectedIndexChanged" OnRowDataBound="Grd_Salary_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="sfrom" HeaderText="From" />
                    <asp:BoundField DataField="sto" HeaderText="To" />
                    <asp:BoundField DataField="basic" HeaderText="Basic" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="hra" HeaderText="HRA" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="conveyance" HeaderText="Convey" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sallowence" HeaderText="Special Allow" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lta" HeaderText="LTA" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="medical" HeaderText="Medical" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcmonth" HeaderText="CTC Month" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ctcannum" HeaderText="CTC Annum" DataFormatString="{0:0.00}" ItemStyle-CssClass="TxtAlign1">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <%-- <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="Lnk_Select" runat="server" CommandName="select" Font-Underline="false"
                            CssClass="Arrow">⇛</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                </Columns>
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>

        </asp:Panel>

                  </div>
              </div>
         </div>
            </div>
           </div>




       <asp:Panel ID="pln_Emp" runat="server" class="div_frame" Style="display: none;">
            <div class="div_close">
                <asp:Image ID="Close_Emp" runat="server" ImageAlign="Baseline" ImageUrl="~/images/GrdClose.gif" />
            </div>
            <div class="div_Break">
            </div>
            <div class="div_frame">
                <iframe id="iframecost" runat="server" src="" frameborder="0" class="frames" style="background-color: #FFFFFF"></iframe>
            </div>
        </asp:Panel>
        <div class="div_break">
        </div>
    <asp:HiddenField ID="hid" runat="server" />

    <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <asp:HiddenField ID="hid_empcode" runat="server" />
    <asp:ModalPopupExtender ID="Popup_Emp" runat="server" PopupControlID="pln_Emp" BackgroundCssClass="modalBackgroundjob"
        CancelControlID="Close_Emp" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_from"></asp:CalendarExtender>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_to"></asp:CalendarExtender>
</asp:Content>
