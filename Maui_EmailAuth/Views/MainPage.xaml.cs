using Maui_EmailAuth.ViewModels;

namespace Maui_EmailAuth;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    }

	
}

