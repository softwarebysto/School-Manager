using School.API.Entities;
using Schoolodels.DTOS;
using System.Runtime.CompilerServices;

namespace School.API.Extentions
{
    public static class DtoConvertor
    {
        public static List<SchoolsDTO> ConvertToDto (this List<Schools> schools)
        {
            return (from schoolss in schools 
                    select new SchoolsDTO
                    {       
                        id = schoolss.id,
                        region_name=schoolss.region_name,
                        school_name=schoolss.school_name,
                    }).ToList ();
        }
        public static SchoolDTO  ConvertToDto(this School.API.Entities.School school)
        {
            return new SchoolDTO
            { 
                id = school.id,
                school_name = school.school_name,
                classes = null
            };                    
        }
    }
}
