//服务器入口
namespace AOICellServer
{
    public class ServerStart
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                ServerRoot.Instance.Init();
                while (true)
                {
                    ServerRoot.Instance.Tick();
                    Thread.Sleep(10);
                }
            });
            while(true)
            {
                string input = Console.ReadLine();
            }
        }
        
    }
}