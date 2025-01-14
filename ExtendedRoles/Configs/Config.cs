using Exiled.API.Interface;
using System.ComponentModel;

namespace ExtendedConfig
{
    public sealed class Config: IConfig
    {
        [Description("Weather or not the plugin is enabled")]
        public bool IsEnabled {get; set;} = true;
        
        [Description("Weather the plugin will display debug text")]
        public bool DebugMode = false;

        [Description("Weather the Custom Role are allowed to spawn")]
        public bool ERspawn = true;

        [Description("Something cool I found in the Exiled Documentation")]
        public EnvironmentType environment = 0;

        public A_Anesthetic Camniste {get; set;} = new();
        public Anti049 Anti049 {get; set;} = new();
        public NTFGhost NTFGhost {get; private set;} = new();
        public NTFMedic NTFMedic {get; private set;} = new();
        public Alpha_0Captain Alpha_0Captain {get; private set;} = new();
        public Alpha_0Private Alpha_0Private {get; private set;} = new();
        public Alpha_0Sargent Alpha_0Sargent {get; private set;} = new();
        public Abilities.MedMist MedMist {get; set;} = new();

        
    }
}