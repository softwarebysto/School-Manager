using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Entities;

namespace School.API.Repositoryies
{
    public class SchoolServiceRepository : ISchoolServiceRepository
    {
        private readonly ShcoolDbContext schoolDbContext;
        public SchoolServiceRepository(ShcoolDbContext shcoolDbContext)
        {
            this.schoolDbContext = shcoolDbContext;
        }
        public async Task<List<Schools>> GetSchools(int skip, int take)
        {
            var schools = await schoolDbContext.schools.Skip(skip).Take(take).ToListAsync();

            return schools;
        }

        public async Task<Schools> GetSChoolByID(int id)
        {
            var school = await schoolDbContext.schools.SingleOrDefaultAsync(x => x.id == id);
            return school;
        }

        public async Task<Schools> AddSchool(Schools schoolsToAdd)
        {
            var schools = await schoolDbContext.schools.AddAsync(schoolsToAdd);
            await schoolDbContext.SaveChangesAsync();
            return schools.Entity;
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSchool(int id)
        {
            try
            {
                var schools = await schoolDbContext.schools.ToListAsync();
                if (schools.Where(w => w.id == id).Any())
                {
                    schoolDbContext.schools.Where(w => w.id == id).ExecuteDelete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public async Task<Schools>? UpdateSchool(Schools school)
        {
            try
            {
                var schooldb = await schoolDbContext.schools.ToListAsync();
                if (schooldb.Where(w => w.id == school.id).Any())
                {
                    var schoolUpdate = schooldb.Where(w => w.id == school.id).First();
                    schoolUpdate.school_name = (school.school_name !=null && school.school_name !="string") ? school.school_name : schoolUpdate.school_name;
                    schoolUpdate.region_name = (school.region_name !=null && school.region_name != "string") ? school.region_name : schoolUpdate.region_name;
                    var res = schoolDbContext.schools.Update(schoolUpdate);
                    schoolDbContext.SaveChanges();
                    return res.Entity;
                }
                else
                {
                    return null;
                    //throw new Exception("There is no school with this id");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
