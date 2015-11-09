using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Doze
{
    public sealed partial class BatteryControl : UserControl
    {


        public StackPanel BatteryGrid
        {
            get { return (StackPanel)GetValue(BatteryGridProperty); }
            set { SetValue(BatteryGridProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BatteryGrid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BatteryGridProperty =
            DependencyProperty.Register("BatteryGrid", typeof(StackPanel), typeof(StackPanel), new PropertyMetadata(null));



        public RotateTransform BatteryRotateTransform
        {
            get { return (RotateTransform)GetValue(BatteryRotateTransformProperty); }
            set { SetValue(BatteryRotateTransformProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BatteryRotateTransform.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BatteryRotateTransformProperty =
            DependencyProperty.Register("BatteryRotateTransform", typeof(RotateTransform), typeof(RotateTransform), new PropertyMetadata(null));





        public Rectangle IndicatorRect
        {
            get { return (Rectangle)GetValue(IndicatorRectProperty); }
            set { SetValue(IndicatorRectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicatorRect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndicatorRectProperty =
            DependencyProperty.Register("IndicatorRect", typeof(Rectangle), typeof(Rectangle), new PropertyMetadata(null));




        public TextBlock StatsText
        {
            get { return (TextBlock)GetValue(StatsTextProperty); }
            set { SetValue(StatsTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatsText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatsTextProperty =
            DependencyProperty.Register("StatsText", typeof(TextBlock), typeof(TextBlock), new PropertyMetadata(null));



        public BatteryControl()
        {
            this.InitializeComponent();
            BatteryGrid = Battery_Grid;
            BatteryRotateTransform = Battery_RotateTransform;
            IndicatorRect = indicator;
            StatsText = StatusText;
        }
    }
}
