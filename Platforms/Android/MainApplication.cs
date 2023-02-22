using Android.App;
using Android.Provider;
using Android.Runtime;

namespace ChatFlow;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
		
    }

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
