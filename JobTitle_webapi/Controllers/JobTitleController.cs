using JobTitle_webapi.Data;
using JobTitle_webapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobTitle_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public JobTitleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTitle()
        {
            List<JobTitle> jobTitles = dbContext.JobTitles.Select(x => new JobTitle()
            {
                Id= x.Id,
                Name = x.Name,
                Prefix = x.Prefix,
                Description = x.Description
            }).ToList();
            return Ok();
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetJobTitle(long id)
        {
            var jobTitle = dbContext.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return NotFound();
            }
            JobTitleViewModel jobTitleViewModel = new JobTitleViewModel()
            {
                Id = jobTitle.Id,
                Name = jobTitle.Name,
                Prefix = jobTitle.Prefix,
                Description = jobTitle.Description,
                CreateOrUpdatedBy = jobTitle.CreateBy,
                CreateOrUpdatedOn = jobTitle.CreatedOn
            };

            return Ok(jobTitle);
        }

        [HttpPost]
        public IActionResult CreateJobTitle([FromBody]JobTitleViewModel jobTitleViewModel)
        {
            if(ModelState.IsValid)
            {
                JobTitle jobTitle = new JobTitle()
                {
                    Name = jobTitleViewModel.Name,
                    Prefix = jobTitleViewModel.Prefix,
                    Description = jobTitleViewModel.Description,
                    CreateBy = jobTitleViewModel.CreateOrUpdatedBy,
                    CreatedOn = DateTime.Now
                };
                dbContext.JobTitles.Add(jobTitle);
                dbContext.SaveChanges();
                return Ok(jobTitle);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:long}")]
        public IActionResult UpdateJobTitle(long id, JobTitleViewModel jobTitleViewModel)
        {
            if (ModelState.IsValid)
            {
                var jobTitle = dbContext.JobTitles.Find(id);
                if (jobTitle == null)
                {
                    return NotFound();
                }
                jobTitle.Name = jobTitleViewModel.Name;
                jobTitle.Prefix = jobTitleViewModel.Prefix;
                jobTitle.Description = jobTitleViewModel.Description;
                jobTitle.UpdatedBy = jobTitleViewModel.CreateOrUpdatedBy;
                jobTitle.UpdatedOn = DateTime.Now;
                dbContext.SaveChanges();
                return Ok(jobTitle);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteJobTitle(long id)
        {
            var jobTitle = dbContext.JobTitles.Find(id);
            if(jobTitle ==null)
            {
                return NotFound();
            }
            dbContext.JobTitles.Remove(jobTitle);
            jobTitle.DeletedOn = DateTime.Now;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
