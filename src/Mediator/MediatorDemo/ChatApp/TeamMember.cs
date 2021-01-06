using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDemo.ChatApp
{
    public abstract class TeamMember
    {
        private ChatRoom chatRoom;
        public string Name { get; }

        public TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatroom(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
        }

        public void Send(string message)
        {
            chatRoom.Send(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from {from}: '{message}");
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            chatRoom.SendTo<T>(Name, message);
        }
    }
}
