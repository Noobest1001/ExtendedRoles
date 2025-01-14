using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;

namespace ExtendedRoles.Abilities
{
    public class MedMist : Ability
    {
        public string Name = "Nano-Machines"
        private const float Healing = 50f;
        private const float Duration {get; set;} = 1f;
        private const float Radius = 5f;
        private const float Cooldown {get; set;} = 180f;
        private Dictionary<Player, CoroutineHandle> activeAbilities = new Dictionary<Player, CoroutineHandle>();
        public Dictionary<EffectType, byte> Effects {get; set;} = new Dictionary<EffectType, byte>();
        {
            {EnableEffect(EffectTypeId.Vitality, 10)},
            {EnableEffect(EffectTypeId.Scp1853, 5)}
        }

        public override void Activate(Player player)
        {
            if(activeAbilities.ContainsKey(player))
                return;

            foreach(Player player in Player.list)
            {
                try{
                    if((Vector3.Distance(player.Position, center) <= Radius) && player.Team != Team.SCP)
                    {
                        player.Health += HealAmount;

                        Log.Info($"{player} was healed for {Healing}.\n");
                    }
                }
                catch(Exception e){
                    Log.Error($"A fatal error occured: {e}\n")
                }
            }
            CoroutineHandle coroutine = Timing.CallDelayed(Duration, () => Deactivate(player));
            activeAbilities.Add(player, coroutine);
        }

        public override void Deactivate(Player player)
        {
            if (!activeAbilities.ContainsKey(player))
                return;


            Timing.KillCoroutines(activeAbilities[player]);
            activeAbilities.Remove(player);
        }
    }
}