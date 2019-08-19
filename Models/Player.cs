using GolfCard.InterfacesActual;
using System;
using System.Collections.Generic;

namespace GolfCard.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<int> Scores { get; set; }

    public void DisplayFinalScore()
    {
      System.Console.WriteLine(string.Format("{0}: {1}", Name, TotalScore));
    }
    public int TotalScore
    {
      get
      {
        int totalScore = 0;
        foreach (int score in Scores)
        {
          totalScore = totalScore + score;
        }
        return totalScore;


      }

    }

    public Player(string name)
    {
      Name = name;
      Scores = new List<int>();
    }


  }
}
