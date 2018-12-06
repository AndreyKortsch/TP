using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Кат_продукция
    {
        public String Код_продукции { get; set; }
        public String Название_продукции { get; set; }
        public int Категория { get; set; }
        public String Материал { get; set; }
        public float Масса { get; set; }
        public float Цена_за_единицу { get; set; }
        public int Количество { get; set; }
        public int Код_категории { get; set; }
        public String Название { get; set; }
        public DateTime Дата_создания { get; set; }
        public int Количество_товара { get; set; }
       
    }
}