using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UsefulApp.Views;
using Xamarin.Forms;

namespace UsefulApp.ViewModels
{
	public class AlarmListViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		public ObservableCollection<AlarmViewModel> Alarms { get; set; }

		private AlarmViewModel _selectedAlarm;
		public INavigation Navigation { get; set; }

		public ICommand BackCommand { get; protected set; }
		public ICommand SaveAlarmCommand { get; protected set; }
		public ICommand CreateAlarmCommand { get; protected set; }
		public ICommand DeleteAlarmCommand { get; protected set; }


		public AlarmListViewModel()
		{
			Alarms = new ObservableCollection<AlarmViewModel>();
			/* где-то здесь нужно связать коллекцию с хранилищем */

			BackCommand = new Command(Back);
			SaveAlarmCommand = new Command(SaveAlarm);
			CreateAlarmCommand = new Command(CreateAlarm);
			DeleteAlarmCommand = new Command(DeleteAlarm);
		}

		public AlarmViewModel SelectedAlarm
		{
			get { return _selectedAlarm; }
			set
			{
				if (_selectedAlarm != value)
				{
					AlarmViewModel tmpAlarm = value;
					_selectedAlarm = null;
					OnPropertyChanged("SelectedAlarm");
					Navigation.PushModalAsync(new AlarmPage(tmpAlarm));
				}
			}
		}

		protected void OnPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}

		private void Back()
		{
			Navigation.PopModalAsync();
		}

		private void SaveAlarm(object alarmObject)
		{
			AlarmViewModel alarm = alarmObject as AlarmViewModel;
			if (alarm != null && !Alarms.Contains(alarm))
			{
				Alarms.Add(alarm);
			}
			Back();
		}

		private void CreateAlarm()
		{
			Navigation.PushAsync(new AlarmPage(new AlarmViewModel() { ListViewModel = this }));
		}

		private void DeleteAlarm(object alarmObject)
		{
			AlarmViewModel alarm = alarmObject as AlarmViewModel;
			if (alarm != null)
			{
				Alarms.Remove(alarm);
			}
			Back();
		}
	}
}
