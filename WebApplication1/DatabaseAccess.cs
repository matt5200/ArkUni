using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DatabaseAccessor
    {
        private static readonly WebApplication1.Entities school;

        static DatabaseAccessor()
        {
            school = new Entities();
            school.Database.Connection.Open();
        }

        public static WebApplication1.Entities Instance
        {
            get
            {
                return school;
            }
        }
    }
}