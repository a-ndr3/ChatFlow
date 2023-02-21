namespace ChatFlow;

public partial class MainPage : ContentPage
{
    ISettings settings;
    //TODO change splash pic
    public MainPage()
    {
        settings = DependencyService.Get<ISettings>();
        InitializeComponent();
    }
    private void MainPageEnterButtonClicked(object sender, EventArgs e)
    {
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
}

