using System;
using UsefulApp.Views;
using Xamarin.Forms;

namespace UsefulApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void GetWeather_Click(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new WeatherPage());
		}

		private async void alarmButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AlarmListPage());
		}
	}
}
