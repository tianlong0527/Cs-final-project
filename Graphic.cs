using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace personal_note
{
    public partial class Graphic : Form
    {
        List<int> stars;
        public Graphic(List<int> stars)
        {
            this.stars = stars;
            InitializeComponent();
            ShowGraph(stars);
        }

        private void ShowGraph(List<int> stars)
        {
            // Create a new Chart
            Chart lineChart = new Chart();
            lineChart.Size = new Size(600, 400);
            lineChart.Location = new Point(10, 10);

            // Create a ChartArea
            ChartArea chartArea = new ChartArea();
            lineChart.ChartAreas.Add(chartArea);

            // Create a Series and add data points
            Series series = new Series
            {
                Name = "StarsData",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line
            };

            // Add data points to the series
            for (int i = 0; i < stars.Count; i++)
            {
                series.Points.Add(new DataPoint(i, stars[i]));
            }

            lineChart.Series.Add(series);

            // Customize the chart (optional)
            lineChart.Legends.Add(new Legend("Legend1"));
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = Color.Blue;

            // Add the Chart to the Form
            this.Controls.Add(lineChart);

        }
    }
}
