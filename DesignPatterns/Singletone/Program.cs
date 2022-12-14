namespace Singletone;

public class Program
{
    public static void Main(string[] args)
    {
        var balancer1 = LoadBalancer.GetLoadBalancer();
        var balancer2 = LoadBalancer.GetLoadBalancer();
        var balancer3 = LoadBalancer.GetLoadBalancer();
        var balancer4 = LoadBalancer.GetLoadBalancer();

        if (balancer1 == balancer2 && balancer2 == balancer3 && balancer3 == balancer4)
        {
            Console.WriteLine("Same instance\n");
        }

        var balancer = LoadBalancer.GetLoadBalancer();
        for (var i = 0; i < 15; i++)
        {
            var serverName = balancer.NextServer.Name;
            Console.WriteLine("Dispatch request to: " + serverName);
        }

        Console.ReadKey();
    }
}