using Microsoft.AspNetCore.Mvc;
using School.API.Entities;
using School.API.Extentions;
using School.API.Repositoryies;

namespace School.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolServiceRepository schoolServiceRepository;
        public SchoolController(ISchoolServiceRepository schoolServiceRepository)
        {
            this.schoolServiceRepository = schoolServiceRepository;
        }

        [HttpGet]
        [Route("/returnt-school-list/{skip:int}/{take:int}")]
        public async Task<ActionResult<List<Schools>>> GetSchools(int skip, int take)
        {
            try
            {
                var schools = await schoolServiceRepository.GetSchools(skip, take);
                if (schools == null)
                {
                    return NotFound();
                }
                else
                {
                    var schoolsDto = schools.ConvertToDto();
                    return Ok(schoolsDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<School.API.Entities.School>> GetSchoolByID(int id)
        {
            try
            {
                if (schoolServiceRepository != null)
                {
                    var schools = await schoolServiceRepository.GetSChoolByID(id);
                    if (schools == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var schoolsDto = schools;
                        return Ok(schoolsDto);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "Data not found");
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }
        [HttpPost("AddSchool")]
        public async Task<ActionResult<Schools>> AddSchool([FromBody] Schools schoolToAdd)
        {
            try
            {
                var newSchool = await schoolServiceRepository.AddSchool(schoolToAdd);
                if (newSchool == null)
                {
                    return NoContent();
                }
                return Ok(newSchool);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSchool(int id)
        {
            try
            {
                bool isSuccess = await schoolServiceRepository.DeleteSchool(id);
                if (!isSuccess)
                {
                    return false;
                }
                else
                {
                    return Ok(true);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Schools>> UpdateSchool([FromBody] Schools school)
        {
            try
            {
                var res = schoolServiceRepository.UpdateSchool(school);
                if (res==null)
                {
                    NotFound("There is no school with this id");
                }
                return Ok(res?.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

    }
}
