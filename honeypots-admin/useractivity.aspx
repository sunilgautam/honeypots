<%@ Page Title="" Language="C#" MasterPageFile="~/honeypots-admin/honeypotsMasterPage.master" AutoEventWireup="true" CodeFile="useractivity.aspx.cs" Inherits="honeypots_admin_useractivity" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/auto.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align: right; font-size: 12px; margin-right: 5px;"> Page will refresh in <span id="autoTimer">10</span> seconds &nbsp;<a href="javascript:void(0);" onclick="javascript:stopAuto();">Stop</a></p>
    <div style="margin-left: 15px; margin-bottom: 5px;">
        <p> Chart type : 
            <asp:DropDownList ID="ddlChartTypr" CssClass="dropList" runat="server" AutoPostBack="true"
                onselectedindexchanged="ddlChartTypr_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
    </div>
    <div style="border: solid 5px #e6edf5">
        <p style="font-weight: 700; text-align: center; margin-top: 5px;">USER HITS PER HOUR (PAGES)</p>
        <asp:Chart ID="Chart_Pages" runat="server" DataSourceID="SqlDataSource1" 
            Width="900px" oncustomize="Chart_Pages_Customize">
            <Series>
                <asp:Series Name="USER_HIT_SERIES" ChartArea="HITS" XValueMember="HIT_TIME" YValueMembers="HITS" LegendText="User hits" Label="#VALY" LabelForeColor="#222222" ChartType="Column"
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
                <asp:Legend  Docking="Bottom" Name="USER_HITS">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:honeypots.app.con %>" 
            SelectCommand="GET_USER_ACTIVITY" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="H" Name="PARA" Type="String" />
                <asp:Parameter DefaultValue="PAGE" Name="RESOURCE_TYPE" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div style="border: solid 5px #e6edf5; margin-top: 10px;">
        <p style="font-weight: 700; text-align: center; margin-top: 5px;">USER HITS PER HOUR (ALL RESOURCES)</p>
        <asp:Chart ID="Chart_All" runat="server" DataSourceID="SqlDataSource2" 
            Width="900px" oncustomize="Chart_All_Customize">
            <Series>
                <asp:Series Name="USER_HIT_SERIES" ChartArea="HITS" XValueMember="HIT_TIME" YValueMembers="HITS" LegendText="User hits" Label="#VALY" LabelForeColor="#222222" ChartType="Column"
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
                <asp:Legend  Docking="Bottom" Name="USER_HITS">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:honeypots.app.con %>" 
            SelectCommand="GET_USER_ACTIVITY" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="H" Name="PARA" Type="String" />
                <asp:Parameter DefaultValue="ALL" Name="RESOURCE_TYPE" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>