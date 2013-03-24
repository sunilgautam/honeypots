<%@ Page Title="" Language="C#" MasterPageFile="~/h-admin/honeypotsMasterPage.master" AutoEventWireup="true" CodeFile="performance.aspx.cs" Inherits="h_admin_performance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .pageAnc
        {
            text-decoration: none;
            font-size: 12px;
            color: #5C5A4E;
        }
        
        .pageAnc:hover
        {
            text-decoration: underline;
            color: #000000;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="border: solid 5px #e6edf5">
        <asp:Repeater ID="rptPageList" runat="server">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <th style="border-bottom: solid 1px #e6edf5">
                            <p style="font-weight: 700; padding: 4px;">Page list</p>
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="border-bottom: solid 1px #e6edf5; padding: 3px;">
                        <a href='performancedetails.aspx?page=<%# Eval("REQUEST_PAGE")%>' target="_blank" class="pageAnc"><%# Eval("REQUEST_PAGE")%></a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>