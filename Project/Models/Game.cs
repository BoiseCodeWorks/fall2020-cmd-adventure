using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Game : IGame
    {
    public Game()
    {
        Setup();
    }

        public IRoom CurrentRoom { get; set; }
        public IPlayer CurrentPlayer { get; set; }

        //NOTE Make yo rooms here...
        public void Setup()
        {
            IRoom start = new Room("Start room", "This is the starting room description");
            IRoom two = new Room("This is the 2nd room", "Another room description");
            IRoom three = new Room("This room", "Another 3rd room description");

            start.AddRoomConnection(two, "east");
            two.AddRoomConnection(start,"west");
            start.AddRoomConnection(three, "north");
            three.AddRoomConnection(start,"south");


            CurrentRoom = start;
        }

        
    }
}