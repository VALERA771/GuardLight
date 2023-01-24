using Exiled.API.Interfaces;
using MapGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGuardPositions
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public uint GuardToTp { get; set; } = 5;

        public List<RoomName> RoomsToTp { get; set; } = new List<RoomName>()
        {
            RoomName.LczAirlock,
            RoomName.LczToilets,
            RoomName.LczCheckpointA,
            RoomName.LczCheckpointB,
            RoomName.LczGlassroom,
            RoomName.LczClassDSpawn,
            RoomName.LczArmory,
            RoomName.Lcz173,
            RoomName.LczGreenhouse,
            RoomName.LczComputerRoom
        };

    }
}
