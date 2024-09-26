using System;

namespace ChatSharedProject
{
    public class Junior : User
    {
        public Junior(string name) : base(name, "Junior") { }
        public override void Type()
        {
            base.Type();
            Console.WriteLine($"{Name}: I want a merge. Will somebody review it for me?");
        }
    }
    public class Middle : User
    {
        public Middle(string name) : base(name, "Middle") { }
        public override void Type()
        {
            base.Type();
            Console.WriteLine($"{Name}: I want a merge. Will somebody review it for me?");
        }
        public void ReactToTLorTeamLead()
        {
            Console.WriteLine($"{Name}: AAAAaaa! No! No TL code review, please!");
        }
    }
    public class Senior : User
    {
        public Senior(string name) : base(name, "Senior") { }
        public override void Type()
        {
            base.Type();
        }
        public void ReactToMerge()
        {
            Console.WriteLine($"{Name}: You are such a jnr! Are you afraid of the Team Lead?");
        }
    }
    public class TeamLead : User
    {
        public TeamLead(string name) : base(name, "Team Lead") { }
        public override void Type()
        {
            base.Type();
            Console.WriteLine($"{Name}: I have a non-fallen prod");
        }
        public void ReviewMerge(string userName)
        {
            Console.WriteLine($"{Name}: Of course, baby. Be ready to suffer {userName}!");
        }
    }
}
