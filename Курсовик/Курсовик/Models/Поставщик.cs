using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Поставщик
    {
            public int Код_поставщика { get; set; }
            public String Наименование_организации { get; set; }
            public String Адрес { get; set; }
            public String Почта { get; set; }
            public String Телефон { get; set; }
            public List<Поставщик> Список_поставщиков { get; set; }
    }
}