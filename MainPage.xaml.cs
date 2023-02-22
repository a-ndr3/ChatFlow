namespace ChatFlow;

public partial class MainPage : ContentPage
{
    //IServiceCollection _services;
    Settings settings = Settings.GetInstance();
    public MainPage()
   {      
        InitializeComponent();
    }
    private void MainPageEnterButtonClicked(object sender, EventArgs e)
    {
        //var settings = DependencyService.Get<Settings.ISettings>();
        try
        {
            if (settings.Api == null || settings.Api == "")
            {
                var setApiKeyPage = SetApiKeyPage.GetInstance();
                Navigation.PushAsync(setApiKeyPage);
            }
            else
            {
                var menuPage = MenuPage.GetInstance();
                Navigation.PushAsync(menuPage);
            }
            //TODO splash screen loading animation of symbols c->h->a->t 

            //TODO check if the user has api key and if not, redirect to the set api page

            //TODO if the user has api key, redirect to the menu page

            //var menuPage = MenuPage.GetInstance();
            //Navigation.PushAsync(menuPage);
        }
        catch (System.NullReferenceException nulrefex)
        {
            Dispatcher.Dispatch(() =>
            {
                DisplayAlert("Error", "Possible problem with reading settings!", "Cancel");
            });
        }
        catch (Exception ex)
        {
            Dispatcher.Dispatch(() =>
            {
                DisplayAlert("Error", "Can't open menu window!", "Cancel");
            });
        }

    }

    private void SettingsButtonClicked(object sender, EventArgs e) 
    {
        var settingsPage = Settings.GetInstance();
        Navigation.PushAsync(settingsPage);
    }
}

