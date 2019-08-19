using System;
using System.Collections.Generic;
using GolfCard.InterfacesActual;
using GolfCard.Models;

namespace GolfCard
{
  public class App : IApp
  {
    public Course ActiveCourse { get; set; }
    public List<Player> Players { get; set; }
    public List<Course> Courses { get; set; }

    public void Run()
    {
      Greeting();
      DisplayCourses();
      SelectCourse();
      SetPlayers();
      DisplayPlayerResults();
    }
    public void Greeting()
    {
      Console.Clear();
      System.Console.WriteLine("Welcome to a fun game of Golf!\n");
    }
    public void DisplayCourses()
    {
      System.Console.WriteLine("We have a few game options:\n");
      for (int i = 1; i <= Courses.Count; i++)
      {
        System.Console.WriteLine(string.Format("{0}) {1}", i, Courses[i - 1].Name));
      }
    }
    public void SelectCourse()
    {
      System.Console.Write("Please Choose: ");
      string playersChoice = Console.ReadLine();
      while (ActiveCourse == null)
      {
        switch (playersChoice)
        {
          case "1":
            ActiveCourse = Courses[0];
            break;
          case "2":
            ActiveCourse = Courses[1];
            break;
          case "3":
            ActiveCourse = Courses[2];
            break;
          default:
            System.Console.WriteLine("Not a valid option. Try again!\n");
            break;
        }
      }

    }
    public void SetPlayers()
    {
      System.Console.Write("Number of Players: ");
      string amountOfPlayers = Console.ReadLine();
      int numOfPlayers;
      bool notAnOption = Int32.TryParse(amountOfPlayers, out numOfPlayers);
      if (!notAnOption)
      {
        System.Console.WriteLine("Please enter a number!\n");
        SetPlayers();
      }
      for (int i = 0; i < numOfPlayers; i++)
      {
        System.Console.Write(string.Format("Player {0} Name: ", i + 1));
        string playerName = Console.ReadLine();
        Players.Add(new Player(playerName));
      }
    }



    public void DisplayPlayerResults()
    {
      for (int i = 0; i < ActiveCourse.Holes.Count; i++)
      {
        Console.Clear();
        System.Console.WriteLine(string.Format("Hole: {0}", i + 1));

        foreach (Player player in Players)
        {
          System.Console.Write($"Strokes for {player.Name}: ");
          string strokesNumber = Console.ReadLine();
          int holeScore;
          bool notANumber = Int32.TryParse(strokesNumber, out holeScore);
          if (!notANumber)
          {
            System.Console.WriteLine("Please enter a number!\n");
          }
          player.Scores.Add(holeScore);
        }
      }
      System.Console.WriteLine(string.Format("Course Par: {0}", ActiveCourse.CoursePar));
      Player winner = Players[0];

      foreach (Player player in Players)
      {

        player.DisplayFinalScore();
        if (player.TotalScore < winner.TotalScore)
        {
          winner = player;
        }
      }
      System.Console.WriteLine("Winner: " + winner.Name);


    }


    public void Setup()
    {
      #region Holes List
      Hole par2 = new Hole(2);
      Hole par3 = new Hole(3);
      Hole par4 = new Hole(4);
      Hole par5 = new Hole(5);
      Hole par6 = new Hole(6);
      Hole par7 = new Hole(7);
      #endregion

      #region Courses + Hole Amount
      Course miniGolf = new Course("Mini Golf");
      miniGolf.Holes.Add(par2);
      miniGolf.Holes.Add(par3);
      miniGolf.Holes.Add(par2);
      miniGolf.Holes.Add(par3);

      Course somethingInBetween = new Course("Something In Between");
      somethingInBetween.Holes.Add(par3);
      somethingInBetween.Holes.Add(par2);
      somethingInBetween.Holes.Add(par4);
      somethingInBetween.Holes.Add(par2);
      somethingInBetween.Holes.Add(par4);
      somethingInBetween.Holes.Add(par3);


      Course superDuperHard = new Course("Super Duper Hard");
      superDuperHard.Holes.Add(par2);
      superDuperHard.Holes.Add(par4);
      superDuperHard.Holes.Add(par3);
      superDuperHard.Holes.Add(par7);
      superDuperHard.Holes.Add(par3);
      superDuperHard.Holes.Add(par5);
      superDuperHard.Holes.Add(par4);
      superDuperHard.Holes.Add(par6);
      superDuperHard.Holes.Add(par7);
      #endregion

      #region Course List
      Courses.Add(miniGolf);
      Courses.Add(somethingInBetween);
      Courses.Add(superDuperHard);
      #endregion
    }

    public App()
    {
      Players = new List<Player>();
      Courses = new List<Course>();
    }

  }
}
