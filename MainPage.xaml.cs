namespace ChatFlow;

public partial class MainPage : ContentPage
{
	//TODO change splash pic
	public MainPage()
	{
		InitializeComponent();
	}
    private void MainPageEnterButtonClicked(object sender, EventArgs e)
    {
        //TODO check if the user has api key and if not, redirect to the set api page

        //TODO if the user has api key, redirect to the menu page
        try
        {
            var menuPage = MenuPage.GetInstance();
            Navigation.PushAsync(menuPage);
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

