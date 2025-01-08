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
    public override unit Id {get; set;} = 25;
    public override string Name {get; set;} = "Potent Adrenaline";
    public override string Description {get; set;} = "A concentrated amount of Epinephrine that can counter the effect of cardiac arrest.";
    public override float Weight {get; set;} = 1f;

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

        ev.Player.EnableEffect(EffectType.Invigorated, 2);
        ev.Player.DisableEffect(EffectType.CardiacArrest)
    }

    public void OnDropping(DroppingItemEventArgs ev)
    {
        if(!Check(ev.Item)) return;
        ev.IsAllowed = false;
    }
}