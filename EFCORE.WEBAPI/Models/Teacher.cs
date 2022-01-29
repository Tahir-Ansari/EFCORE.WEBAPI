using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCORE.WEBAPI.Models
{
    public class Teacher : Entity
    {
        public string FullName { get; set; }
        public string SubjectName { get; set; }
        public DateTime Date_Of_Joining { get; set; }
        public string Salary { get; set; }
    }
}
