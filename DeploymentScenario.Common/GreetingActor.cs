using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeploymentScenario.Common
{
    public class GreetingActor : TypedActor, IHandle<Greet>
    {

        public void Handle(Greet message)
        {
            Console.WriteLine("Hello {0}", message.Who);
        }
    }
}
