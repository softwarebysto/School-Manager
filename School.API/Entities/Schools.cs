namespace School.API.Entities
{
    public class Schools
    {
        public int id { get; set; }
        public string? region_name { get; set; }
        public string? school_name { get; set; }
    }
    public class SchoolsView
    {
        public int id { get; set; }
        public string? region_name { get; set; }
        public string? school_name { get; set; }
        public bool editing { get; set; }
    }
}
