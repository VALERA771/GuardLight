using Exiled.API.Features;
using MapGeneration;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGuardPositions
{
    public class Plugin : Plugin<Config>
    {
        internal Plugin Instance => _singleton;
        private Plugin _singleton;

        public override string Name => base.Name;
        public override string Prefix => base.Prefix;
        public override string Author => base.Author;
        public override Version Version => base.Version;
        public override Version RequiredExiledVersion => base.RequiredExiledVersion;


        public override void OnEnabled()
        {
            _singleton = this;
            if (Instance.Config.RoomsToTp.Count == 0)
            {
                Instance.Config.RoomsToTp = new List<MapGeneration.RoomName>()
                {
                    RoomName.LczAirlock,
                    RoomName.LczToilets,
                    RoomName.LczCheckpointA,
                    RoomName.LczCheckpointB,
                    RoomName.LczGlassroom,
                };
            }
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }

        
        public void OnRoundStart()
        {
            Timing.CallDelayed(0.5f, () =>
            {
                List<Player> guards = Player.Get(PlayerRoles.RoleTypeId.FacilityGuard).ToList();
                for (int i = 0; i < Instance.Config.GuardToTp; i++)
                {
                    Player guard = guards[i];
                    RoomName name = Instance.Config.RoomsToTp.RandomItem();
                    Room room = Room.List.Where(x => x.RoomName == name).First();
                    guard.Teleport(room.Position);
                }
            });
        }
    }
}
