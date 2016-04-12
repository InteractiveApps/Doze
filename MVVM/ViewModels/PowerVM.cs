using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Power;
using Windows.System.Power;

namespace Doze.MVVM.ViewModels
{
	public class PowerVM : INotifyPropertyChanged
	{
		#region properties

		private int? _PercentageRemaining;
		public int? PercentageRemaining
		{
			get { return _PercentageRemaining; }
			set
			{
				if (value != null || value != _PercentageRemaining) _PercentageRemaining = value;
				OnPropertyChanged();
			}
		}

		private BatteryStatus _status;
		public BatteryStatus status
		{
			get { return _status; }
			set
			{
				if (value != _status) _status = value;
				OnPropertyChanged();
			}
		}

		private DateTimeOffset _TimeToFullCharge;
		public DateTimeOffset TimeToFullCharge
		{
			get { return _TimeToFullCharge; }
			set
			{
				if (value != null || value != _TimeToFullCharge) _TimeToFullCharge = value;
				OnPropertyChanged();
			}
		}

		private int? _ChargeRate;
		public int? ChargeRate
		{
			get { return _ChargeRate; }
			set
			{
				if (value != null || value != _ChargeRate) _ChargeRate = value;
				OnPropertyChanged();
			}
		}

		private DateTimeOffset _TimeToDisCharge;
		public DateTimeOffset TimeToDisCharge
		{
			get { return _TimeToDisCharge; }
			set
			{
				if (value != null || value != _TimeToDisCharge) _TimeToDisCharge = value;
				OnPropertyChanged();
			}
		}

		#endregion

		public Battery _battery { get; set; }

		#region constructor
		public PowerVM()
		{
			_battery = Battery.AggregateBattery;
			_battery.ReportUpdated += _battery_ReportUpdated;
			UpdateBatteryStatus();
		}

		#endregion

		#region Methods
		void UpdateBatteryStatus()
		{
			var report = _battery.GetReport();
			status = report.Status;
			switch (status)
			{
				case BatteryStatus.Charging:

					break;
				case BatteryStatus.Discharging:

					break;
				case BatteryStatus.Idle:

					break;
				case BatteryStatus.NotPresent:

					break;
			}

		}
		#endregion

		#region Events
		/// <summary>
		/// This method handles the report updated event by updating all the values required by VM.
		/// </summary>
		/// <param name="sender">The battery the event is fired from.</param>
		/// <param name="args">The arguments</param>
		private void _battery_ReportUpdated( Battery sender , object args )
		{
			UpdateBatteryStatus();
		}

		#endregion

		#region Notify Property Changed Method
		/// <summary>
		/// This is the event tha gets raised whenever a property is changed in this class.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// The Method that needs to be called on the property that is changed.
		/// </summary>
		/// <param name="propertyName">The name of the property that is changed.</param>
		private void OnPropertyChanged( [CallerMemberName]string propertyName = null )
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
