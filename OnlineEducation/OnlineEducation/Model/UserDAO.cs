using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Model
{
     
    public class UserDAO
    {
        MyDB mydb = new MyDB();

        public User getUser(string username, string password)
        {
            // Không sử dụng đôi tượng sqlparameters
            //  string query = "SELECT * FROM  dbo.[User] WHERE Username ='"+username+"' AND Password ='"+password+"'";
            //mydb.Database.SqlQuery<User>(query).FirstOrDefault();

            //string query = "SELECT * FROM  dbo.[User] WHERE Username = @username AND Password = @password";
            //return mydb.Database.SqlQuery<User>(query,
            //      new SqlParameter("@username", username),
            //      new SqlParameter("@password", password)
            //      ).FirstOrDefault();
            return mydb.Users.Where(u => u.Username == username&&u.Password==password).FirstOrDefault();
        }
        public User getUser(string username, string password,string fullname, string phone, string email)
        {
            return mydb.Users.Where(u => u.Username == username && u.Password == password&&u.FullName==fullname&&u.PhoneNumber== phone&&u.Email==email).FirstOrDefault();
        }
        public void updateInforUser(User user)
        {
            var userUpdate = mydb.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            userUpdate.Password = user.Password;
            userUpdate.FullName = user.FullName;
            userUpdate.PhoneNumber = user.PhoneNumber;
            userUpdate.Email = user.Email;
            mydb.SaveChanges();
        }
        public User getUserByUserID(int userID)
        {
            return mydb.Users.Where(u => u.UserID == userID).FirstOrDefault();
        }

        public User getUserByUserName(string username)
        {
            return mydb.Users.Where(u => u.Username == username).FirstOrDefault();
        }
        public List<User> getListUser()
        {
            return mydb.Users.ToList();
        }

        public void AddUser(User obj)
        {
            mydb.Users.Add(obj); // thêm
            mydb.SaveChanges();
        }

        public void Save()
        {
            mydb.SaveChanges();
        }

        public void addUserFacebook(User user)
        {
            if (user != null)
            {
                var original = mydb.Users.SingleOrDefault(x => x.Username == user.Username);
                if (original == null)
                {
                    mydb.Users.Add(user);
                    mydb.SaveChanges();
                }
            }
        }

    }
}
