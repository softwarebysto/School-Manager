using Schoolodels.DTOS;

namespace School.API.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public int class_id { get; set; }
        public string? Name { get; set; }
        public List<SubjectsDTO>? subjects { get; set; }
    }
}
