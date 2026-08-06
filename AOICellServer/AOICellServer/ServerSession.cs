using AOICellProtocol;
using PENet;
//服务器会话管理
namespace AOICellServer
{
    public class ServerSession : AsyncSession<Package>
    {
        protected override void OnConnected(bool result)
        {
            this.LogGreen("New Client Online:{0}.",result);
        }
        protected override void OnDisConnected()
        {
            this.LogGreen("Client Offline.");
        }

        protected override void OnReceiveMsg(Package msg)
        {
            
        }
    }
}