namespace FriendFace
{
    class Program
    {
        static void Main()
        {
            {
                var users = CreateInitialUsers();
                LoginMenu(users);
            }

            static List<User> CreateInitialUsers()
            {
                return new List<User>
                {
                    new User("johnny", "johnny Cash", "We used to have cash!"),
                    new User("steven", "Steven Jobs", "We used to have jobs"),
                    new User("bob", "Bob Hope", "We used to have hope for the future!!"),
                    new User("kevin", "Kevin Bacon", "At least we still have bacon!!!"),
                    new User("mark", "Mark Zuckerberg", "01001000 01100101 01101100 01101100 01101111 00111111 00100000 01001001 00100000 01100001 01101101 00100000 01101000 01110101 01101101 01100001 01101110 00100001" )
                };
            }

            static void LoginMenu(List<User> users)    
            {
                Console.WriteLine("Welcome to FriendFace!");
                Console.WriteLine("Do you wish to \n 1. Login \n 2. Register");
                var UserReply = Console.ReadLine();

                if (UserReply == "1")
                {
                    Console.WriteLine("Username:");
                    var Username = Console.ReadLine();

                    foreach (var user in users)
                    {
                        if (Username == user.Username)
                        {
                            var loggedInUser = user;
                            MainMenu(loggedInUser, users);
                        }
                    }
                }
                else if (UserReply == "2")
                {
                    Console.WriteLine("Please type in a username.");
                    var newUsername = Console.ReadLine();
                    Console.WriteLine("Please write your full name");
                    var newUserFullName = Console.ReadLine();
                    Console.WriteLine("Now just a tiny bit for you're bio");
                    var newUserBio = Console.ReadLine();
                    var newUser = new User(newUsername, newUserFullName, newUserBio);
                    users.Add(newUser);
                    MainMenu(newUser, users);
                }
                else
                {
                    Console.WriteLine("Not a valid option");
                }
                
            }

            static void MainMenu(User currentUser, List<User> allUsers)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n--- FriendFace Menu ---");
                    Console.WriteLine("1. My Profile");
                    Console.WriteLine("2. Add a friend");
                    Console.WriteLine("3. View friends list");
                    Console.WriteLine("4. View a friend's profile");
                    Console.WriteLine("5. Remove a friend");
                    Console.WriteLine("6. Exit");

                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            MyProfile(currentUser);
                            break;
                        case "2":
                            AddFriend(allUsers, currentUser);
                            break;
                        case "3":
                            currentUser.PrintFriends();
                            break;
                        case "4":
                            ViewFriend(allUsers, currentUser);
                            break;
                        case "5":
                            RemoveFriend(allUsers, currentUser);
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }

       

        private static void MyProfile(User currentUser)
        {
            Console.Clear();
            Console.WriteLine($"Username: {currentUser.Username}");
            Console.WriteLine($"Full Name: {currentUser.FullName}");
            Console.WriteLine($"Bio: {currentUser.Bio}");
            Console.WriteLine("Want to change bio? [Y / N]");
            var userReply = Console.ReadLine().ToLower();

            if (userReply == "y")
            {
                Console.Write("Enter new bio: ");
                var newBio = Console.ReadLine();
                currentUser.Bio = newBio;
                Console.WriteLine("Bio updated successfully.");
            }
            else if (userReply == "n")
            {
                Console.WriteLine("Bio unchanged.");
            }
            else
            {
                Console.WriteLine("Invalid response. Bio unchanged.");
            }
        }


        private static void ViewFriend(List<User> allUsers, User currentUser)
        {
            Console.Clear();
            Console.Write("Enter the username of the friend whose profile you want to view: ");
            var viewUsername = Console.ReadLine();
            var viewUser = currentUser.Friends.FirstOrDefault(user => user.Username == viewUsername);
            if (viewUser != null)
            {
                viewUser.PrintProfile();
            }
            else
            {
                Console.WriteLine("Friend not found.");
            }
        }

        private static void RemoveFriend(List<User> allUsers, User currentUser)
        {
            Console.Clear();
            Console.Write("Enter the username of the user you want to remove: ");
            var removeUsername = Console.ReadLine();
            var removeUser = allUsers.FirstOrDefault(user => user.Username == removeUsername);
            if (removeUser != null)
            {
                currentUser.RemoveFriend(removeUser);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private static void AddFriend(List<User> allUsers, User currentUser)
        {
            Console.Clear();

            foreach (var User in allUsers)
            {
                if (User.Username != currentUser.Username)
                {
                    Console.WriteLine($"- {User.Username}");
                }
            }

            Console.Write("Enter the username of the user you want to add: ");
            var addUsername = Console.ReadLine();
            var addUser = allUsers.FirstOrDefault(user => user.Username == addUsername);
            if (addUser != null)
            {
                currentUser.AddFriend(addUser);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}