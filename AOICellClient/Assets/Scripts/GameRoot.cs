using PENet;
using UnityEngine;
using AOICellProtocol;
using PEUtils;
//客户端根节点
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;
    
    AsyncNet<ClientSession, Package> client=new AsyncNet<ClientSession, Package>();
    void Start()
    {
        Instance = this;
        LogConfig config = new LogConfig
        {
            saveName = "AOICellClientPELog.txt",
            loggerEnum = LoggerType.Unity
        };
        PELog.InitSettings(config);
        client.StartAsClient("192.168.0.1", 8080);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
