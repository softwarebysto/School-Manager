using Schoolodels.DTOS;

namespace School.API.Entities
{
    public class School
    {
        public int id { get; set; }
        public string? school_name { get; set; }
        public List<Classes>? classes { get; set; }
    }
}
