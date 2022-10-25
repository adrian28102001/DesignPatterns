using Singletone.Models;

namespace Singletone;

public class LoadBalancer
{
    private static readonly LoadBalancer Instance = new();

    private readonly List<Server> _servers;
    private readonly Random _random = new();

    private LoadBalancer()
    {
        _servers = new List<Server>
        {
            new() {Name = "ServerI", IP = "120.14.220.18"},
            new() {Name = "ServerII", IP = "120.14.220.19"},
            new() {Name = "ServerIII", IP = "120.14.220.20"},
            new() {Name = "ServerIV", IP = "120.14.220.21"},
            new() {Name = "ServerV", IP = "120.14.220.22"},
        };
    }

    public static LoadBalancer GetLoadBalancer()
    {
        return Instance;
    }

    public Server NextServer
    {
        get
        {
            var r = _random.Next(_servers.Count);
            return _servers[r];
        }
    }
}