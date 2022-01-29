using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCORE.WEBAPI.Models
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Class { get; set; }
        public string Div { get; set; }
    }
}
