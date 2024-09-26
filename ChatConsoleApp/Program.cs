using System;
using ChatSharedProject;

namespace ChatConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<User> users = new List<User>();
            List<string> chatLog = new List<string>();

            // Объекты пользователей
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(' ');
                string name = parts[0];
                string role = parts[1].ToLower();

                switch (role)
                {
                    case "junior":
                        users.Add(new Junior(name));
                        break;
                    case "middle":
                        users.Add(new Middle(name));
                        break;
                    case "senior":
                        users.Add(new Senior(name));
                        break;
                    case "teamlead":
                        users.Add(new TeamLead(name));
                        break;
                    default:
                        users.Add(new User(name, "User"));
                        break;
                }
            }

            // Логика вывода сообщений
            foreach (var user in users)
            {
                user.Type();
                chatLog.Add($"{user.Name}: Hey");

                if (user is Junior)
                {
                    string mergeRequest = $"{user.Name}: I want a merge. Will somebody review it for me?";
                    Console.WriteLine(mergeRequest);
                    chatLog.Add(mergeRequest);
                }

                // Middle реагирует на слова "TL" или "Team Lead"
                if (user is Middle middle)
                {
                    foreach (var log in chatLog)
                    {
                        if (log.Contains("TL") || log.Contains("Team Lead"))
                        {
                            middle.ReactToTLorTeamLead();
                            break;
                        }
                    }
                }

                // Senior реагирует на "I want a merge"
                if (user is Senior senior)
                {
                    foreach (var log in chatLog)
                    {
                        if (log.Contains("I want a merge"))
                        {
                            senior.ReactToMerge();
                            break;
                        }
                    }
                }

                // Team Lead реагирует на "I want a merge. Will somebody review it for me?"
                if (user is TeamLead teamLead)
                {
                    foreach (var log in chatLog)
                    {
                        if (log.Contains("I want a merge. Will somebody review it for me?"))
                        {
                            teamLead.ReviewMerge(user.Name);
                            break;
                        }
                    }
                }
            }
        }
    }
}