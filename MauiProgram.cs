using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ChatFlow;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{       
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("CascadiaCode.ttf", "CascadiaCode");
			});
        //builder.Services.AddSingleton(new Settings.SettingsService(Preferences.Default));
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
  
}
