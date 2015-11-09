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
        public Battery _battery { get; set; }
        public BatteryReport _report { get; set; }
        public BatteryStatus _status { get; set; }
        public int TimeToFullCharge { get; private set; }
        public int ChargeRemaining { get; private set; }
        public int ChargeCapacity { get; private set; }
        public int ChargeRate { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Devices.Power.Battery",1))
            {
                _battery = Battery.AggregateBattery;
                _report = _battery.GetReport();
                UpdateBatteryStats(_report);
                _battery.ReportUpdated += BatteryReportUpdated;
            }
        }

        private void BatteryReportUpdated( Battery sender, object args )
        {
            throw new NotImplementedException();
            var rep = (sender as Battery).GetReport();
            UpdateBatteryStats(rep);
            
        }

        protected override void OnNavigatedTo( NavigationEventArgs e )
        {
            base.OnNavigatedTo(e);
            FindName("MainStack");
            MainStack.Visibility = Visibility.Visible;
            indicator.Width = slid.Value;
        }

        private void slid_ValueChanged( object sender, RangeBaseValueChangedEventArgs e )
        {
           indicator.Width = slid.Value;
        }

        private void rotate( object sender, RoutedEventArgs e )
        {
            BatteryGrid.UseLayoutRounding = true;
        }

        public void UpdateBatteryStats(BatteryReport report)
        {
            _status = report.Status;
            TimeToFullCharge = (int)report.FullChargeCapacityInMilliwattHours;
            ChargeRemaining = (int)report.RemainingCapacityInMilliwattHours;
            ChargeCapacity = (int)report.DesignCapacityInMilliwattHours;
            ChargeRate = (int)report.ChargeRateInMilliwatts;
        }

    }
}
