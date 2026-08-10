using PENet;
using UnityEngine;
using AOICellProtocol;
using PEUtils;
using UnityEngine.UI;
//客户端根节点
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;
    public Text TextEntityID;
    public Camera camera;
    public bool setFollow;
    public Transform EntityRoot;
    public Transform CellRoot;
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
    public void ClickLoginButton()
    {
        client.session.SendMsg(new Package
        {
            cmd=Command.RequestLogin,
            requestLogin=new RequestLogin 
            {
                account="Test"
            },
        });
    }
}
