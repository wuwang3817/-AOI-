using System;
using PENet;
namespace AOICellProtocol
{
    public enum Command
    {
        RequestLogin,
        ResponseLogin,
        SendMovePosition,
        SendExit,
    }
    [Serializable]
    public class Package:AsyncMsg
    {
        public Command cmd;
        public RequestLogin requestLogin;
        public ResponseLogin responseLogin;
    }
    [Serializable]
    public class  RequestLogin
    {
        public string account;
    }
    [Serializable]
    public class ResponseLogin
    {
        public uint EntityID;
    }
}
