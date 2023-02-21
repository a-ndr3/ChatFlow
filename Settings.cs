using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    public interface ISettings
    {
        public string Api { get; set; }
        public string DefaultTheme { get; set; }
    }
    internal class SettingsService : ISettings
    {
        IPreferences settings;

        public SettingsService(IPreferences settings)
        {
            this.settings = settings;
        }

        public string Api { get => settings.Get("Api", ""); set => settings.Set("Api", value); }
        public string DefaultTheme { get => settings.Get("DefaultTheme", ""); set => settings.Set("DefaultTheme", value); }
    }
}
