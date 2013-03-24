<%@ Page Title="" Language="C#" MasterPageFile="~/h-admin/honeypotsMasterPage.master" AutoEventWireup="true" CodeFile="activityhistory.aspx.cs" Inherits="h_admin_activityhistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="margin-left: 15px; margin-bottom: 5px; margin-top: 5px;">
        <p> Date : 
            <asp:TextBox ID="txtDate" CssClass="inpText" style="width: 170px;" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="txtDate_CalendarExtender" Format="dd-MMM-yyyy" runat="server" Enabled="True" TargetControlID="txtDate">
            </asp:CalendarExtender>
            &nbsp;&nbsp;
            <asp:Button ID="btnGo" runat="server" style="padding: 3px; border: solid 2px #AFAFAF; cursor: pointer;" Text="GO" onclick="btnGo_Click" />
        </p>
    </div>
    <asp:Panel ID="pnlNoRecord" runat="server" style="border: solid 5px #e6edf5; padding: 5px; font-size: 14px; margin-bottom: 400px;">
        Select a date
    </asp:Panel>
    <asp:Panel ID="pnlPageHits" runat="server" style="border: solid 5px #e6edf5">
        <p style="font-weight: 700; text-align: center; margin-top: 5px;"><asp:Literal ID="litPage" runat="server"></asp:Literal></p>
        <asp:Chart ID="Chart_Pages" runat="server" Width="900px" OnCustomize="Chart_Pages_Customize">
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
    </asp:Panel>
    <asp:Panel ID="pnlAllHits" runat="server" style="border: solid 5px #e6edf5">
        <p style="font-weight: 700; text-align: center; margin-top: 5px;"><asp:Literal ID="litAll" runat="server"></asp:Literal></p>
        <asp:Chart ID="Chart_All" runat="server" Width="900px" OnCustomize="Chart_All_Customize">
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
    </asp:Panel>
</asp:Content>