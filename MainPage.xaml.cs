using Doze.VM;
using Microsoft.AdMediator.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Power;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Power;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Doze
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        string[ ] OopsText =
        {
            "Oops! Check your Battery.",
            "I Don't think you have one.",
            "No Battery Found.",
            "Is your Battery functioning?"
        };

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo( NavigationEventArgs e )
        {
            base.OnNavigatedTo(e);
            this.FindName("MainGrid");
            MainGrid.Visibility = Visibility.Visible;
            B_VM = new VM.BatteryVM();
            UpdateIndicator(B_VM);
        }

        void UpdateIndicatorColor( double Percentage )
        {
            if (Percentage < 14) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.Red);
            else if (Percentage < 20) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.DarkOrange);
            else if (Percentage < 25) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.Yellow);
            else if (Percentage > 25) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.Green);
        }

        void UpdateIndicatorSize( double Percentage )
        {
            BatteryAsset.IndicatorRect.Width = (Percentage / 100) * 255;
        }

        void UpdateIndicatorText( string text )
        {
            string t = text + "%";
            BatteryAsset.StatsText.Text = t;
        }

        void ShowEmptyBattery()
        {
            BatteryAsset.IndicatorRect.Width = 0;
            BatteryAsset.StatsText.Text = "Error !";
        }

        void UpdateIndicator( BatteryVM BVM )
        {
            if (BVM.isPresent)
            {
                double percentage = (BVM.Batterie.RemainingCapacity / BVM.Batterie.BatteryCapacity) * 100;
                UpdateIndicatorColor(percentage);
                UpdateIndicatorSize(percentage);
                UpdateIndicatorText(percentage.ToString());
                if (BVM.isCharging)
                {
                    ElectricPlugText.FontSize = 50;
                    ElectricPlugText.Text = "🔌";
                }
            }
            else
            {
                ShowEmptyBattery();
                ElectricPlugText.FontSize = 15;
                Random r = new Random();
                ElectricPlugText.Text = OopsText[r.Next(0, 3)];
            }

        }

    }
}
