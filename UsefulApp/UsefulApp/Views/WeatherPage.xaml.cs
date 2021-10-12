
using UsefulApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage()
		{
			InitializeComponent();
			BindingContext = new ClimateViewModel();
		}
	}
}