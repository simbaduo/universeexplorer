
using System;
namespace universeexplorer.Models

{
  public class StudentList

  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string FavoriteSpell { get; set; }

    public string Sex { get; set; }
    public int HouseId { get; set; }

    public House House { get; set; }
  }

}