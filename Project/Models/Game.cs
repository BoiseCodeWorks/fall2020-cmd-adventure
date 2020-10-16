using console_game_fall20.Project.Models;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public Game()
    {
      Setup();
      CurrentPlayer = new Player("");
    }

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      TrapRoom start = new TrapRoom("Start room", "You see a window about a perfect ladders height away.");
      IRoom two = new Room("This is the 2nd room", "Another room description");
      IRoom three = new Room("This room", "Another 3rd room description");

      start.AddRoomConnection(two, "east");
      two.AddRoomConnection(start, "west");
      start.AddRoomConnection(three, "north");
      three.AddRoomConnection(start, "south");

      Item ladder = new Item("Ladder", "A real nice ladder");
      start.Items.Add(ladder);

     start.AddUnlockable(ladder, "You can now climb the ladder out");

      CurrentRoom = start;
    }


  }
}