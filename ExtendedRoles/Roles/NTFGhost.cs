using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

using PlayerEvent = Exiled.Events.Handlers.Player;

namespace ExtendedRoles.Roles
{
    [CustomRole(RoleTypeId.NtfSpecialist)]
    public class ExtendedRoles : CustomRole
    {
        public override uint Id { get; set; } = 22;
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSpecialist;
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get; set; } = "NTF Ghost";
        public override string Description { get; set; } = "Help the NTF unit with the recontainment of the facility";
        public override string CustomInfo { get; set; } = "NTF Medic";
        public override bool IgnoreSpawnSystem { get; set; } = false;
        

        public override List<string> Inventory { get; set; } = new()
       {
          $"{ItemType.GunCrossvec}",
          $"{ItemType.KeycardNTFLieutenant}",
          $"{ItemType.Radio}",
          $"{ItemType.Medkit}",
          $"{ItemType.ArmorCombat}"
       };

        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            StaticSpawnPoints = new List<StaticSpawnPoint>
          {
             new()
             {
                Name = "Spawn Point",
                Position = new UnityEngine.Vector3(63f, 992f, -50f),
                Chance = 100
             }
          }
        };
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
       {
          { AmmoType.Nato9, 120 }
       };

        protected override void SubscribeEvents()
        {
            PlayerEvent.EnteringPocketDimension += OnEnteringPocketDimension;
            PlayerEvent.Hurting += OnHurting;
            PlayerEvent.Shot += OnShot;
            PlayerEvent.ActivatingGenerator += OnActivatingGenerator;
            PlayerEvent.ChangingRole += OnChangingRole;

            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            PlayerEvent.EnteringPocketDimension -= OnEnteringPocketDimension;
            PlayerEvent.Hurting -= OnHurting;
            PlayerEvent.Shot -= OnShot;
            PlayerEvent.ActivatingGenerator -= OnActivatingGenerator;
            PlayerEvent.ChangingRole -= OnChangingRole;

            base.UnsubscribeEvents();
        }
    }
}