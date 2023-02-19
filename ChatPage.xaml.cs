namespace ChatFlow;

public partial class ChatPage : ContentPage
{
	private static ChatPage instance;
	private ChatPage()
	{
		InitializeComponent();
	}
	public static ChatPage GetInstance()
	{
        if (instance == null)
		{
            instance = new ChatPage();
        }
        return instance;
    }
}