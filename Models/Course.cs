using GolfCard.InterfacesActual;
using System;
using System.Collections.Generic;

namespace GolfCard.Models
{
  public class Course : ICourse
  {
    public string Name { get; set; }
    public List<Hole> Holes { get; set; }
    public Course(string name)
    {
      Name = name;
      Holes = new List<Hole>();
    }
    public int CoursePar
    {
      get
      {
        int par = 0;
        foreach (Hole hole in Holes)
        {
          par = par + hole.Par;
        }
        return par;
      }
    }
  }


}
