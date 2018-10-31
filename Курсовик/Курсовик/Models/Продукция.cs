using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Продукция
    {
            public String Код_продукции { get; set; }
            public int Категория { get; set; }
            public String Материал { get; set; }
            public float Масса { get; set; }
            public float Цена_за_единицу { get; set; }
            public int Количество { get; set; }
            public List<Продукция> Список_продукции { get; set; }
    }
}