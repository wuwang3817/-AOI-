using AOICellProtocol;
using PENet;
using System;
//客户端网络会话
public class ClientSession : AsyncSession<Package>
{
    protected override void OnConnected(bool result)
    {
        this.LogGreen("Connect Server:{0}", result);
    }

    protected override void OnDisConnected()
    {
        this.Warn("Disconnect to server");
    }

    protected override void OnReceiveMsg(Package msg)
    {
        GameRoot.Instance.AddPackage(msg);
    }
}