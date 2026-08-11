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
        public void EnterStage(BattleEntity entity)
        {
            this.LogYellow($"BattleStage EnterStage {entity.entityID}");
        }
        public void UpdateStage(BattleEntity entity)
        {
            this.LogYellow($"BattleStage UpdateStage {entity.entityID}");
        }
        public void ExitStage(BattleEntity entity)
        {
            this.LogYellow($"BattleStage ExitStage {entity.entityID}");
        }
    }
}
