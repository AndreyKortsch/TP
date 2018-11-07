using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;


namespace Курсовик.DAO
{
    public class ПоставщикDAO : DAO
    {
        public List<Поставщик> Список_поставщиков()
        {
            Connect();
            List<Поставщик> Список_поставщиков = new List<Поставщик>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_поставщиков", Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Поставщик поставщик = new Поставщик();
                    поставщик.Код_поставщика = Convert.ToInt32(reader["код_поставщика"]);
                    поставщик.Наименование_организации = Convert.ToString(reader["наименование_организации"]);
                    поставщик.Адрес = Convert.ToString(reader["адрес"]);
                    поставщик.Почта = Convert.ToString(reader["почта"]);
                    поставщик.Телефон = Convert.ToString(reader["телефон"]);
                    Список_поставщиков.Add(поставщик);
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
            return Список_поставщиков;
        }
        public bool Добавить_поставщика(Поставщик поставщик)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Список_поставщиков (наименование_организации, адрес, " +
                "почта, телефон) " +
                "VALUES (@наименование_организации, @адрес, @почта,@телефон)", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@наименование_организации", поставщик.Наименование_организации));
                cmd.Parameters.Add(new SqlParameter("@адрес", поставщик.Адрес));
                cmd.Parameters.Add(new SqlParameter("@почта", поставщик.Почта));
                cmd.Parameters.Add(new SqlParameter("@телефон", поставщик.Телефон));
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

        public bool Удалить_поставщика(int id)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Список_поставщиков WHERE код_поставщика=" + id, Сonnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String a = ex.Message;
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        public Поставщик Поставщик(int id)
        {
            Connect();
            Поставщик Поставщик = new Поставщик();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_поставщиков WHERE код_поставщика ="+id, Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Поставщик.Код_поставщика = Convert.ToInt32(reader["код_поставщика"]);
                Поставщик.Наименование_организации = Convert.ToString(reader["наименование_организации"]);
                Поставщик.Адрес = Convert.ToString(reader["адрес"]);
                Поставщик.Почта = Convert.ToString(reader["почта"]);
                Поставщик.Телефон = Convert.ToString(reader["телефон"]);
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return Поставщик;
        }
        public bool Изменить_поставщика(int id, Поставщик поставщик)
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_поставщиков SET наименование_организации='{0}', адрес='{1}', почта='{2}', телефон='{3}' " +
                "WHERE код_поставщика='{4}'", поставщик.Наименование_организации, поставщик.Адрес, поставщик.Почта, поставщик.Телефон, id);
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
    }
}