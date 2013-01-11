using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

public partial class h_admin_useractivity : System.Web.UI.Page
{
    string[] chartTypes = { "Column", "Line", "BoxPlot", "Bar", "Point", "FastLine", "FastPoint", "Spline", "StackedArea" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlChartTypr.DataSource = chartTypes;
            ddlChartTypr.DataBind();
            GetTypeCookie();
        }
    }

    protected void ddlChartTypr_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetChartType(Chart_Pages.Series[0], ddlChartTypr.Text);
        SetChartType(Chart_All.Series[0], ddlChartTypr.Text);
        SetTypeCookie(ddlChartTypr.Text);
    }

    protected void SetChartType(Series chartSeries, string type)
    {
        switch (type)
        {
            case "Bar":
                chartSeries.ChartType = SeriesChartType.Bar;
                break;
            case "Line":
                chartSeries.ChartType = SeriesChartType.Line;
                break;
            case "BoxPlot":
                chartSeries.ChartType = SeriesChartType.BoxPlot;
                break;
            case "Column":
                chartSeries.ChartType = SeriesChartType.Column;
                break;
            case "Point":
                chartSeries.ChartType = SeriesChartType.Point;
                break;
            case "CandlestickErrorBar":
                chartSeries.ChartType = SeriesChartType.Candlestick;
                break;
            case "ErrorBar":
                chartSeries.ChartType = SeriesChartType.ErrorBar;
                break;
            case "FastLine":
                chartSeries.ChartType = SeriesChartType.FastLine;
                break;
            case "FastPoint":
                chartSeries.ChartType = SeriesChartType.FastPoint;
                break;
            case "Funnel":
                chartSeries.ChartType = SeriesChartType.Funnel;
                break;
            case "Kagi":
                chartSeries.ChartType = SeriesChartType.Kagi;
                break;
            case "PointAndFigure":
                chartSeries.ChartType = SeriesChartType.PointAndFigure;
                break;
            case "Polar":
                chartSeries.ChartType = SeriesChartType.Polar;
                break;
            case "Radar":
                chartSeries.ChartType = SeriesChartType.Radar;
                break;
            case "Spline":
                chartSeries.ChartType = SeriesChartType.Spline;
                break;
            case "StackedArea":
                chartSeries.ChartType = SeriesChartType.StackedArea;
                break;
            case "StackedBar":
                chartSeries.ChartType = SeriesChartType.StackedBar;
                break;
            case "StepLine":
                chartSeries.ChartType = SeriesChartType.StepLine;
                break;
            case "Stock":
                chartSeries.ChartType = SeriesChartType.Stock;
                break;
            case "ThreeLineBreak":
                chartSeries.ChartType = SeriesChartType.ThreeLineBreak;
                break;
            default:
                chartSeries.ChartType = SeriesChartType.Column;
                break;
        }
    }

    protected void SetTypeCookie(string type)
    {
        HttpCookie tCookie = new HttpCookie("ACTIVITY");
        tCookie["CHART_TYPE"] = type;
        Response.Cookies.Add(tCookie);
    }

    protected void GetTypeCookie()
    {
        HttpCookie tCookie = Request.Cookies["ACTIVITY"];
        if (tCookie != null)
        {
            string chart_type = tCookie["CHART_TYPE"];
            if (chart_type != "" && ddlChartTypr.Items.FindByValue(chart_type) != null)
            {
                ddlChartTypr.Text = chart_type;
                SetChartType(Chart_Pages.Series[0], ddlChartTypr.Text);
                SetChartType(Chart_All.Series[0], ddlChartTypr.Text);
            }
        }
    }

    protected void Chart_Pages_Customize(object sender, EventArgs e)
    {
        if (Chart_Pages.Series[0].ChartType != SeriesChartType.Point)
        {
            foreach (Series series in Chart_Pages.Series)
            {
                foreach (DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.LegendText = point.AxisLabel;
                        point.AxisLabel = string.Empty;
                        point.Label = string.Empty;
                    }
                }
            }
        }
    }

    protected void Chart_All_Customize(object sender, EventArgs e)
    {
        if (Chart_All.Series[0].ChartType != SeriesChartType.Point)
        {
            foreach (Series series in Chart_All.Series)
            {
                foreach (DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.LegendText = point.AxisLabel;
                        point.AxisLabel = string.Empty;
                        point.Label = string.Empty;
                    }
                }
            }
        }
    }
}