using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolodels.DTOS
{
    public class ClassesDTO
    {
        public int id { get; set; }
        public int students_count { get; set; }
        public string? class_name { get; set; }
        public List<StudentsDTO>? students { get; set; }    
    }
}
