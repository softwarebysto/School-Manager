using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolodels.DTOS
{
    public class SchoolDTO
    {
        public int id { get; set; }
        public string? school_name { get; set; }
        public List<ClassesDTO>? classes { get; set; }
    }
}
