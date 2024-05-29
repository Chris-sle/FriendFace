using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class User
    {
        public string Username { get; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<User> Friends { get; set; }

        public User(string username, string fullName, string bio)
        {
            Username = username;
            FullName = fullName;
            Bio = bio;
            Friends = new List<User>();
        }

        public void AddFriend(User friend)
        {
            if (!Friends.Contains(friend))
            {
                Friends.Add(friend);
                Console.WriteLine($"{friend.Username} has been added as a friend.");
            }
            else
            {
                Console.WriteLine($"{friend.Username} is already a friend.");
            }
        }

        public void RemoveFriend(User friend)
        {
            if (Friends.Contains(friend))
            {
                Friends.Remove(friend);
                Console.WriteLine($"{friend.Username} has been removed from your friends.");
            }
            else
            {
                Console.WriteLine($"{friend.Username} is not in your friends list.");
            }
        }

        public void PrintFriends()
        {
            Console.Clear();
            if (Friends.Count > 0)
            {
                Console.WriteLine("Friends list:");
                foreach (var friend in Friends)
                {
                    Console.WriteLine($"- {friend.Username}");
                }
            }
            else
            {
                Console.WriteLine("You have no friends in your list.");
            }
        }

        public void PrintProfile()
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"Bio: {Bio}");
        }
    }
}
