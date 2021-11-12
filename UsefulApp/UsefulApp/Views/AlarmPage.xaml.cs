using System;
using System.ComponentModel;
using UsefulApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlarmPage : ContentPage
	{
		public AlarmViewModel ViewModel { get; private set; }
		public AlarmPage(AlarmViewModel viewModel)
		{
			InitializeComponent();
			ViewModel = viewModel;
			BindingContext = ViewModel;
			btnSave.IsEnabled = false;
			datePicker.DateSelected += (sender, e) => PickersChanged(sender, new PropertyChangedEventArgs("Date"));
			timePicker.PropertyChanged += (sender, e) => PickersChanged(sender, e);
		}

		private void PickersChanged(object sender, PropertyChangedEventArgs e)
		{
			VisualStateManager.GoToState(datePicker, ViewModel.alarm.alarmAt < DateTime.Now ? "Invalid" : "Valid");
			VisualStateManager.GoToState(timePicker, ViewModel.alarm.alarmAt < DateTime.Now ? "Invalid" : "Valid");
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			DisplayAlert("Уведомление", $"Будильник сработает через {(ViewModel.alarm.alarmAt - DateTime.Now):dd\\.hh\\:mm}", "Ok");
		}

		private void Ready_Clicked(object sender, EventArgs e)
		{
			if (ViewModel.alarm.alarmAt < DateTime.Now)
			{
				lblReady.Text = $"Будильник не может быть установлен на выбранное время!";
			}
			else
			{
				lblReady.Text = $"Будильник будет установлен на {(ViewModel.alarm.alarmAt):dd\\.MM\\.yyyy HH\\:mm}";
				datePicker.IsEnabled = false;
				timePicker.IsEnabled = false;
				slider.IsEnabled = false;
				repeaterSwitch.IsEnabled = false;
				btnSave.IsEnabled = true;
			}

		}
	}
}