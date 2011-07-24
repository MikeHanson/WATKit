using System;
using System.Windows;
using System.Threading;
using System.Windows.Controls;

namespace WATKit.TestApp
{
	public partial class MainWindow: Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnEnableDisabledButtonClick(object sender, RoutedEventArgs e)
		{
			Thread.Sleep(3);
			this.DisabledButton.IsEnabled = true;
		}

		private void OnIChangeMyNameButtonClick(object sender, RoutedEventArgs e)
		{
			this.IChangeMyNameButton.Content = "My Name Has Changed";
		}

		private void OnShowInvisibleButtonClick(object sender, RoutedEventArgs e)
		{
			this.InvisibleButton.Visibility = Visibility.Visible;
		}

		private void OnAddDynamicButtonClick(object sender, RoutedEventArgs e)
		{
			this.LeftColumn.Children.Add(new Button 
			{
				Name = "DynamicButton",
				Content = "Dynamic Button",
				Width = this.DisabledButton.Width 
			});
		}
	}
}
