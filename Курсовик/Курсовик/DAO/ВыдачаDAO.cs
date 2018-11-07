using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;

namespace Курсовик.DAO
{
    public class ВыдачаDAO : DAO
    {
        

        public List<Выдача> Журнал_выдач()
        {
            Connect();
            List<Выдача> Журнал_выдач = new List<Выдача>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Журнал_выдач", Сonnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Выдача выдача = new Выдача
                    {
                        Код_выдачи = Convert.ToInt32(reader["номер"]),
                        Код_продукции = Convert.ToString(reader["код_продукции"]),
                        Дата_и_время = Convert.ToDateTime(reader["дата_и_время"]),
                        Количество = Convert.ToInt32(reader["количество"])
                    };
                    Журнал_выдач.Add(выдача);
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
            return Журнал_выдач;
        }
        public bool Добавить_выдачу(String id, Выдача выдача)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Журнал_выдач (код_продукции, дата_и_время, " +
                "количество) " +
                "VALUES (@код_продукции, @дата_и_время, @количество)", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@код_продукции", id));
                cmd.Parameters.Add(new SqlParameter("@дата_и_время", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@количество", выдача.Количество));
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

        public bool Удалить_выдачу(int id,Выдача выдача)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Журнал_выдач WHERE номер=" + id, Сonnection);
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
        public Выдача Выдача(int id)
        {
            Connect();
            Выдача Поступление = new Выдача();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Журнал_выдач WHERE номер =" + id, Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Поступление.Код_выдачи = Convert.ToInt32(reader["номер"]);
                Поступление.Код_продукции = Convert.ToString(reader["код продукции"]);
                Поступление.Дата_и_время = Convert.ToDateTime(reader["дата_и_время"]);
                Поступление.Количество = Convert.ToInt32(reader["количество"]);
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return Поступление;
        }
        public bool Изменить_выдачу(int id, Выдача выдача)
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Журнал_выдач SET код_продукции='{0}', дата_и_время='{1}', количество='{2}' " +
                "WHERE номер={3}", выдача.Код_продукции, выдача.Дата_и_время, выдача.Количество, id);
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