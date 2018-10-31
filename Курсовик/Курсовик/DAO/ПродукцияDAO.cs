using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;

namespace Курсовик.DAO
{
    public class ПродукцияDAO: DAO
        {
            public List<Продукция> Список_продукции()
            {
               Connect();
                List<Продукция> Список_продукции = new List<Продукция>();
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Список_продукции", Сonnection);
                   
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Продукция товар = new Продукция();
                        товар.Код_продукции = Convert.ToString(reader["код_продукции"]);
                        товар.Категория =Convert.ToInt32(reader["номер_категории"]);
                        товар.Количество = Convert.ToInt32(reader["количество"]);
                        товар.Масса =Convert.ToUInt32(reader["масса"]);
                        товар.Материал = Convert.ToString(reader["материал"]);
                        товар.Цена_за_единицу= Convert.ToInt32(reader["цена_за_единицу"]);
                    Список_продукции.Add(товар);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    Disconnect();
                }
                return Список_продукции;
            }
        public bool Добавить_продукт(Продукция продукт)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Список_продукции (код_продукции, номер_категории, " +
                "материал, масса, количество, цена_за_единицу) " +
                "VALUES (@код_продукции, @номер_категории, @материал, @масса, @количество,@цена_за_единицу)",Сonnection);
                cmd.Parameters.Add(new SqlParameter("@код_продукции", продукт.Код_продукции));
                cmd.Parameters.Add(new SqlParameter("@номер_категории", продукт.Категория));
                cmd.Parameters.Add(new SqlParameter("@материал",  продукт.Материал));
                cmd.Parameters.Add(new SqlParameter("@масса", продукт.Масса));
                cmd.Parameters.Add(new SqlParameter("@количество", продукт.Количество));
                cmd.Parameters.Add(new SqlParameter("@цена_за_единицу", продукт.Цена_за_единицу));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }

    }

