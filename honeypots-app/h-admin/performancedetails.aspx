<%@ Page Title="" Language="C#" MasterPageFile="~/h-admin/honeypotsMasterPage.master" AutoEventWireup="true" CodeFile="performancedetails.aspx.cs" Inherits="h_admin_performancedetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="margin-left: 15px; margin-bottom: 5px; margin-top: 5px;">
        <p> Date : 
            <asp:TextBox ID="txtDateFrom" CssClass="inpText" style="width: 170px;" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="txtDate_CalendarExtender" Format="dd-MMM-yyyy" runat="server" Enabled="True" TargetControlID="txtDateFrom">
            </asp:CalendarExtender>
            &nbsp;to&nbsp;
            <asp:TextBox ID="txtDateTo" CssClass="inpText" style="width: 170px;" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="txtDateTo_CalendarExtender" Format="dd-MMM-yyyy" runat="server" Enabled="True" TargetControlID="txtDateTo">
            </asp:CalendarExtender>
            &nbsp;&nbsp;
            <asp:Button ID="btnGo" runat="server" style="padding: 3px; border: solid 2px #AFAFAF; cursor: pointer;" Text="GO" onclick="btnGo_Click" />

            <asp:HiddenField ID="hdnPage" runat="server" />
        </p>
        <p style="font-size: 15px; text-align: left; margin-top: 5px;"><asp:Literal ID="litPage" runat="server"></asp:Literal></p>
    </div>
    <asp:Panel ID="pnlNoRecord" runat="server" style="border: solid 5px #e6edf5; padding: 5px; font-size: 14px; margin-bottom: 400px;">
        Select from and to date
    </asp:Panel>
    <asp:Panel ID="pnlPagePerformance" runat="server" style="border: solid 5px #e6edf5">
        <asp:Repeater ID="rptPagePerformance" runat="server">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <th style="border-bottom: solid 1px #e6edf5; width: 50%;" align="left">
                            <p style="font-weight: 700; padding: 4px;">Date</p>
                        </th>
                        <th style="border-bottom: solid 1px #e6edf5; border-left: solid 1px #e6edf5; width: 50%;" align="left">
                            <p style="font-weight: 700; padding: 4px;">Avg Processing Time (milliseconds)</p>
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="border-bottom: solid 1px #e6edf5; padding: 3px; width: 50%; font-size: 12px;" align="left">
                        <%# Eval("LOG_DATE", "{0:dd MMM yyyy}")%>
                    </td>
                    <td style="border-bottom: solid 1px #e6edf5; padding: 3px; width: 50%; font-size: 12px; border-left: solid 1px #e6edf5;" align="left">
                        <%# Eval("AVG_TIME")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>