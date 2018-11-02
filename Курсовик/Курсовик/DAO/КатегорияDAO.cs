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
        public List<Категория> Список_категорий(int id)
        {
            Connect();
            List<Категория> Список_категорий = new List<Категория>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_категорий " +
                    "WHERE номер not in (SELECT номер категории from Поставщик_категория WHERE " +
                    "номер поставщика="+id+")", Сonnection);

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
                "INSERT INTO Список_категорий (название, количество_товаров, " +
                "дата_создания) VALUES (@назван, @кол, @время)", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@назван", категория.Название));
                cmd.Parameters.Add(new SqlParameter("@кол", '0'));
                cmd.Parameters.Add(new SqlParameter("@время", DateTime.Now));
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
                SqlCommand command = new SqlCommand("SELECT * FROM Список_поставщиков WHERE код_поставщика =" + id, Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Категория.Код_категории = Convert.ToInt32(reader["номер"]);
                Категория.Название = Convert.ToString(reader["название"]);
                Категория.Количество_товара = Convert.ToInt32(reader["количество_товаров"]);
                Категория.Дата_создания = Convert.ToDateTime(reader["дата_создания"]);
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
        public bool Изменить_категорию(Категория категория)
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_категорий SET название='{0}', количество_товаров='{1}', дата_создания='{2}'" +
                "WHERE номер={3}", категория.Название, категория.Количество_товара, категория.Дата_создания, категория.Код_категории);
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
        public bool Удалить_категорию(Категория категория)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Список_категорий" +
                "WHERE номер=" + категория.Код_категории, Сonnection);
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
