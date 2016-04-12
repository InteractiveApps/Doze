using Doze.VM;
using System;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.UI.Core;

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

		public BatteryVM B_VM { get; private set; }

		public MainPage()
		{
			InitializeComponent();
			B_VM = new BatteryVM();
			DataContext = B_VM;
		}

		protected async override void OnNavigatedTo( NavigationEventArgs e )
		{
			base.OnNavigatedTo(e);
			this.FindName("MainGrid");
			MainGrid.Visibility = Visibility.Visible;

			await Dispatcher.RunAsync(CoreDispatcherPriority.High , ()=> UpdateIndicator(B_VM) );
		}

		void  UpdateIndicatorColor( double Percentage )
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
				//if (BVM.isCharging)
				//{
				//	ElectricPlugText.FontSize = 50;
				//	ElectricPlugText.Text = "🔌";
				//}
			}
			else
			{
				ShowEmptyBattery();
				ElectricPlugText.FontSize = 15;
				Random r = new Random();
				ElectricPlugText.Text = OopsText[r.Next(0 , OopsText.Length - 1)];
			}

		}

	}
}
