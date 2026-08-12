using System;
using System.Collections.Generic;
using System.Text;
//AOI管理器
namespace AOICell
{
    public class AOIConfig
    {
        public string MapName = "";
        public int CellSize = 20;
        public int InitCellCount = 200;
    }
    public class AOIManager
    {
        
        private int CellSize;
        private int cellSize;
        private string managerName;
        private AOIConfig AOIConfig;
        public int CellSizeValue
        {
            get
            {
                return cellSize;
            }
            private set
            {
                cellSize=value;
            }
        }
        
        public AOIConfig Config
        {
            get
            {
                return AOIConfig;
            } 
            private set
            {
                AOIConfig=value;
            }
        }
        private Dictionary<string, AOICell> mapDic;
        private List<AOIEntity> entityList;
        public AOIManager(AOIConfig config)
        {
            Config = config;
            CellSize=config.CellSize;
            managerName=config.MapName;
            mapDic =new Dictionary<string, AOICell>(config.InitCellCount);
            entityList=new List<AOIEntity>();
        }

        public AOIEntity EnterCell(uint EntityID,float x,float y)
        {
            return null;
        }
        public void UpdatePos(AOIEntity entity,float x,float y)
        {

        }
        public void ExitCell(AOIEntity entityID)
        {

        }
    }
}
