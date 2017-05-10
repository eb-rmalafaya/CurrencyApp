using CurrencyApp.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CurrencyApp.Views
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OxyPlotPage : ContentPage
    {
        private Double number1 = 100;
        private Double number2 = 300;

        public PlotModel PieModel { get; set; }
        public PlotModel AreaModel { get; set; }
        public PlotModel BarModel { get; set; }
        public PlotModel StackedBarModel { get; set; }

        public OxyPlotPage()
        {

            StackLayout column1 = new StackLayout
            {
                Children =
                {
                    new Label{Text = "20", FontSize = 10, HorizontalOptions = LayoutOptions.Center},
                    new BoxView{
                    Color = Color.Gray,
                    WidthRequest = 80,
                    HeightRequest = 150,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand
                    },
                    new Label{Text = "JPY", FontSize = 10, HorizontalOptions = LayoutOptions.Center},
                },
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout column2 = new StackLayout
            {
                Children =
                {
                    new Label{Text = "40", FontSize = 10, HorizontalOptions = LayoutOptions.Center},
                    new BoxView{
                    Color = Color.Cyan,
                    WidthRequest = 80,
                    HeightRequest = 200,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand
                    },
                    new Label{Text = "GBP", FontSize = 10, HorizontalOptions = LayoutOptions.Center},
                },
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout column3 = new StackLayout
            {
                Children =
                {
                    new Label{Text = "110", FontSize = 10, HorizontalOptions = LayoutOptions.CenterAndExpand},
                    new BoxView{
                    Color = Color.Gold,
                    WidthRequest = 80,
                    HeightRequest = 300,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand
                    },
                    new Label{Text = "EUR", FontSize = 10, HorizontalOptions = LayoutOptions.Center},
                },
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout barChart = new StackLayout
            {
                Children =
                {
                    column1,
                    column2,
                    column3
                },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //BackgroundColor = Color.GhostWhite
            };

            /*Orientation = StackOrientation.Horizontal,
     HorizontalOptions = LayoutOptions.FillAndExpand, */



            this.Content = barChart;

            /* PieModel = CreatePieChart();
             AreaModel = CreateAreaChart();
             StackedBarModel = CreateBarChart(true, "Stacked Bar");
             BarModel = CreateBarChart(false, "Un-Stacked Bar");


             //
             PlotView plot = new PlotView
             {
                 Model = StackedBarModel,
                 VerticalOptions = LayoutOptions.Fill,
                 HorizontalOptions = LayoutOptions.Fill,
             };
             //
             //
             var picker = new Picker { Title = "Select a monkey" };
             picker.SelectedIndexChanged += delegate
             {
                 number1 += number2;
                 plot.Model = CreatePieChart();
             };
             foreach (String symbol in CurrencyDTO.top10Currencies)
             {
                 if (picker.SelectedIndex != 0) picker.SelectedIndex = 0;
                 picker.Items.Add(symbol);
             }
             //
             Button button = new Button { Text = "Convert" };
             button.Clicked += delegate
             {
                 //number1 += number2;
                 //plot.Model = CreatePieChart();
             };
             var absolute = new Frame
             {
                 HeightRequest = 100,
                 WidthRequest = 100,
                 VerticalOptions = LayoutOptions.FillAndExpand,
                 HorizontalOptions = LayoutOptions.CenterAndExpand,
                 Content = plot
             };

             var contentView1 = new ContentView
             {
                 Content = new AbsoluteLayout
                 {
                     VerticalOptions = LayoutOptions.FillAndExpand,
                     Children = {
                     plot
                 }
                 }
             };

             var contentView = new ContentView
             {
                 Content = new StackLayout
                 {
                     VerticalOptions = LayoutOptions.FillAndExpand,
                     Children = {
                     picker,
                     button,
                     plot
                 }
                 }
             };


             Content = absolute;*/

        }
        private PlotModel CreatePieChart()
        {
            var model = new PlotModel { Title = "World population by continent" };

            var ps = new PieSeries
            {
                StrokeThickness = .25,
                InsideLabelPosition = .25,
                AngleSpan = 360,
                StartAngle = 0
            };

            // http://www.nationsonline.org/oneworld/world_population.htm
            // http://en.wikipedia.org/wiki/Continent
            ps.Slices.Add(new PieSlice("Africa", number1) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Americas", number1) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Asia", number1));
            ps.Slices.Add(new PieSlice("Europe", number2) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Oceania", number2) { IsExploded = false });
            model.Series.Add(ps);
            return model;
        }

        public PlotModel CreateAreaChart()
        {
            var plotModel1 = new PlotModel { Title = "AreaSeries with crossing lines" };
            var areaSeries1 = new AreaSeries();
            areaSeries1.Points.Add(new DataPoint(0, 50));
            areaSeries1.Points.Add(new DataPoint(10, 140));
            areaSeries1.Points.Add(new DataPoint(20, 60));
            areaSeries1.Points2.Add(new DataPoint(0, 60));
            areaSeries1.Points2.Add(new DataPoint(5, 80));
            areaSeries1.Points2.Add(new DataPoint(20, 70));
            plotModel1.Series.Add(areaSeries1);
            return plotModel1;
        }

        private PlotModel CreateBarChart(bool stacked, string title)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries
            {
                Title = "Series 1",
                IsStacked = stacked,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            s1.Items.Add(new BarItem { Value = 25 });
            s1.Items.Add(new BarItem { Value = 137 });
            s1.Items.Add(new BarItem { Value = 18 });
            s1.Items.Add(new BarItem { Value = 40 });

            var s2 = new BarSeries
            {
                Title = "Series 2",
                IsStacked = stacked,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            s2.Items.Add(new BarItem { Value = 12 });
            s2.Items.Add(new BarItem { Value = 14 });
            s2.Items.Add(new BarItem { Value = 120 });
            s2.Items.Add(new BarItem { Value = 26 });

            var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };
            categoryAxis.Labels.Add("Category A");
            categoryAxis.Labels.Add("Category B");
            categoryAxis.Labels.Add("Category C");
            categoryAxis.Labels.Add("Category D");
            var valueAxis = new LinearAxis
            {
                Position = ValueAxisPosition(),
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMinimum = 0
            };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private AxisPosition CategoryAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Bottom;
            }

            return AxisPosition.Left;
        }

        private AxisPosition ValueAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Left;
            }

            return AxisPosition.Bottom;
        }
    }
}