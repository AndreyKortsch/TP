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
            public List<Продукция> Список_продукции(String sql)
            {
               Connect();
                List<Продукция> Список_продукции = new List<Продукция>();
                try
                {
                    SqlCommand command = new SqlCommand(sql, Сonnection);
                   
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Продукция товар = new Продукция();
                        товар.Код_продукции = Convert.ToString(reader["код_продукции"]);
                        товар.Название = Convert.ToString(reader["название"]);
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
        public bool Добавить_категорию(Продукция продукт)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "UPDATE Список_продукции SET номер_категории ='{1}'" +
                "WHERE код_продукции='{0}'", Сonnection);
                cmd.Parameters.Add(new SqlParameter("@код_продукции", продукт.Код_продукции));
                cmd.Parameters.Add(new SqlParameter("@номер_категории", продукт.Категория));
                cmd.ExecuteNonQuery();
                String sql = string.Format("UPDATE Список_категорий SET количество=количество+'{0}'" +
                "WHERE номер='{1}'", продукт.Количество, продукт.Категория);
                SqlCommand cmd1 = new SqlCommand(sql, Сonnection);
                cmd1.ExecuteNonQuery();
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
        public bool Добавить_продукт(Продукция продукт)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Список_продукции (код_продукции, название, номер_категории, " +
                "материал, масса, количество, цена_за_единицу) " +
                "VALUES (@код_продукции, @название, @номер_категории, @материал, @масса, @количество,@цена_за_единицу)",Сonnection);
                cmd.Parameters.Add(new SqlParameter("@код_продукции", продукт.Код_продукции));
                cmd.Parameters.Add(new SqlParameter("@название", продукт.Название));
                cmd.Parameters.Add(new SqlParameter("@номер_категории", продукт.Категория));
                cmd.Parameters.Add(new SqlParameter("@материал",  продукт.Материал));
                cmd.Parameters.Add(new SqlParameter("@масса", продукт.Масса));
                cmd.Parameters.Add(new SqlParameter("@количество", продукт.Количество));
                cmd.Parameters.Add(new SqlParameter("@цена_за_единицу", продукт.Цена_за_единицу));
                cmd.ExecuteNonQuery();
                String sql = string.Format("UPDATE Список_категорий SET количество=количество+'{0}'" +
                "WHERE номер='{1}'", продукт.Количество, продукт.Категория);
                SqlCommand cmd1 = new SqlCommand(sql, Сonnection);
                cmd1.ExecuteNonQuery();
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
        public bool Удалить_продукцию(String id,Продукция продукция)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Список_продукции WHERE код_продукции=" + id, Сonnection);
                cmd.ExecuteNonQuery();
                Продукция продукт=Продукция(id);
                String sql = string.Format("UPDATE Список_категорий SET количество=количество-'{0}'" +
                "WHERE номер='{1}'", продукт.Количество, продукт.Категория);
                SqlCommand cmd1 = new SqlCommand(sql, Сonnection);
                cmd1.ExecuteNonQuery();

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
        public Продукция Продукция(String id)
        {
            Connect();
            Продукция товар = new Продукция();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_продукции WHERE код_продукции =" + id, Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                товар.Код_продукции = Convert.ToString(reader["код_продукции"]);
                товар.Название = Convert.ToString(reader["название"]);
                товар.Категория = Convert.ToInt32(reader["номер_категории"]);
                товар.Количество = Convert.ToInt32(reader["количество"]);
                товар.Масса = Convert.ToUInt32(reader["масса"]);
                товар.Материал = Convert.ToString(reader["материал"]);
                товар.Цена_за_единицу = Convert.ToInt32(reader["цена_за_единицу"]);
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return  товар;
        }
        public bool Изменить_продукцию(String id, Продукция продукция)
        {
            Connect();
            bool result = true;
            try
            {
                String sql = string.Format("UPDATE Список_продукции SET номер_категории='{0}', название='{1}'" +
                    " ,количество='{2}', масса='{3}', материал='{4}', цена_за_единицу='{5}'" +
                "WHERE код_продукции='{6}'", продукция.Категория, продукция.Название ,продукция.Количество, 
                продукция.Масса, продукция.Материал, продукция.Цена_за_единицу, id);
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

