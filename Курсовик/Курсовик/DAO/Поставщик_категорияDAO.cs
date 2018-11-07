using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;

namespace Курсовик.DAO
{
    public class Поставщик_категорияDAO:DAO
    {
        public List<Поставщик_категория> Список_категорий(String sql,int id)
        {
            Connect();
            List<Поставщик_категория> Список_категорий = new List<Поставщик_категория>();
            try
            {
                SqlCommand command = new SqlCommand(sql, Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Поставщик_категория категория = new Поставщик_категория();
                    категория.Код_поставщика = id;
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
        public bool Удалить_категорию(int id, int a)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Поставщик_категория WHERE (номер_поставщика="+id+") and (номер_категории="+a+")" , Сonnection);
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
        public bool Добавить_категорию(int id, int a)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Поставщик_категория(номер_категории, номер_поставщика) VALUES (@номер_категории, @номер_поставщика)", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@номер_категории", a));
                cmd.Parameters.Add(new SqlParameter("@номер_поставщика", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String ac = ex.Message;
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