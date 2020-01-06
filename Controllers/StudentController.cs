
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using universeexplorer.Models;
using Microsoft.EntityFrameworkCore;

namespace universeexplorer.Controllers

{

  [ApiController]
  [Route("api/[controller]")]

  public class StudentController : ControllerBase

  {

    [HttpGet]
    public ActionResult GetAllStudents()

    {

      var db = new DatabaseContext();
      return Ok(db.StudentLists.OrderBy(x => x.Name));

    }

    [HttpPost]
    public ActionResult CreateStudent(StudentList tempstudent)

    {

      var db = new DatabaseContext();
      var student = db.StudentLists.FirstOrDefault(y => y.Id == tempstudent.HouseId);


      if (student == null)

      {
        return NotFound();
      }

      else

      {
        var table = new StudentList

        {
          Name = tempstudent.Name,
          FavoriteSpell = tempstudent.FavoriteSpell,

   Sex = tempstudent.Sex,
    HouseId = tempstudent.HouseId

        };

        db.StudentLists.Add(table);
        db.SaveChanges();
        return Ok(table);

      }


    }



    [HttpPut("{id}")]
    public ActionResult UpdateStudent(StudentList student)

    {

      var db = new DatabaseContext();
      var prevStudent = db.StudentLists.FirstOrDefault(temp => temp.Id == student.Id);

      if (prevStudent == null)

      {
        return NotFound();
      }

      else

      {

        prevStudent.Name = student.Name;
        db.SaveChanges();
        return Ok(prevStudent);

      }

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteStudent(int id)

    {

      var db = new DatabaseContext();
      var xStudent = db.StudentLists.FirstOrDefault(temp => temp.Id == id);

      if (xStudent == null)

      {
        return NotFound();
      }

      else

      {

        db.StudentLists.Remove(xStudent);
        db.SaveChanges();
        return Ok();

      }

    }

    [HttpGet("{id}")]
    public ActionResult SingleStudent(int id)

    {

      var db = new DatabaseContext();
      var xStudent = db.StudentLists.Include(x => x.Id).FirstOrDefault(y => y.Id == id);

      if (xStudent == null)

      {
        return NotFound();
      }

      else

      {
        return Ok();
      }

    }

  }

}

