﻿using CurrencyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CurrencyApp.Utils
{
    public class BarChartFactory
    {

        private static Double MaxWidth = 80;
        private static Double MaxHeight = 250;

        private static Double maxNumber = 0;


        public static StackLayout createChart(List<Wallet> listOfWallets)
        {
            StackLayout barChart = new StackLayout
            {               
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //BackgroundColor = Color.GhostWhite
            };

            findMax(listOfWallets);

            foreach (Wallet wallet in listOfWallets)
            {
                barChart.Children.Add(createColumn(wallet.Symbol, wallet.Quantity));
            }
            return barChart;
        }

        private static Double findMax(List<Wallet> listOfWallets) 
        {
        //find max           
            foreach (Wallet wallet in listOfWallets)
            {
                if(wallet.Quantity > maxNumber)
                {
                    maxNumber = wallet.Quantity;
                }
            }
            return maxNumber;
        }

        private static StackLayout createColumn(String title, Double quantity)
        {
            StackLayout column = new StackLayout
            {
                Children =
                {
                    new Label{Text = quantity.ToString(), FontSize = 10, HorizontalOptions = LayoutOptions.CenterAndExpand},
                    new BoxView{
                    Color = Color.FromHex("47525E"),
                    WidthRequest = MaxWidth,
                    HeightRequest = (quantity/maxNumber) * MaxHeight,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand
                    },
                    new Label{Text = title, FontSize = 10, HorizontalOptions = LayoutOptions.Center},
                },
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            return column;
        }
    }
}
