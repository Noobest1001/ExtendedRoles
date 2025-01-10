using Exiled.API.Interface;
using System.ComponentModel;

namespace ExtendedRoles.Config
{
    public sealed class Config: IConfig
    {
        [Description("Weather or not the plugin is enabled")]
        public bool IsEnabled {get; set;} = true;
        
        [Description("Weather the plugin will display debug text")]
        public bool DebugMode = false;

        [Description("Weather the Custom Role are allowed to spawn")]
        public bool ERspawn = true;

        
    }
}