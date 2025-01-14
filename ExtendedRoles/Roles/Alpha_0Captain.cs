using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace ExtendedRoles.Roles
{
    [CustomRole(RoleTypeId.NtfCaptain)]
    public class Alpha_0Captain : CustomRole
    {
        public override uint Id { get; set; } = 14;
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfCaptain;
        public override int MaxHealth { get; set; } = 125;
        public override string Name { get; set; } = "Alpha-0 Captain";
        public override string Description { get; set; } = "The 05 has ordered you to regain control of the site";
        public override string CustomInfo { get; set; } = "Alpha-0 Captain";
        public override bool IgnoreSpawnSystem { get; set; } = true; 

        public override List<string> Inventory { get; set; } = new()
        {
            $"{ItemType.KeycardMTFOperative}",
            $"{ItemType.GunFRMG0}",
            $"{ItemType.Medkit}",
            $"{ItemType.Adrenaline}",
            $"{ItemType.Radio}",
            $"{ItemType.GrenadeHE}",
            $"{ItemType.ArmorHeavy}"
        }

        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new()
                {
                    Role = RoleTypeId.NtfPrivate,
                    Chance = 100
                }
            }
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
        {
            { AmmoType.Nato556, 200 }
        };
    }
}