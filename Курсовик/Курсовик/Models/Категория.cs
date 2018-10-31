using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Категория
    {
        public int Код_категории { get; set; }
        public String Название { get; set; }
        public DateTime Дата_создания { get; set; }
        public int Количество_товара { get; set; }
        public List<Категория> Список_категорий { get; set; }
    }
}