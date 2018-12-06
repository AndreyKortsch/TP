using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Курсовик.Models;
namespace Курсовик.DAO
{
    public class Кат_продукцияDAO:DAO
    {
       
        public List<Кат_продукция> Список_категорий(Кат_продукция категория1)
        {
            Connect();
            List<Кат_продукция> Список_категорий = new List<Кат_продукция>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Список_категорий", Сonnection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Кат_продукция категория = new Кат_продукция();
                    категория.Код_категории = Convert.ToInt32(reader["номер"]);
                    категория.Название = Convert.ToString(reader["название"]);
                    категория.Количество_товара = Convert.ToInt32(reader["количество"]);
                    категория.Дата_создания = Convert.ToDateTime(reader["дата"]);
                    категория.Код_продукции = категория1.Код_продукции;
                    категория.Количество = категория1.Количество;
                    категория.Масса = категория1.Масса;
                    категория.Категория = Convert.ToInt32(reader["номер"]);
                    категория.Материал = категория1.Материал;
                    категория.Название_продукции = категория1.Название_продукции;
                    категория.Цена_за_единицу = категория1.Цена_за_единицу;
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
    }
}