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

        public MainPage()
        {
            this.InitializeComponent();
        }

        void UpdateIndicatorColor( double Percentage )
        {
            if (Percentage < 14) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.Red);
            else if (Percentage < 20) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.DarkOrange);
            else if (Percentage < 25) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.Yellow);
            else if (Percentage > 25) BatteryAsset.IndicatorRect.Fill = new SolidColorBrush(Colors.Green);
        }

        void UpdateIndicatoSize( double Percentage )
        {
            BatteryAsset.IndicatorRect.Width = (Percentage/100)*255;
        }
        void UpdateIndicatorText(string text )
        {
            string t = text + "%";
            BatteryAsset.StatsText.Text = t;
        }

        private void slider_ValueChanged( object sender, RangeBaseValueChangedEventArgs e )
        {
            UpdateIndicatoSize(e.NewValue);
            UpdateIndicatorColor(e.NewValue);
            UpdateIndicatorText(e.NewValue.ToString());
            CircleBorder.Opacity = e.NewValue / 100;
        }
    }
}
