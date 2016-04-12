using Doze.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Power;
using Windows.System.Power;
using Windows.UI.Xaml;

namespace Doze.VM
{
	public class BatteryVM : INotifyPropertyChanged
	{
		public BatteryReport report { get; set; }
		private Battery B { get; set; }
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

		private bool _isPresent;
		public bool isPresent
		{
			get { return _isPresent; }
			set
			{
				if (value != _isPresent) _isPresent = value;
				OnPropertyChanged("isPresent");
			}
		}


		private bool _isCharging;
		public bool isCharging
		{
			get { return _isCharging; }
			set
			{
				if (value != _isCharging) _isCharging = value;
				OnPropertyChanged("isCharging");
			}
		}

		public BatteryVM()
		{
			B = Battery.AggregateBattery;

			report = B.GetReport();

			if (report.Status == BatteryStatus.NotPresent)
				isPresent = false;

			else if (report.Status != BatteryStatus.NotPresent)
			{
				isPresent = true;
				Batterie = new BatteryModel((int)report.FullChargeCapacityInMilliwattHours , (int)report.FullChargeCapacityInMilliwattHours , (int)report.FullChargeCapacityInMilliwattHours , report.Status , (int)report.FullChargeCapacityInMilliwattHours);
				isCharging = report.Status == BatteryStatus.Charging ? true : false;

			}

			B.ReportUpdated += B_ReportUpdated;
		}

		private void B_ReportUpdated( Battery sender , object args )
		{
			report = B.GetReport();

			if (report.Status == BatteryStatus.NotPresent)
				isPresent = false;

			else if (report.Status != BatteryStatus.NotPresent)
			{
				Batterie = new BatteryModel((int)report.FullChargeCapacityInMilliwattHours , (int)report.FullChargeCapacityInMilliwattHours , (int)report.FullChargeCapacityInMilliwattHours , report.Status , (int)report.FullChargeCapacityInMilliwattHours);
				isCharging = report.Status == BatteryStatus.Charging ? true : false;

			}

		}


		#region Notify Property Changed Members
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged( string propertyName )
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this , new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
