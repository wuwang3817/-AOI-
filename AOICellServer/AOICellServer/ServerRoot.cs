//服务器根节点
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
        private BattleStage stage=new BattleStage();
        public void Init()
        {
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
