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
		private AlarmListViewModel _listViewModel;

		public Alarm alarm { get; private set; }

		public AlarmViewModel()
		{
			alarm = new Alarm
			{
				alarmAt = DateTime.Now.AddHours(1),
				volumeLevel = 50,
				repeatDaily = false
			};
		}

		public AlarmListViewModel ListViewModel
		{
			get { return _listViewModel; }
			set
			{
				if (_listViewModel != value)
				{
					_listViewModel = value;
					OnPropertyChanged("ListViewModel");
				}
			}

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

		public string sAlarmDate { get { return alarm.alarmAt.ToString("dd.MM.yyyy"); } }
		public string sAlarmTime { get { return alarm.alarmAt.ToString("HH:mm"); } }
		public string sAlarmVolumeLevel { get { return String.Format("{0:F0}%", alarm.volumeLevel); } }

		protected void OnPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
