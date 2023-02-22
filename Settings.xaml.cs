using System;
using System.ComponentModel;

namespace ChatFlow;

public partial class Settings : ContentPage
{

    static Settings instance;
    private Settings()
    {
        BindingContext = this;
        InitializeComponent();
    }

    public static Settings GetInstance()
    {
        if (instance == null)
            instance = new Settings();
        return instance;
    }

    public string Api { get => Preferences.Default.Get("Api", "");
        set 
        { 
            Preferences.Default.Set("Api", value);
            OnPropertyChanged();
        }
    }
    public bool IsDarkThemeActive { get => Preferences.Default.Get("IsDarkThemeActive", true);
        set 
        { 
            Preferences.Default.Set("IsDarkThemeActive", value);
            OnPropertyChanged();
        } 
    }

    private void SetNewKey_Clicked(object sender, EventArgs e)
    {
        try
        {
            App.Current.Dispatcher.Dispatch(async () =>
            {
                var answer = await App.Current.MainPage.DisplayAlert("Info", "This will erase the old key! Continue?", "Yes", "No");
                if (answer)
                {
                    var setApiKeyPage = SetApiKeyPage.GetInstance();
                    Navigation.PushAsync(setApiKeyPage);
                }

            });
        }
        catch (Exception ex)
        {
            throw new Exception("Can't set a new key!");
        }
    }

    private void SwitchedToAnotherTheme_Clicked(object sender, ToggledEventArgs e)
    {
        IsDarkThemeActive = !IsDarkThemeActive;
    }
}