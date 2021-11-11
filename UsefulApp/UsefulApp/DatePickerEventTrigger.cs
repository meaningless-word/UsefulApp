using System;
using Xamarin.Forms;

namespace UsefulApp
{
	public class DatePickerEventTrigger : TriggerAction<DatePicker>
	{
		protected override void Invoke(DatePicker sender)
		{
			if (sender.IsFocused)
			{
				//sender.TextColor = sender.Date < DateTime.Now.Date ? Color.Red : Color.BlueViolet;
				VisualStateManager.GoToState(sender, sender.Date < DateTime.Now.Date ? "Invalid" : "Valid");
			}
		}
	}
}
