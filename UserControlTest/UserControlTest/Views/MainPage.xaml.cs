using UserControlTest.ViewModels;
using Xamarin.Forms;

namespace UserControlTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
