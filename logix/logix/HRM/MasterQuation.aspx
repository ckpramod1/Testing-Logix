<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterForm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MasterQuation.aspx.cs" Inherits="logix.HRM.MasterQuation" %>

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
    <link href="../Styles/VoucherRegister.css" rel="stylesheet" />
     <link href="../Theme/assets/css/buttonicon.css" rel="stylesheet" type="text/css">
    <link href="../Theme/newTheme/css/systemnewdeign.css" rel="stylesheet" />
    <!--=== JavaScript ===-->

  <%--  <script type="text/javascript" src="../Theme/Content/assets/js/libs/jquery-1.10.2.min.js"></script>--%>

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


    <link href="../Styles/MasterQuation.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="stylesheet" />
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        {
            function pageLoad(sender, args) {
                $(document).ready(function () {
                    $("#<%=txtQuextiontitle.ClientID %>").autocomplete({

                        source: function (request, response) {
                            $("#<%=hid_QuesTit.ClientID %>").val(0);
                            $.ajax({
                                url: "../HRM/MasterQuation.aspx/GetQuestTitle",
                                data: "{ 'prefix': '" + request.term + "','Ftype':'C'}",
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
                            $("#<%=txtQuextiontitle.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=txtQuextiontitle.ClientID %>").change();
                            $("#<%=hid_QuesTit.ClientID %>").val(i.item.val);
                        },
                        focus: function (event, i) {
                            $("#<%=txtQuextiontitle.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                            $("#<%=hid_QuesTit.ClientID %>").val(i.item.val);
                        },
                        change: function (event, i) {
                            if (i.item) {
                                $("#<%=txtQuextiontitle.ClientID %>").val($.trim(i.item.label.split(',')[0]));
                                $("#<%=hid_QuesTit.ClientID %>").val(i.item.val);

                            }

                        },
                        close: function (event, i) {
                            var result = $("#<%=txtQuextiontitle.ClientID %>").val().toString().split(',')[0];
                            $("#<%=txtQuextiontitle.ClientID %>").val($.trim(result));

                        },
                        minLength: 1
                    });
                });
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });

            }
        }
        </script>    
    <style type="text/css">

        .btn-UpdateAdd2 {
   
    z-index: 2;
    border-radius: 0px;
}

    .btn-UpdateAdd2 input {
       
        border: medium none;
        line-height: normal;
        color: #4e4e4c!important;
        padding: 5px 0px 6px 28px;
        background:url(../Theme/assets/img/buttonIcon/updateadd_ic.png ) no-repeat left top;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="logix_CPH" runat="server">

      <!-- Breadcrumbs line -->
          <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
              <li><i class="icon-home"></i><a href="#"></a>Home </li>
            <li><a href="#">HRM</a></li>
              <li><a href="#" title="">Utility</a> </li>
              <li class="current">Master Question </li>
            </ul>
      </div>
    <!-- Breadcrumbs line End -->
    
     <div class="FormBg">
    <div class="FormHead">
      <h3><img src="../Theme/newTheme/img/masterquestion_ic.png" />  <asp:Label ID="txtMasterQuation" runat="server" Text="Master Question"></asp:Label></h3>
    </div>
        <div class="Form-ControlBg">
                <div class="FormGroupContent4">
                  <div class="MasterTitle">
                      <div class="LabelWidth">Question Title</div>
                      <div class="FieldInput"><asp:TextBox ID="txtQuextiontitle" runat="server" placeholder="" ToolTip="Question Title" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtQuextiontitle_TextChanged"></asp:TextBox></div>
                      </div>
                  <div class="MasterDrop">
                      <div class="LabelWidth">Department</div>
                      <div class="FieldInput"><asp:DropDownList ID="ddlDepartment" runat="server" CssClass="chzn-select" data-placeholder="Department" ToolTip="Department">
                                   <asp:ListItem Value=""></asp:ListItem>         
                                          </asp:DropDownList></div>
                      </div>
                  <div class="MasterName">
                      <div class="LabelWidth">Conducted By</div>
                      <div class="FieldInput"><asp:TextBox ID="txtConductedBy" runat="server" placeholder="" ToolTip="Conducted By" CssClass="form-control"></asp:TextBox></div>
                      </div>
                  </div>
              <div class="bordertopNew MT05"></div>
              <div class="FormGroupContent4">
                  <div class="right_btn MT0">
                      <div class="btn ico-save" id="btnSave1" runat="server"> <asp:Button ID="btnSave" runat="server" ToolTip="Save"  OnClick="btnSave_Click" /></div>
                      <div class="btn ico-cancel" id="btnCancel1" runat="server"><asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" OnClick="btnCancel_Click" /></div>
                  </div>
              </div>
               <div class="FormGroupContent4">
                   <div class="LabelWidth">Question</div>
                   <div class="FieldInput"><asp:TextBox ID="txtQuestion" runat="server" placeholder="" ToolTip="Question"  TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox></div>
                   
                   </div>
              <div class="FormGroupContent4">
                  <div class="MasterOption">
                      <div class="LabelWidth">Option</div>
                      <div class="FieldInput"><asp:TextBox ID="txtOption" runat="server" placeholder="" ToolTip="Option"  CssClass="form-control"></asp:TextBox></div>
                      </div>
                   <div class="MasterOption">
                       <div class="LabelWidth">Option 1</div>
                       <div class="FieldInput"><asp:TextBox ID="txtOption1" runat="server" placeholder="" ToolTip="Option1" CssClass="form-control"></asp:TextBox></div>
                       
                        </div>
                   <div class="MasterOption">
                       <div class="LabelWidth">Option 2</div>
                       <div class="FieldInput"><asp:TextBox ID="txtOption2" runat="server" placeholder="" ToolTip="Option2" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="MasterOption">
                       <div class="LabelWidth">Option 3</div>
                       <div class="FieldInput"><asp:TextBox ID="txtOption3" runat="server" placeholder="" ToolTip="Option3" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   <div class="MasterOption1">
                       <div class="LabelWidth">Option 4</div>
                       <div class="FieldInput"><asp:TextBox ID="txtOption4" runat="server" placeholder="" ToolTip="Option4" CssClass="form-control"></asp:TextBox></div>
                       </div>
                   </div>
               <div class="FormGroupContent4">

                   <div class="right_btn MT0">
                       <div class="btn ico-add" id="btnAdd1" runat="server"> <asp:Button ID="btnAdd" runat="server" ToolTip="Add" OnClick="btnAdd_Click1" /></div>
                       <div class="btn ico-delete"><asp:Button ID="BtnDelete" runat="server" ToolTip="Delete" /></div>
                       <div class="btn ico-clear"><asp:Button ID="btnClear" runat="server" ToolTip="Clear"  OnClick="btnClear_Click" /></div>
                   </div>
                   </div>
               <div class="FormGroupContent4">
                   <div class="div_grd">
            <asp:GridView ID="Grd" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"  Width="100%"   CssClass="NewThemeTbl" OnSelectedIndexChanged="Grd_SelectedIndexChanged" OnRowDataBound="Grd_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="qid" HeaderText="Quest ID" />
                    <asp:BoundField DataField="question" HeaderText="Question" />
                    <asp:BoundField DataField="option1" HeaderText="Option 1" />
                    <asp:BoundField DataField="option2" HeaderText="Option 2" />
                    <asp:BoundField DataField="option3" HeaderText="Option 3" />
                    <asp:BoundField DataField="option4" HeaderText="Option 4" />
                    <asp:BoundField DataField="option5" HeaderText="Option 5" />

                </Columns>
                 <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GrdAltRow" />
            </asp:GridView>
        </div>

                   </div>
            </div>
         </div>











       <div >
        <div class="col-md-12  maindiv"> 
    
     <div class="widget box" runat ="server">
     <div class="widget-header">
                  <h4><i class="icon-umbrella"></i></h4>
                </div>
          <div class="widget-content">
          
              </div>
         </div>
            </div>
           </div>











    <div class="div_total">
        <div class="lbl_Header1">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_Questontitletxt">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_ddldepartmentt">
            
        </div>
        <div class="div_txtConductedBy">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_btn">
           
            
        </div>
        <div class="div_Break"></div>
        <div class="div_Quextiontxt">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_optiontxt">
           
        </div>
        <div class="div_Break"></div>
        <div class="div_option1txt">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_option2txt">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_option3txt">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_option4txt">
            
        </div>
        <div class="div_Break"></div>
        <div class="div_btn1">
           
            
            
        </div>
        <div class="div_Break"></div>
        
        <div class="div_Break"></div>
        <asp:HiddenField ID="hid_QuesTit" runat="server" />
        <asp:HiddenField ID="hid_Qid" runat="server" />
    </div>
</asp:Content>
