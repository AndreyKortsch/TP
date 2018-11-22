using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Курсовик.DAO
{
    
    
        public class DAO
        {
            private string ConnectionString =
           ConfigurationManager.ConnectionStrings["YourDB"].ConnectionString;
            protected SqlConnection Сonnection { get; set; }
            public void Connect()
            {
                Сonnection = new SqlConnection(ConnectionString);
                Сonnection.Open();
            }
            public void Disconnect()
            {
                Сonnection.Close();
            }
        }
    }
  