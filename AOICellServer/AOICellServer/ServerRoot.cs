//服务器根节点
using AOICellProtocol;
using PENet;

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
        private BattleStage stage=new BattleStage();
        public void Init()
        {
            server.StartAsServer("192.168.0.1", 8080);
            stage.InitStage(1);
        }
        public void Tick()
        {
            stage.TickStage();
        }
        public void UnInit()
        {
            stage.UnInitStage();
        }
    }
}
