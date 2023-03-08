using Maui_EmailAuth.ViewModels;
namespace Maui_EmailAuth.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class EmailFormPage : ContentPage
{
    public EmailFormPage()
    {
        InitializeComponent();
    }
    public EmailFormPage(EmailViewModel emailViewModel)
	{
		InitializeComponent();
		BindingContext = emailViewModel;
    }
}