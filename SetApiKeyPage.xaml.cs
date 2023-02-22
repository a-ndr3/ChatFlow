using System.ComponentModel;

namespace ChatFlow;

public partial class SetApiKeyPage : ContentPage
{
	static SetApiKeyPage instance;
    Settings settings = Settings.GetInstance();
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
        settings.Api = apiFieldEditor.Text.Trim();

        Navigation.PopAsync();
    }
}