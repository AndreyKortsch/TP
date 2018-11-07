using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Выдача
    {
        public int Код_выдачи { get; set; }
        public String Код_продукции { get; set; }
        public DateTime Дата_и_время { get; set; }
        public int Количество { get; set; }
        public List<Выдача> Список_выдач { get; set; }
    }
}