using Doze.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Power;
using Windows.System.Power;

namespace Doze.VM
{
    public class BatteryVM : INotifyPropertyChanged
    {
        public BatteryReport  report { get; set; }

        private BatteryModel _Batterie;
        public BatteryModel Batterie
        {
            get { return _Batterie; }
            set
            {
                if (value != null || value != _Batterie) _Batterie = value;
                OnPropertyChanged("Batterie");
            }
        }

        public BatteryVM()
        {
            Battery B = Battery.AggregateBattery;
            report = B.GetReport();
            if (report.Status == BatteryStatus.NotPresent)
            {
                Batterie = new BatteryModel((int)report.FullChargeCapacityInMilliwattHours, (int)report.FullChargeCapacityInMilliwattHours, (int)report.FullChargeCapacityInMilliwattHours, report.Status, (int)report.FullChargeCapacityInMilliwattHours);
            }

        }


        #region Notify Property Changed Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
