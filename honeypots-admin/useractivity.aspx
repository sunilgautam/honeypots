<%@ Page Title="" Language="C#" MasterPageFile="~/honeypots-admin/honeypotsMasterPage.master" AutoEventWireup="true" CodeFile="useractivity.aspx.cs" Inherits="honeypots_admin_useractivity" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/auto.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align: right; font-size: 12px; margin-right: 5px;"> Page will refresh in <span id="autoTimer">10</span> seconds &nbsp;<a href="javascript:void(0);" onclick="javascript:stopAuto();">Stop</a></p>
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
        Width="900px">
        <Series>
            <asp:Series Name="USER_HIT_SERIES" ChartArea="HITS" XValueMember="HIT_TIME" YValueMembers="HITS" 
                XValueType="Time" YValueType="Int32" Legend="USER_HITS">
                <SmartLabelStyle MaxMovingDistance="1" />
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="HITS">
            
                <AxisX IntervalAutoMode="VariableCount" IntervalOffsetType="Minutes" 
                    IntervalType="Minutes">
                </AxisX>
            
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend  Docking="Bottom" Name="USER_HITS" Title="USER HITS">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Name="Title1" Text="USER HITS PER HOUR">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:honeypots.app.con %>" 
        SelectCommand="GET_USER_ACTIVITY" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="M" Name="PARA" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>