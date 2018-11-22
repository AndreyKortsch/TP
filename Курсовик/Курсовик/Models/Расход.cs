using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Курсовик.Models
{
    public class Расход
    {
        public String Код_продукции { get; set; }
        public String Название { get; set; }
        public int Приход_за_сутки { get; set; }
        public int Расход_за_сутки { get; set; }
        public int Расход_по_норме { get; set; }
        public float Коэффициент_расхода { get; set; }
        
    }
}