using AOICellProtocol;
using System.Numerics;
using AOICell;

namespace AOICellServer
{
    public enum PlayerStateEnum
    {
        None,
        Online,
        Offline,
        Mandate,
    }
    public class BattleEntity
    {
        public uint entityID;
        public ServerSession session;
        public Vector3 targetDir;
        public Vector3 targetPos;
        public PlayerStateEnum playerState;

        public AOIEntity aoiEntity;

        public void SendMsg(Package package)
        {
            session?.SendMsg(package);
        }
    }
}
