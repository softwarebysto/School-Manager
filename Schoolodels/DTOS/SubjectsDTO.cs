using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolodels.DTOS
{
    public class SubjectsDTO
    {
        public int id { get; set; }
        public int? techer_id { get; set;}
        public string? subject_name { get; set; }
    }
}
