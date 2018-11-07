using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;

namespace Курсовик.DAO
{
    public class ПоступлениеDAO:DAO
    {
       
            public List<Поступление> Журнал_поступлений()
            {
                Connect();
                List<Поступление> Журнал_поступлений = new List<Поступление>();
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Журнал_поступлений", Сonnection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Поступление поступление = new Поступление();
                        поступление.Код_поступления = Convert.ToInt32(reader["номер"]);
                        поступление.Код_продукции = Convert.ToString(reader["код_продукции"]);
                        поступление.Дата_и_время = Convert.ToDateTime(reader["дата_и_время"]);
                        поступление.Количество = Convert.ToInt32(reader["количество"]);
                        Журнал_поступлений.Add(поступление);
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
                return Журнал_поступлений;
            }
            public bool Добавить_поступление(Поступление поступление)
            {
                Connect();
                bool result = true;
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Журнал_поступлений (код_продукции, дата_и_время, количество) " +
                    "VALUES (@код_продукции, @дата_и_время, @количество)", Сonnection);
                    cmd.Parameters.Add(new SqlParameter("@код_продукции", поступление.Код_продукции));
                    cmd.Parameters.Add(new SqlParameter("@дата_и_время", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@количество", поступление.Количество));
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

            public bool Удалить_поступление(int id, Поступление поступление)
            {
                Connect();
                bool result = true;
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Журнал_поступлений WHERE номер=" + id, Сonnection);
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
            public Поступление Поступление(int id)
            {
                Connect();
                Поступление Поступление = new Поступление();
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Журнал_поступлений WHERE номер =" + id, Сonnection);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Поступление.Код_поступления = Convert.ToInt32(reader["номер"]);
                    Поступление.Код_продукции = Convert.ToString(reader["код_продукции"]);
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
            public bool Изменить_поступление(int id,Поступление поступление)
            {
                Connect();
                bool result = true;
                try
                {
                    String sql = string.Format("UPDATE Журнал_поступлений SET код_продукции='{0}', дата_и_время='{1}', количество='{2}' "+
                    "WHERE номер={3}", поступление.Код_продукции, DateTime.Now, поступление.Количество, id);
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