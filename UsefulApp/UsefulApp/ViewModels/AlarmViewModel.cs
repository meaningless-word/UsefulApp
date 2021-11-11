using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UsefulApp.Models;

namespace UsefulApp.ViewModels
{
	public class AlarmViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public AlarmListViewModel ListViewModel { get; }

		public Alarm alarm { get; private set; }

		public AlarmViewModel(AlarmListViewModel listViewModel)
		{
			ListViewModel = listViewModel;
			alarm = new Alarm
			{
				/* начальные установки для новой сущности */
				alarmAt = DateTime.Now,
				volumeLevel = 50,
				repeatDaily = false
			};
		}

		public DateTime alarmDate
		{
			get { return alarm.alarmAt.Date; }
			set
			{
				if (alarm.alarmAt.Date != value.Date)
				{
					alarm.alarmAt = value.Date + alarm.alarmAt.TimeOfDay;
					OnPropertyChanged("alarmDate");
				}
			}
		}

		public TimeSpan alarmTime
		{
			get { return alarm.alarmAt.TimeOfDay; }
			set
			{
				if (alarm.alarmAt.TimeOfDay != value)
				{
					alarm.alarmAt = alarm.alarmAt.Date + value;
					OnPropertyChanged("alarmTime");
				}
			}
		}

		public int volumeLevel
		{
			get { return alarm.volumeLevel; }
			set
			{
				if (alarm.volumeLevel != value)
				{
					alarm.volumeLevel = value;
					OnPropertyChanged("volumeLevel");
				}

			}
		}

		public bool repeatDaily
		{
			get { return alarm.repeatDaily; }
			set
			{
				if (alarm.repeatDaily != value)
				{
					alarm.repeatDaily = value;
					OnPropertyChanged("repeatDaily");
				}
			}
		}

		protected void OnPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
