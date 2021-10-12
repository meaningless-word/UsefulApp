using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UsefulApp.Models;

namespace UsefulApp.ViewModels
{
	public class ClimateViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public Climate climate { get; private set; }

		public ClimateViewModel()
		{
			climate = new Climate()
			{
				/* предположим, здесь считываются данные с какой-то погодной станции */
				InsideTmprtr = 25,
				OutsideTmprtr = -1,
				AtmPressure = 748
			};
		}

		public string InsideTmprtr { get { return $"{climate.InsideTmprtr:F0} °С"; } }
		public string OutsideTmprtr { get { return $"{climate.OutsideTmprtr:F0} °С"; } }
		public string AtmPressure { get { return $"{climate.AtmPressure:F0} мм"; } }

		protected void OnPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
