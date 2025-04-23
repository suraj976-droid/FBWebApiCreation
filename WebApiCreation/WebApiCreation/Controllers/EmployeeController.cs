using Microsoft.AspNetCore.Mvc;
using WebApiCreation.Data;
using WebApiCreation.Models;


namespace WebApiCreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddEmployee(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            return Ok("Added Successfully");
        }

        [Route("GetEmp")]
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var data = db.emps.ToList();
            return Ok(data);
        }


        [Route("DelEmp/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmp(int id)
        {
            var data = db.emps.Find(id);
            db.emps.Remove(data);
            db.SaveChanges();
            return Ok("Deleted Successfully");
        }

        // Multiple Delete

        [Route("EmpDels")]
        [HttpDelete]
        public IActionResult MultipleDelete(List<int> ids)
        {
            var data = db.emps.Where(x => ids.Contains(x.Id)).ToList();
            db.RemoveRange(data);
            db.SaveChanges();
            return Ok("Deleted Successfully");
        }


        [Route("FindByName/{name}")]
        [HttpPost]
        public IActionResult FindEmpByName(string name)
        {
            var data = db.emps.Where(x => x.name.Contains(name)).ToList();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Data Not Found");

            }
        }


                // **** User Model Start **** //
                // Multiple Insertion using List and from body take as a array [ {}, {}]

        [Route("AddMultipleUser")]
        [HttpPost]
        public IActionResult AddUser(List<User> u)
        {
            db.users.AddRange(u);
            db.SaveChanges();
            return Ok("User Added Successfully");
        }

        [Route("GetUser")]
        [HttpGet]

      public IActionResult FetchUser ()
        {
            var data = db.users.ToList();
            return Ok(data);
        }

        // we can use [FromForm] for testing purpose only it will give us Form
        [Route("login")]
        [HttpPost]
        public IActionResult Login(User e)
        {
           var login = db.users.Where(x=> x.Email == e.Email && x.Password == e.Password).FirstOrDefault();
            if ( login != null)
            {
                return Ok("Login Successfully");
            }
            else
            {
                return NotFound("Login Failed");
            }

        }
    }
}
