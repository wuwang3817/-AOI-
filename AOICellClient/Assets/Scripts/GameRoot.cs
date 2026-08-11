using PENet;
using UnityEngine;
using AOICellProtocol;
using PEUtils;
using UnityEngine.UI;
using System.Collections.Concurrent;
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
    ConcurrentQueue<Package> packageQueue = new ConcurrentQueue<Package>();
    private uint selfID;
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
        while(!packageQueue.IsEmpty)
        {
            if(packageQueue.TryDequeue(out Package package))
            {
                switch(package.cmd)
                {
                    case Command.ResponseLogin:
                        HandleResponeLogin(package.responseLogin);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.Error("Failed to dequeue package from queue.");
            }
        }
    }

    private void HandleResponeLogin(ResponseLogin responseLogin)
    {
        selfID = responseLogin.EntityID;
        TextEntityID.text = $"$SelfEntityID: {responseLogin.EntityID}";
    }

    public void AddPackage(Package package)
    {
        packageQueue.Enqueue(package);
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
