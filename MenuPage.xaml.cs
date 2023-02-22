namespace ChatFlow;

public partial class MenuPage : ContentPage
{
	static MenuPage instance;
    static Settings settings = Settings.GetInstance();
    private MenuPage()
	{
		InitializeComponent();
	}

	public static MenuPage GetInstance()
	{
        if (instance == null)
		{
            instance = new MenuPage();
        }

        return instance;
    }

    private async void OpenHistory_Clicked(object sender, EventArgs e)
    {
        //var settings = DependencyService.Get<Settings.ISettings>();
        IConnection connection = new HttpConnection();
        IChatGPT chat = new ChatGPT3(new HttpClient(),settings.Api,Endpoints.History);
        Dictionary<string, string[]> chatHistory = new Dictionary<string, string[]>();
        
        try
        {
            if (chat is ChatGPT3 gpt3)
            {
                chatHistory = await gpt3.GetAllChatsFromHistoryAsync();
            }
            var historyPage = HistoryPage.GetInstance(chatHistory);
            await Navigation.PushAsync(historyPage);
        }
        catch (Exception ex)
        {
            Dispatcher.Dispatch(() =>
            {
                DisplayAlert("Error", "Can't open history window!", "Cancel");
            });
        }
    }

    private void OpenChat_Clicked(object sender, EventArgs e)
    {
        try
        {
            var chatPage = ChatPage.GetInstance();
            Navigation.PushAsync(chatPage);
        }
        catch (Exception ex)
        {
            Dispatcher.Dispatch(() =>
            {
                DisplayAlert("Error", "Can't open chat window!", "Cancel");
            });
        }
    }
}