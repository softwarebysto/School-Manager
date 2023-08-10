using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolodels.DTOS
{
    public class StudentsDTO
    {
        public int Id { get; set; }
        public int class_id { get; set; }
        public string? Name { get; set; }
        public List<SubjectsDTO>? subjects { get; set; }
    }
}
