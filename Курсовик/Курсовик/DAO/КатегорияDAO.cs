using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;

namespace Курсовик.DAO
{
    public class КатегорияDAO:DAO
    {
        public List<Категория> Список_категорий()
        {
            Connect();
            List<Категория> Список_категорий = new List<Категория>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_категорий", Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Категория категория = new Категория();
                    категория.Код_категории = Convert.ToInt32(reader["номер"]);
                    категория.Название = Convert.ToString(reader["название"]);
                    категория.Количество_товара = Convert.ToInt32(reader["количество_товаров"]);
                    категория.Дата_создания = Convert.ToDateTime(reader["дата_создания"]);
                    Список_категорий.Add(категория);
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
            return Список_категорий;
        }
        public bool Добавить_категорию(Категория категория)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Список_категорий (название, количество_товаров, дата_создания) " +
                "VALUES (@название, 0, curdate())", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@название", категория.Название));
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
