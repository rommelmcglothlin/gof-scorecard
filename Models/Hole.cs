using GolfCard.InterfacesActual;
using System;

namespace GolfCard
{
  public class Hole : IHole
  {
    public int Par { get; set; }

    public Hole(int par)
    {
      Par = par;
    }
  }

}


