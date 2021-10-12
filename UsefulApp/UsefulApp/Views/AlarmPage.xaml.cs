using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			datePicker.MinimumDate = DateTime.Now;
			datePicker.MaximumDate = DateTime.Now.AddDays(7);
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			DisplayAlert("Уведомление", $"Будильник сработает через {(ViewModel.alarm.alarmAt - DateTime.Now):dd\\.hh\\:mm}", "Ok") ;
		}
	}
}