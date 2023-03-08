using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_EmailAuth.ViewModels
{
    public partial class EmailViewModel: ObservableObject
    {
        public Models.Email GetEmail { get; set; }
        public EmailViewModel()
        {
            GetEmail= new();
        }

        [RelayCommand]
        private async void SendMail()
        {
            try
            {
                if (string.IsNullOrEmpty(GetEmail.Oggetto) ||
                    string.IsNullOrEmpty(GetEmail.Body) ||
                    string.IsNullOrEmpty(GetEmail.A))
                {
                    await App.Current.MainPage.DisplayAlert("Errore!", "Si prega di compilare i campi obbligatori", "Ok");
                    return;
                }

                var message = new EmailMessage()
                {
                    Subject = GetEmail.Oggetto,
                    Body = GetEmail.Body,
                    To = new List<string>(GetEmail.A.Split(';'))
                };

                if (GetEmail.A.Length > 0)
                {
                    message.Cc = new List<string>(GetEmail.A.Split(';'));
                    await Microsoft.Maui.ApplicationModel.Communication.Email.Default.ComposeAsync(message);

                }
            }
            catch (FeatureNotEnabledException fbsEx)
            {
                await App.Current.MainPage.DisplayAlert("Errore!", fbsEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Errore!", ex.Message, "Ok");
            }
        }
    }
}
