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
            return myDB.Orders.ToList();
        }




    }
}