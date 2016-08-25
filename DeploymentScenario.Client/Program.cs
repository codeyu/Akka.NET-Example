using Akka.Actor;
using Akka.Configuration;
using DeploymentScenario.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeploymentScenario.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
                    akka {  
                        actor {
                            provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                        }
                        remote {
                            helios.tcp {
                                transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
                                applied-adapters = []
                                transport-protocol = tcp
                                port = 0
                                hostname = localhost
                            }
                        }
                    }
                    ");
            using (var system = ActorSystem.Create("MyClient", config))
            {
                var greeting = system.ActorSelection("akka.tcp://MySystem@localhost:8008/user/Greeting");

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input.Equals("Hello"))
                    {
                        greeting.Tell(new Greet("World"));
                    }
                }
            }
        }
    }
}
