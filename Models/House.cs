
using System.Collections.Generic;
namespace universeexplorer.Models

{
  public class House

  {
    public int Id { get; set; }

    public string HouseName { get; set; }

    public string HouseColor { get; set; }

    public List<StudentList> StudentLists { get; set; } = new List<StudentList>(); //why are we calling a function here ?
    //make this StudentList instead of Student so we know we do not need to keep it the same.. referring to title of controller and namespace within the controller
  }

}