using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace ExtendedRoles.Items
[CustomItem(ItemType.Adrenaline)]
public class Anti049 : CustomItem
{
    public override unit Id {get; set;} = 200;
    public override string Name {get; set;} = "Potent Adrenaline";
    public override string Description {get; set;} = "A concentrated amount of Epinephrine that can counter the effect of cardiac arrest.";
    public override float Weight {get; set;} = 1f;

    public override SpawnProperties? SpawnProperties {get; set;} = new(){
        Limit = 2,
        DynamicSpawnPoints = [
            new DynamicSpawnPoint() { Location = SpawnLocationType.Inside049Armory, Chance = 75},
            new DynamicSpawnPoint() { Location = SpawnLocationType.InsideHczArmory, Chance = 25},
            new DynamicSpawnPoint() { Location = SpawnLocationType.InsideLczCafe, Chance = 50}
        ]
    }

    protected override void SubscribeEvents() {
        PlayerEvents.UsingItem += OnUsingItem;
    
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents() {
        PlayerEvents.UsingItem -= OnUsingItem;

        base.UnsubscribeEvents();
    }

    public void OnUsingItem(UsingItemEventArgs ev)
    {
        if(Check(ev.Item)) return;

        ev.Player.DisableEffect(EffectType.CardiacArrest);
        ev.Player.EnableEffect(EffectType.Invigorated, byte.MaxValue);

    }

    public void OnDropping(DroppingItemEventArgs ev)
    {
        if(!Check(ev.Item)) return;
        ev.IsAllowed = false;
    }
}