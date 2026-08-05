//战斗关卡
namespace AOICellServer
{
    public class BattleStage
    {
        public void InitStage(int stageID)
        {
            this.LogYellow($"BattleStage InitStage {stageID}");
        }
        public void TickStage()
        {

        }
        public void UnInitStage()
        {
        }
    }
}
