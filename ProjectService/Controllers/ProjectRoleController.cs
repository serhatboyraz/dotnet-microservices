using System.Collections.Generic;
using System.Linq;
using DMicroservices.Base.Controllers;
using DMicroservices.DataAccess.UnitOfWork;
using DMicroservices.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Data.Context;
using ProjectService.Data.Models;

namespace ProjectService.Controllers
{
    [Route("/Roles")]
    [ApiController]
    public class ProjectRoleController : CrudController<ProjectRoleModel, ProjectDbContext>
    {

        // GET api/values/5
        [HttpGet("GetByProjectId/{id}")]
        public List<ProjectRoleModel> GetByProjectId(int id)
        {
            using (var uow = new UnitOfWork<ProjectDbContext>())
            {
                var projectRoleRepo = uow.GetRepository<ProjectRoleModel>();
                return projectRoleRepo.GetAll(x => x.ProjectId == id)
                    .Include(projectRoleRepo.GetDbContext().GetIncludePaths(typeof(ProjectRoleModel))).ToList();

            }
        }
    }
}
