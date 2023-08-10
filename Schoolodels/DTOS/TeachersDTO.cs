using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolodels.DTOS
{
    public class TeachersDTO
    {
        public int id { get; set; }
        public int subject_id { get; set; }
        public string? teacher_name { get; set; }
    }
}
