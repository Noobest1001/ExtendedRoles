using Exiled.API.Features;
using PlayerRoles;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;

namespace ExtendedRoles.Abilities
{
    public class MedMist : Ability
    {
        private const float Healing = 50f;
        private const float Duration {get; set;} = 1f;
        private const float Radius = 5f;
        private const float Cooldown {get; set;} = 60f;
        private Dictionary<Player, CoroutineHandle> activeAbilities = new Dictionary<Player, CoroutineHandle>();

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
                        player.EnableEffect(EffectTypeId.Vitality, 10);
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

            player.DisableEffect(EffectType.Vitality);
        }
    }
}