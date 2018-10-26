using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace Курсовик.DAO
{
    
    
        public class DAO
        {
            private const string ConnectionString =
           "Data Source=.\\SQLEXPRESS;Initial Catalog=Склад;Integrated Security=True";
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
  