using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace NeerServiceApp
{
    [ServiceContract]
    public class UserService
    {
        static Users _users = new Users()
        {
            new User(){Email ="aaa", FirstName ="bbb", LastName ="ccc", UserId="ddd"}
        };
        [WebGet(UriTemplate = "/users", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Users GetAllUsers()
        {
            return _users;
        }
        [WebInvoke(UriTemplate = "/users", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        public User AddNewUser(User u)
        {
            u.UserId = Guid.NewGuid().ToString();
            _users.Add(u);
            return u;
        }
        [WebGet(UriTemplate = "/users/{user_id}")]
        [OperationContract]
        public User GetUser(string user_id)
        {
            User u = FindUser(user_id);
            return u;
        }
        User FindUser(string user_id)
        {
            User ret = null;
            var result = (from u in _users
                          where u.UserId == user_id
                          select u).Single();
            if (result != null)
                ret = result;
            else
                ret = new User();
            return ret;
        }
        [WebInvoke(UriTemplate = "/users/{user_id}", Method = "PUT")]
        [OperationContract]
        public User UpdateUser(string user_id, User update)
        {
            User u = FindUser(user_id);
            UpdateUserInternal(u, update);
            return u;
        }

        private void UpdateUserInternal(User u, User update)
        {
            u.Email = update.Email;
            u.FirstName = update.FirstName;
            u.LastName = update.LastName;

        }
        [WebInvoke(UriTemplate = "/users/{user_id}", Method = "DELETE")]
        [OperationContract]
        public void DeleteUser(string user_id)
        {
            User u = FindUser(user_id);
            _users.Remove(u);
        }
    }
}
