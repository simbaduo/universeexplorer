
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using universeexplorer.Models;
using Microsoft.EntityFrameworkCore;

namespace universeexplorer.Controllers

{

  [ApiController]
  [Route("api/[controller]")]

  public class HouseController : ControllerBase

  {

    [HttpGet] //type 1
    public ActionResult GetAllHouses()

    { //return list of all tektites, order by name

      var db = new DatabaseContext();
      return Ok(db.Houses.OrderBy(x => x.HouseName));

    }

    [HttpGet("{id}")]
    public ActionResult GetOneStudent(int id)

    {

      var db = new DatabaseContext();
      var xHouse = db.Houses.FirstOrDefault(x => x.Id == id);

      if (xHouse == null)

      {
        return NotFound();
      }

      else

      {
        return Ok(xHouse);
      }

    }


    [HttpPost] //type 2
    public ActionResult CreateHouse(House house) //xTektite?

    {

      var db = new DatabaseContext();
      db.Houses.Add(house);
      db.SaveChanges();
      return Ok(house);

    }

    [HttpPut("{id}")]//what happens with no id? - type 3
    public ActionResult UpdateHouse(House house)

    {

      var db = new DatabaseContext(); //can you use const in C#
      var prevHouse = db.Houses.FirstOrDefault(temp => temp.Id == house.Id); //difference between line 18, 25 and 51

      if (prevHouse == null)

      {
        return NotFound();
      }

      else

      {
        prevHouse.HouseName = house.HouseName; //how does this actually work
        prevHouse.HouseColor = house.HouseColor;
        db.SaveChanges();
        return Ok(prevHouse); //why are we returning prevHouse ? previous?
      }

    }

    [HttpDelete("{id}")]// type 4
    public ActionResult DeleteHouse(int id) //line 46 vs 78?

    {

      var db = new DatabaseContext(); //can you use const in C#
      var xHouse = db.Houses.FirstOrDefault(temp => temp.Id == id); //explain this again?

      if (xHouse == null)

      {
        return NotFound();
      }

      else

      {

        db.Houses.Remove(xHouse);
        db.SaveChanges();
        return Ok(); //dont need to pass anything?

      }

    }

  }

}

