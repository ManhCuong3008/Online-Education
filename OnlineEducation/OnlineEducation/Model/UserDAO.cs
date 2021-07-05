using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public User getUserByUserName(string username)
        {
            return mydb.Users.Where(u => u.Username == username).FirstOrDefault();
        }
        public List<User> getListUser()
        {
            return mydb.Users.ToList();
        }

        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj); // thêm
        }

        public void Save()
        {
            mydb.SaveChanges();
        }

        public void addUser(User user)
        {
            string query = "INSERT INTO dbo.[User]( Username ,Password ,FullName ,Email ,PhoneNumber ,Role_ID) VALUES(@u,@pw,@fn,@e,@p,@roleid)";
            string username = user.Username;
            string password = user.Password;
            string fullname = user.FullName;
            string emaill = user.Email;
            string phone = user.PhoneNumber;
            int RoleID = user.Role_ID;
            mydb.Database.ExecuteSqlCommand(query,
                new SqlParameter("@u", username),
                new SqlParameter("@pw", password),
                new SqlParameter("@fn", fullname),
                new SqlParameter("@e", emaill),
                new SqlParameter("@p", phone),
                new SqlParameter("@roleid", RoleID)
                );
        }

    }
}
