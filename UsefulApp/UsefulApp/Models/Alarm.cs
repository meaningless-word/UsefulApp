using System;

namespace UsefulApp.Models
{
	public class Alarm
	{
		public DateTime alarmAt { get; set; }
		public int volumeLevel { get; set; }
		public bool repeatDaily { get; set; }
	}
}
