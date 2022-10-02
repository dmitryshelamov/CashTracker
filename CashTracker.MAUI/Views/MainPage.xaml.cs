using CashTracker.MAUI.ViewModels;

namespace CashTracker.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            // BindingContext = new MonkeysViewModel();
        }

    }
}