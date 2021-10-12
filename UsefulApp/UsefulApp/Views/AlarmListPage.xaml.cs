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
	public partial class AlarmListPage : ContentPage
	{
		public AlarmListPage()
		{
			InitializeComponent();
			BindingContext = new AlarmListViewModel() { Navigation = this.Navigation };
		}
	}
}