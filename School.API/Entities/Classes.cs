using Schoolodels.DTOS;

namespace School.API.Entities
{
    public class Classes
    {
        public int id { get; set; }
        public int students_count { get; set; }
        public string? class_name { get; set; }
        public List<Students>? students { get; set; }
    }
}
