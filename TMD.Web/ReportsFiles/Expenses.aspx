<%@ Page Language="C#"  MasterPageFile="~/Views/Shared/Reports.Master"  AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="TMD.Web.ReportsFiles.Expenses" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ReportContentPage" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet-title">
                    <div class="tools">
                        <input type="button" class="btn blue titleButton" id="btnResetFltr" style="float:right" onclick="ResetFilters();" value="Reset" />
                        <asp:Button ID="btnFilter" runat="server" style="float:right"  Text="Filter" OnClick="btnFilter_OnClick" OnClientClick="Spinner();"/>
                    </div>
                </div>
            <div class="portlet-body form">
                    <div class="form-actions">
                        <div>
                            <table class="responsive">
                                <tr>
                                    <td class="col-md-1">
                                        <label class="control-label"> Year </label>
                                    </td>
                                    <td class="col-md-2">
                                        <div class="input-icon">
                                            <asp:DropDownList runat="server" ID="ddlYear"> 
                                                <asp:ListItem Text="2015" Value="2015" />
                                                <asp:ListItem Text="2016" Value="2016" />
                                                <asp:ListItem Text="2017" Value="2017" />
                                                <asp:ListItem Text="2018" Value="2018" />
                                                <asp:ListItem Text="2019" Value="2019" />
                                                <asp:ListItem Text="2020" Value="2020" />
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-md-1">
                                        <label class="control-label"> Month </label>
                                    </td>
                                    <td class="col-md-2">
                                        <div class="input-icon">
                                            <asp:DropDownList runat="server" ID="ddlMonth"> 
                                                <asp:ListItem Text="January" Value="1" />
                                                <asp:ListItem Text="February" Value="2" />
                                                <asp:ListItem Text="March" Value="3" />
                                                <asp:ListItem Text="April" Value="4" />
                                                <asp:ListItem Text="May" Value="5" />
                                                <asp:ListItem Text="June" Value="6" />
                                                <asp:ListItem Text="July" Value="7" />
                                                <asp:ListItem Text="August" Value="8" />
                                                <asp:ListItem Text="September" Value="9" />
                                                <asp:ListItem Text="October" Value="10" />
                                                <asp:ListItem Text="November" Value="11" />
                                                <asp:ListItem Text="December" Value="12" />
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-md-1">
                                        <label class="control-label"> Vendor </label>
                                    </td>
                                    <td class="col-md-2">
                                        <div class="input-icon">
                                            <i class="fa fa-search"></i>
                                           <asp:TextBox runat="server" ID="txtVendorName" ClientIDMode="static"/>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 10px !important; "></tr>
                            </table>
                        </div>
                    </div>
                </div>
        </div>
    </div>
    <div class="span12">
         <rsweb:ReportViewer ID="ExpensesReportViewer" runat="server" Width="100%" Height="500px" Font-Names="Verdana"  Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" />
    </div>
    <div id="loading" class="reload" style="display: none;">
    <img src="/Images/reportsSpinner.gif" style="width: 196px;" />
    <span style="margin-left: -144px;">Loading report...</span>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script>
        function Spinner() {
            $("#loading").show();
        }
        function ResetFilters() {                       
            $("#ddlYear").val("2015");
            $("#ddlMonth").val("1");
            $("#txtVendorName").val("");
        }
      </script>
</asp:Content>
