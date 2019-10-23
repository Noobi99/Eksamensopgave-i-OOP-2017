using System.Collections.Generic;

namespace Eksamensopgave2017
{
    public class UserCatalog
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User(){Id = 4, Username = "chris", Money = 5000f},
                new User(){Id = 2, Username = "noemi", Money = 6500f},
                new User(){Id = 5, Username = "suser", Money = 200},
                new User(){Id = 3, Username = "muser", Money = 5000f},
                new User(){Id = 1, Username = "luser", Money = 99999f}
            };

            return users;
        }
    }
}