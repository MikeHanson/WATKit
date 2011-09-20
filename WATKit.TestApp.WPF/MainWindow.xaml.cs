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
			Thread.Sleep(2); // simulate some processing
			this.DisabledButton.IsEnabled = true;
		}

		private void OnIChangeMyNameButtonClick(object sender, RoutedEventArgs e)
		{
			this.IChangeMyNameButton.Content = "My Name Has Changed";
			Thread.Sleep(2); // give the change time to register

			//TODO: probably need a wait on property value change
		}

		private void OnShowInvisibleButtonClick(object sender, RoutedEventArgs e)
		{
			Thread.Sleep(2); // simulate some processing
			this.InvisibleButton.Visibility = Visibility.Visible;
		}

		private void OnAddDynamicButtonClick(object sender, RoutedEventArgs e)
		{
			Thread.Sleep(2); // simulate some processing
			this.LeftColumn.Children.Add(new Button 
			{
				Name = "DynamicButton",
				Content = "Dynamic Button",
				Width = this.DisabledButton.Width 
			});
		}

		private void OpenChildWindowButton_Click(object sender, RoutedEventArgs e)
		{
			new ChildWindow().ShowDialog();
		}
	}
}
