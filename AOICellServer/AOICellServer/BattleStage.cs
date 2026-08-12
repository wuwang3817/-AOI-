//战斗关卡
using AOICell;
using AOICellProtocol;

namespace AOICellServer
{
    public class StageConfig
    {
        public int stageID;
        public string stageName;
        public int AOISize;
        public int initCount = 100;
    }
    public class BattleStage
    {
        public StageConfig stageConfig;
        public AOIManager AOIManager;
        public void InitStage(int stageID)
        {
            stageConfig = new StageConfig
            {
                stageID = stageID,
                stageName = "测试关卡",
                AOISize = CommonConfig.AOISize,
                initCount = 200
            };
            AOIConfig AOIConfig = new AOIConfig
            {
                MapName = stageConfig.stageName,
                CellSize = stageConfig.AOISize,
                InitCellCount = stageConfig.initCount
            };
            AOIManager = new AOIManager(AOIConfig);
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
