using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDemo.Structural
{
    public class Colleague2 : Colleague
    {
        //public Colleague2(Mediator mediator) : base(mediator)
        //{
        //}

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Colleague2)} receives notification message: {message}");
        }
    }
}
