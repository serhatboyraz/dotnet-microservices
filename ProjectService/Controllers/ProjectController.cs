using System.Collections.Generic;
using ExampleMicroservices.Base.Controllers;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Data.Context;
using ProjectService.Data.Models;

namespace ProjectService.Controllers
{
    [Route("/")]
    [ApiController]
    public class ProjectController : CrudController<ProjectModel,ProjectDbContext>
    {
    }
}
