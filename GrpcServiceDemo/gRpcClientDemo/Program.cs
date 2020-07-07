using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcServiceDemo;
using System;
using System.Threading.Tasks;

namespace GrpcClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "晓晨" });
            Console.WriteLine("Greeter 服务返回数据: " + reply.Message);

            var catClient = new LuCat.LuCatClient(channel);
            var catReply = await catClient.SuckingCatAsync(new Empty());
            Console.WriteLine("调用撸猫服务：" + catReply.Message);

            Console.ReadKey();
        }
    }
}
