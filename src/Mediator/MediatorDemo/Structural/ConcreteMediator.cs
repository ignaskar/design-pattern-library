﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatorDemo.Structural
{
    public class ConcreteMediator : Mediator
    {
        //public Colleague1 Colleague1 { get; set; }
        //public Colleague2 Colleague2 { get; set; }
        private List<Colleague> colleagues = new List<Colleague>();

        public void Register(Colleague colleague)
        {
            colleague.SetMediator(this);
            colleagues.Add(colleague);
        }

        public T CreateColleague<T>() where T : Colleague, new()
        {
            var c = new T();
            c.SetMediator(this);
            colleagues.Add(c);
            return c;
        }
        
        public override void Send(string message, Colleague colleague)
        {
            //if (colleague == Colleague1)
            //{
            //    Colleague2.HandleNotification(message);
            //}
            //else
            //{
            //    Colleague1.HandleNotification(message);
            //}
            
            colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
        }
    }
}
