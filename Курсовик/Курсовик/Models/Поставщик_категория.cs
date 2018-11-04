using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Поставщик_категория
    {
        public int Код_поставщика { get; set; }
        public  int Код_категории { get ;  set ;  }
        public String Название { get; set; }
        public DateTime Дата_создания { get;  set; }
        public int Количество_товара { get;  set; }
    }
}