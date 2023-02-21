namespace ChatFlow;

public partial class SetApiKeyPage : ContentPage
{
	static SetApiKeyPage instance;
	private SetApiKeyPage()
	{
		InitializeComponent();
	}
	public static SetApiKeyPage GetInstance()
	{
        if (instance == null)
		{
            instance = new SetApiKeyPage();
        }
        return instance;
    }

    private void SaveApiKeySetting_Clicked(object sender, EventArgs e)
    {

    }
}