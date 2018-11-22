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
                String sql = string.Format("UPDATE Список_продукции SET статус is null, расход_по_норме is null");
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
