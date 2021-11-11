using System;
using Xamarin.Forms;

namespace UsefulApp
{
	public class TimePickerEventTrigger : TriggerAction<TimePicker>
	{
		protected override void Invoke(TimePicker sender)
		{
			if (sender.IsFocused)
			{
				VisualStateManager.GoToState(sender, sender.Time < DateTime.Now.TimeOfDay ? "Invalid" : "Valid");
			}
		}
	}
}
