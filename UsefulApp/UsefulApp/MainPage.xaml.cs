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
			WeatherPage weatherPage = new WeatherPage();
			await Navigation.PushModalAsync(weatherPage);
		}

		private async void alarmButton_Clicked(object sender, EventArgs e)
		{
			AlarmListPage alarmListPage = new AlarmListPage();
			await Navigation.PushAsync(alarmListPage);
		}
	}
}
