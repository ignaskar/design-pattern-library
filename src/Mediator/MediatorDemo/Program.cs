using System;
using MediatorDemo.ChatApp;
using MediatorDemo.Structural;

namespace MediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamChat = new TeamChatRoom();

            var steve = new Developer("Steve");
            var justin = new Developer("Justin");
            var jenna = new Developer("Jenna");
            var kim = new Tester("Kim");
            var julia = new Tester("Julia");
            teamChat.RegisterMembers(steve, justin, jenna, kim, julia);
            
            steve.Send("Hey everyone, we are going to be deploying at 2pm today.");
            kim.Send("Ok, thanks for letting us know. :)");

            Console.WriteLine();
            steve.SendTo<Developer>("Make sure your tests pass before checking in!");
        }

        static void StructuralExample()
        {
            var mediator = new ConcreteMediator();
            //var c1 = new Colleague1();
            //var c2 = new Colleague2();

            ////mediator.Colleague1 = c1;
            ////mediator.Colleague2 = c2;

            //mediator.Register(c1);
            //mediator.Register(c2);
            var c1 = mediator.CreateColleague<Colleague1>();
            var c2 = mediator.CreateColleague<Colleague2>();

            c1.Send("Hello, world! (from c1)");
            c2.Send("Hi there! (from c2)");
        }
    }
}
