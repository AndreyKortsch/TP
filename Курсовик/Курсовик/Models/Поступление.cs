using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Поступление
    {
        public int Код_поступления { get; set; }
        public String Код_продукции { get; set; }
        public DateTime Дата { get; set; }
        public DateTime Время { get; set; }
        public int Количество { get; set; }
        public List<Поступление> Список_поступлений { get; set; }
    }
}