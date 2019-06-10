using System.Collections.Generic;
using ExampleMicroservices.Base.Controllers; 
using Microsoft.AspNetCore.Mvc;
using UserService.Data.Context;
using UserService.Data.Models;

namespace UserService.Controllers
{
    [Route("/")]
    public class UserController : CrudController<UserModel,UserDbContext>
    {
        
    }
}
