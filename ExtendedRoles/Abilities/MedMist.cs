using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using UnityEngine;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;

namespace ExtendedRoles.Abilities
{
    public class MedMist : Ability
    {
        public string Name {get; set;} = "Nano-Machines"
        public string Description {get; set;} = "[Redacted] of nano-machines are let go and activly seek out biological matter in a 5 meter radius and heal them"
        private const float Duration {get; set;} = 1f;
        private const float Radius = 100f;
        private const float Cooldown {get; set;} = 180f;
        [Description("The Amount of healing that should be dealt to players in a range")]
        private const float Healing = 50f;
        private readonly List<CoroutineHandle> coroutines = new ();
        private Dictionary<Player, CoroutineHandle> activeAbilities = new Dictionary<Player, CoroutineHandle>();
        public Dictionary<EffectType, byte> FEffects {get; set;} = new Dictionary<EffectType, byte>();
        {
            {EffectType.Vitality, 10, true},
            {EffectType.Scp1853, 5, true}
        }

        public Dictionary<EffectType, byte> HEffects {get; set;} = new Dictionary<EffectType, byte>();
        {
            {EffectType.Vitality, 5, true},
            {EffectType.Scp1853, 2 ,true}
        }

        private void Activate(Player player)
        {
            foreach(Player player0 in Player.List)
            {
                if((Vector3.Distance(player.Position, center) <= Radius) && player.RoleTypeId != RoleTypeId.SCP173)
                {
                    coroutine.Add(Timeing.RunCoroutine(Ability(player)));
                    continue;
                    
                }
            }
        }


    }
}