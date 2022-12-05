using Microsoft.AspNetCore.Mvc;
using backend.Models;
namespace BEDotNetWebApi.Controllers;

[ApiController]
[Route("API/Student")]
public class EmployeeController : ControllerBase
{
private readonly WhiteDbContext DB;

public EmployeeController(WhiteDbContext db)
{
    this.DB = db;
}
[HttpPost("InsertStudent")]
public object InsertEmployee(Register regObj)
{
    try
    {
        AbStudent e1 =new AbStudent();
        if (e1.Id==0)
        {
            e1.StudentsName=regObj.RegStudentsName;
            e1.Age=regObj.RegAge;
            e1.Grade=regObj.RegGrade;            
            e1.Email=regObj.RegEmail;
            e1.Password=regObj.RegPassword;
            e1.ContactNumber=regObj.RegContactNumber;
            

            DB.AbStudents.Add(e1);

            DB.SaveChanges();

            return new Response{Status="Success",Message="Add!!!!"};
        }

    }
    catch(System.Exception)
    {
        throw;
    }
    return new Response{Status="Error",Message="Invalid Information"};
}
[HttpPost("Login")]
public IActionResult LoginCheck(Login logObj)
{
    var logindetail = DB.AbStudents.Where(x=>x.Email.Equals(logObj.Email)&&x.Password.Equals(logObj.Password)).FirstOrDefault();
    if(logindetail ==null)
    {
        return Ok(new Response{Status="not Valid",Message="Invalid Information"});
    }
    else{
        return Ok(new Response{Status="Success",Message="Welcome User"});
    
    }
}
// [HttpGet("GetAllStudent")]

// public IQueryable<AbStudent> GetEmployeelogins()
// {
//     try
//     {
//         return DB.AbStudents;
//     }
//     catch (System.Exception)
//     {
        
//         throw;
//     }

// }
[HttpGet("AllStudentDetails")]
    public IQueryable<AbStudent> GetAll()
    {
var users =this.DB.AbStudents;
return users;
    }

    
[HttpDelete("DeleteUserDetails/{uid}")]
    public IActionResult Deletestudent(int uid)
    {
        string message = "";
            var user = this.DB.AbStudents.Find(uid);
            if (user == null)
            {
                return NotFound();
            }

            this.DB.AbStudents.Remove(user);
            int result = this.DB.SaveChanges();
            if (result > 0)
            {
                message = "User has been successfully deleted";
            }
            else
            {
                message = "failed";
            }

            return Ok(message);
        }

}


