//服务器根节点
using AOICellProtocol;
using PENet;
using System.Collections.Concurrent;
using System.Numerics;

namespace AOICellServer
{
    public class ServerRoot
    {
        private static ServerRoot instance;
        public static ServerRoot Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new ServerRoot();
                }
                return instance;
            }
        }
        

        private AsyncNet<ServerSession,Package> server=new AsyncNet<ServerSession,Package>();
        private ConcurrentQueue<NetPack> NetPackQueue = new ConcurrentQueue<NetPack>();
        private BattleStage stage=new BattleStage();
        public void Init()
        {
            server.StartAsServer("192.168.0.1", 8080);
            stage.InitStage(1);
        }
        public void Tick()
        {
            while(!NetPackQueue.IsEmpty)
            {
                if(NetPackQueue.TryDequeue(out NetPack netPack))
                {
                    switch (netPack.package.cmd)
                    {
                        case Command.RequestLogin:
                            LoginStage(netPack);
                            break;
                        case Command.ResponseLogin:
                            break;
                        case Command.SendMovePosition:
                            break;
                        case Command.SendExit:
                            break;
                    }
                }
                else
                {
                    this.Error($"Dequeue Package Failed");
                }
                
            }
            stage.TickStage();
        }
        public void UnInit()
        {
            stage.UnInitStage();
        }
        public void AddMsgPack(NetPack netPack)
        {
            NetPackQueue.Enqueue(netPack);
        }

        private void LoginStage(NetPack netPack)
        {
            BattleEntity entity = new BattleEntity
            {
                entityID = GetClientUniqueEntityID(),
                session = netPack.serverSession,
                targetPos = new Vector3(10, 0, 10),
                playerState = PlayerStateEnum.None
            };
            stage.EnterStage(entity);
            entity.SendMsg(new Package 
            { 
                cmd = Command.ResponseLogin,
                responseLogin = new ResponseLogin 
                { 
                    EntityID = entity.entityID
                }
            });
        }

        private uint uid;
        private uint GetClientUniqueEntityID()
        {
            return ++uid;
        }
    }
}
