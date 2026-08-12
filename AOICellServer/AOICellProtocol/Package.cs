using System;
using PENet;
namespace AOICellProtocol
{
    public class CommonConfig
    {
        public const int AOISize = 50;
        public const float moveSpeed = 40;
        public const int borderX = 500;
        public const int borderZ = 500;

        public const int randomDirInterval = 1;
        public const int randomDirRate = 30;
    }
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
