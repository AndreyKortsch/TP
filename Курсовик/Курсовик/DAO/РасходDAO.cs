using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Курсовик.Models;
using System.Data.SqlClient;
namespace Курсовик.DAO
{
    public class РасходDAO:DAO
    {
        public List<Расход> Табель_расхода(String sql)
        {
            Connect();
            List<Расход> Табель_расхода = new List<Расход>();
            try
            {
                SqlCommand command = new SqlCommand(sql, Сonnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Расход товар = new Расход();
                    товар.Код_продукции = Convert.ToString(reader["a"]);
                    товар.Название = Convert.ToString(reader["b"]);
                    товар.Приход_за_сутки = Convert.ToInt32(reader["c"]);
                    товар.Расход_за_сутки = Convert.ToInt32(reader["d"]);
                    товар.Расход_по_норме = Convert.ToUInt32(reader["e"]);
                    //товар.Код_продукции = reader.GetString(0);
                    //товар.Название = reader.GetString(1);
                    //товар.Приход_за_сутки =  reader.GetInt32(6);
                    //товар.Расход_за_сутки = reader.GetInt32(4);
                    //товар.Расход_по_норме= reader.GetFloat(2);
                    товар.Коэффициент_расхода = (float )товар.Расход_за_сутки/(float)товар.Приход_за_сутки;
                    Табель_расхода.Add(товар);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                String a = ex.Message;
                a="";
            }
            finally
            {
                Disconnect();
            }
            return Табель_расхода;
        }
        public bool Обновить_статус(String id, Расход расход)
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_продукции SET расход_по_норме='{0}', статус= 'черновик'"+
                "WHERE код_продукции='{1}'", расход.Расход_по_норме, id);
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
        public bool Обновить_статус1()
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_продукции SET статус= 'создан'" +
                "WHERE расход_по_норме is not NULL");
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
        public bool Обновить_статус2()
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_продукции SET статус=null, расход_по_норме=null");
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
