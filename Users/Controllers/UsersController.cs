using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UsersController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "John", "Paul", "Ringo", "George", "Pete", "Stuart", "Norman", "Chas", "Tommy", "Jimmy"
        };

        private static readonly string[] LastNames = new[]
        {
            "Lennon", "McCartney", "Starr", "Harrison", "Best", "Sutcliffe", "Chapman", "Newby", "Moore", "Nicol"
        };

        // GET api/values
        [HttpGet]
        [OpenApiOperation("GetAll_Users", "Get a list of Users", "Get a list of Users")]
        [OpenApiTag("Users", AddToDocument = true)]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var rng = new Random();
            var nextIndex = getRandomNext();
            return Enumerable.Range(1, 5).Select(index =>
            {
                return new User
                {
                    FirstName = Names[nextIndex],
                    LastName = LastNames[nextIndex],
                    Email = $"{Names[nextIndex] + LastNames[nextIndex]}@gmail.com",
                    Id = Guid.NewGuid(),
                    Phone = rng.Next(-20, 1000) + ""
                };
            })
            .ToArray();
        }

        // GET api/values/5
        [HttpGet("{userId}")]
        [OpenApiOperation("GetById_Users", "Get a User by its id", "Get a User by its id")]
        [OpenApiTag("Users", AddToDocument = true)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public ActionResult<User> GetById(Guid userId)
        {
            var rng = new Random();
            var nextIndex = getRandomNext();

            return new User
            {
                FirstName = Names[nextIndex],
                LastName = LastNames[nextIndex],
                Email = $"{Names[nextIndex] + LastNames[nextIndex]}@gmail.com",
                Id = userId,
                Phone = rng.Next(-20, 1000) + ""
            };
        }

        // POST api/values
        [HttpPost]
        [OpenApiOperation("Create_Users", "Create a new User", "Create a new User")]
        [OpenApiTag("Users", AddToDocument = true)]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        public ActionResult<User> Post([FromBody] User user)
        {
            return Created("", user);
        }

        private int getRandomNext()
        {
            var rng = new Random();
            return rng.Next(Names.Length);
        }
    }
}
