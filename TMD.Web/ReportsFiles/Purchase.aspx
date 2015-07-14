<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="TMD.Web.ReportsFiles.Purchase" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ReportContentPage" runat="server">
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
                                        <label class="control-label"> Product Code </label>
                                    </td>
                                    <td class="col-md-2">
                                        <div class="input-icon">
                                            <i class="fa fa-search"></i>
                                           <asp:TextBox runat="server" ID="txtProductCode" ClientIDMode="static"/>
                                        </div>
                                    </td>
                                    <td class="col-md-1">
                                        <label class="control-label"> Start Date </label>
                                    </td>
                                    <td class="col-md-2">
                                        <div class="input-icon">
                                            <i class="fa fa-search"></i>
                                           <asp:TextBox runat="server" ID="txtFrom" ClientIDMode="static"/>
                                        </div>
                                    </td>
                                    <td class="col-md-1">
                                        <label class="control-label"> End Date </label>
                                    </td>
                                    <td class="col-md-2">
                                        <div class="input-icon">
                                            <i class="fa fa-search"></i>
                                           <asp:TextBox runat="server" ID="txtTo" ClientIDMode="static"/>
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
         <rsweb:ReportViewer ID="SalesReportViewer" runat="server" Width="100%" Height="500px" Font-Names="Verdana"  Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" />
    </div>  
    <div id="loading" class="reload" style="display: none;">
    <img src="/Images/reportsSpinner.gif" style="width: 196px;" />
    <span style="margin-left: -144px;">Loading report...</span>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script>
         $(document).ready(function () {
             $("#txtFrom").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 numberOfMonths: 1,
                 onClose: function (selectedDate) {
                     $("#txtTo").datepicker("option", "minDate", selectedDate);
                 }
             });
             $("#txtTo").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 numberOfMonths: 1,
                 onClose: function (selectedDate) {
                     $("#txtFrom").datepicker("option", "maxDate", selectedDate);
                 }
             });
         });
         function Spinner() {
             $("#loading").show();
         }
         function ResetFilters() {
             $("#txtProductCode").val("");
             $("#txtFrom").val("");
             $("#txtTo").val("");
         }
      </script>
</asp:Content>
