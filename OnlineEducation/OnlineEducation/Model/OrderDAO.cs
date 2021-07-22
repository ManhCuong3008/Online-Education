using OnlineEduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Model
{
    public class OrderDAO
    {
        MyDB myDB = new MyDB();

        public List<Order> getListOrder()
        {
            return myDB.Orders.Where(o => o.Status=="verify").ToList();
        }

        public Order getOrderByID(int orderID)
        {
            return myDB.Orders.Where(o=> o.OrderID==orderID).FirstOrDefault();
        }

        public void updateOrder(int  orderID, string status)
        {
            var orderUpdate = myDB.Orders.Where(o => o.OrderID == orderID).FirstOrDefault();
            orderUpdate.Status = status;
            myDB.SaveChanges();
        }
        public Course getCourseByActive(string activeCode)
        {
            return myDB.Courses.Where(c => c.Active_ID==activeCode).FirstOrDefault();
        }
    }
}