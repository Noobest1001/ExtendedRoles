using System.ComponentModel;

namespace ExtendedRoles.Configs
{
    public class SpawnManager
    {
        [Description("How many respawn waves must occur before considering The Saviors to spawn.")]
        public int Respawns { get; private set; } = 2;

        [Description("The maximum number of times The Saviors can spawn per game.")]
        public int MaxSpawns { get; set; } = 1;

        [Description("Probability of a Red Right Hand Squad replacing a MTF spawn")]
        public int Probability { get; private set; } = 5;

        [Description("The maximum size of a Red Right Hand squad")]
        public int MaxSquad { get; private set; } = 31;

        [Description("Alpha 0 entrance Cassie Message")]
        public string Aph0AnnouncementCassie { get; private set; } = "By order of the O5 Council MTFUnit alpha 0 designated {designation} has been authorized and activated AllRemaining AwaitingRecontainment {scpnum}";
        public string RRRAnnouncmentCassieNoScp { get; private set; } = "By order of the O5 Council MTFUnit alpha 0 designated {designation} has been authorized and activated AllRemaining NoSCPsLeft";
        
        [Description("NTF entrance Cassie Message (leave empty to use default NTF cassie entrance)")]
        public string NtfAnnouncementCassie { get; private set; } = "MTFUnit epsilon 11 designated {designation} hasentered AwaitingRecontainment {scpnum}";
        public string NtfAnnouncmentCassieNoScp { get; private set; } = "MTFUnit epsilon 11 designated {designation} hasentered NoSCPsLeft";

        [Description("Cassie Subtitles")]
        public bool Subtitles { get; private set; } = true;

        [Description("Cassie Text Espilon-11 SCPs")]
        public string CassieTextMtfSCPs { get; private set; } = "Mobile Task Force Unit Espilon-11, designated {designation} has entered the facility. All remaining personnel are advised to proceed with standard evaction protocols until a MTF squad reaches your destination. awaiting recontainment of {scpnum}.";

        [Description("Cassie Text Espilon-11 No SCPs")]
        public string CassieTextMtfNoSCPs { get; private set; } = "Mobile Task Force Unit Espilon-11, designated {designation} has entered the facility. All remaining personnel are advised to proceed with standard evaction protocols until a MTF squad reaches your destination. Substantial threat remains within the facility - exercise caution.";

        [Description("Cassie Text Alpha 0 SCPs")]
        public string CassieTextUiuSCPs { get; private set; } = "By order of the 05-Council, Mobile Task Force Unit Alpha-0, designated {designation} has been authorized and activated. Awaiting recontainment of {scpnum}";

        [Description("Cassie Text Alpha 0 No SCPs")]
        public string CassieTextUiuNoSCPs { get; private set; } = "By order of the 05-Council, Mobile Task Force Unit Alpha-0, designated {designation} has been authorized and activated. Substantial threat remains within the facility - exercise caution.";
    }
}