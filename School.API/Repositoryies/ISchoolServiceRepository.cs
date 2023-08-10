using School.API.Entities;

namespace School.API.Repositoryies
{
    public interface ISchoolServiceRepository
    {
        Task<List<Schools>> GetSchools(int skip, int take);
        Task<Schools> GetSChoolByID(int id);
        Task<Schools> AddSchool(Schools schoolsToAdd);
        Task<bool> DeleteSchool(int id);

        Task<Schools> UpdateSchool(Schools school);

    }
}
