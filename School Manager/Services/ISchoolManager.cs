using School.API.Entities;

namespace School_Manager.Services
{
    public interface ISchoolManager
    {
        Task<List<Schools>> GetSchools(int skip, int take);
        Task<Schools> GetSchool(int id);
        Task<Schools> AddSchool(Schools school);
        Task<Schools> UpdateSchool(Schools school);
        Task<bool> DeleteSchool (int id);
    }
}
