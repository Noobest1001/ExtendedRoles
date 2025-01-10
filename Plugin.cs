using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using System;
using Map = Exiled.Events.Handlers.Map;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using ExtendedRoles.Configs;

namespace ExtendedRoles
{
    public class Plugin : Plugin<Config>
	{
		public override string Name => "ExtendedRoles";
		public override string Author => "Noobest1001";
		public override Version RequiredExiledVersion => new(9, *, *);
		public override Version Version => new(1, 0, 0);

		public static Plugin Instance;

		public bool IsSpawnable = false;
		public bool IsForced = false;

		private EventHandlers eventHandlers;

		public override void OnEnabled()
		{
			Instance = this;
			Config.ExtendedRoles.Register();
			Config.NTFMedic.Register();
			Config.NTFGhost.Register();
			eventHandlers = new EventHandlers(this);

			Server.RoundStarted += eventHandlers.OnRoundStarted;
			Server.RespawningTeam += eventHandlers.OnRespawningTeam;
			Server.EndingRound += eventHandlers.OnEndingRound;
			//Player.Spawned += eventHandlers.OnSpawned;
			
			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			CustomRole.UnregisterRoles();
			Server.RoundStarted -= eventHandlers.OnRoundStarted;
			Server.RespawningTeam -= eventHandlers.OnRespawningTeam;
			Server.EndingRound -= eventHandlers.OnEndingRound;
			//Player.Spawned -= eventHandlers.OnSpawned;

			eventHandlers = null;
			Instance = null;
			base.OnDisabled();
		}
		
		private void OnSpawnWave(RespawningTeamEventArgs ev)
		{
			if(ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox && Config.ERspawn)
			{
				foreach()
			}
		}
	}
}