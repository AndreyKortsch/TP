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
                    категория.Количество_товара = Convert.ToInt32(reader["количество"]);
                    категория.Дата_создания = Convert.ToDateTime(reader["дата"]);
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
                "INSERT INTO Список_категорий(название, количество, дата) VALUES (@название, @количество, @дата)", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@название", категория.Название));
                cmd.Parameters.Add(new SqlParameter("@количество", '0'));
                cmd.Parameters.Add(new SqlParameter("@дата", DateTime.Now));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String a=ex.ToString();
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
       
        public Категория Категория(int id)
        {
            Connect();
            Категория Категория = new Категория();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_категорий WHERE номер =" + id, Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Категория.Код_категории = Convert.ToInt32(reader["номер"]);
                Категория.Название = Convert.ToString(reader["название"]);
                Категория.Количество_товара = Convert.ToInt32(reader["количество"]);
                Категория.Дата_создания = Convert.ToDateTime(reader["дата"]);
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return Категория;
        }
        public bool Изменить_категорию(int id, Категория категория)
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_категорий SET название='{0}',  дата='{1}' " +
                "WHERE номер='{2}'", категория.Название, DateTime.Now, id);
                SqlCommand cmd = new SqlCommand(sql, Сonnection);
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
        public bool Удалить_категорию(int id,Категория категория)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Список_категорий WHERE номер =" + id, Сonnection);
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
