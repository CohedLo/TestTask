using System;

namespace ChatSharedProject
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public User(string name, string role)
        {
            Name = name;
            Role = role;
        }
        public virtual void Type()
        {
            Console.WriteLine($"{Name}: Hey");
        }
    }
}
