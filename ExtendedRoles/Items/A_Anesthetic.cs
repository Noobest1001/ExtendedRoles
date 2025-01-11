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
[CustomItem(ItemType.SCP500)]

public class Camniste : CustomItem
{
    public override unit Id {get; set;} = 201;
    public override string Name {get; set;} = "Class-A Anestetic";
    public override string Description {get; set;} = "<i>For erasing recent and/or specific episodic memories</i>";
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
        if(!Check(ev.Item)) return;

        ev.Player.EnableEffect(EffectType.AmnesiaVision, 5f);
        ev.Player.DisableEffect(EffectType.Traumatized);
    }

    public void OnDropping(DroppingItemEventArgs ev)
    {
        if(!Check(ev.Item)) return;
        ev.IsAllowed = false;
    }
}